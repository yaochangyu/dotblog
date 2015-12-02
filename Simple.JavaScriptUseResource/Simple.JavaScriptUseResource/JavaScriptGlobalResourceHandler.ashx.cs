using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;
using System.Web.Script.Serialization;

namespace Simple.JavaScriptUseResource
{
    /// <summary>
    /// Summary description for JavaScriptGlobalResourceHandler
    /// </summary>
    public class JavaScriptGlobalResourceHandler : IHttpHandler
    {
        private static Assembly s_globalAssembly;
        private static Dictionary<string, ResourceManager> s_resourceManagerPool;

        static JavaScriptGlobalResourceHandler()
        {
            if (s_globalAssembly == null)
            {
                s_globalAssembly = Assembly.Load("App_GlobalResources");
            }
            if (s_resourceManagerPool == null)
            {
                s_resourceManagerPool = new Dictionary<string, ResourceManager>();
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var requestedUICulture = context.Request.QueryString["UICulture"];
            var requestResourceKey = context.Request.QueryString["ResourceKey"];

            if (string.IsNullOrWhiteSpace(requestedUICulture))
            {
                throw new ArgumentNullException("UICulture");
            }
            if (string.IsNullOrWhiteSpace(requestResourceKey))
            {
                throw new ArgumentNullException("ResourceKey");
            }

            var globalResources = this.ReadResources(requestResourceKey, requestedUICulture);
            var javaScriptObject = this.GenerateJavaScriptObject(requestResourceKey, globalResources);

            context.Response.ContentType = "application/javascript";
            context.Response.Expires = 1440;//1天
            context.Response.Cache.SetLastModified(DateTime.UtcNow);
            context.Response.Write(javaScriptObject);
        }

        private string GenerateJavaScriptObject(string requestResourceKey, Dictionary<object, object> globalResources)
        {
            var javaScriptSerializer = new JavaScriptSerializer();

            var script =
                @"
if (typeof(Resources) == ""undefined"") Resources = {};
Resources." + requestResourceKey + " = " +
                javaScriptSerializer.Serialize(globalResources) + ";";
            return script;
        }

        private Dictionary<object, object> ReadResources(
           string resourceKey, string requestedUICulture)
        {
            var uiCultureInfo = CultureInfo.GetCultureInfo(requestedUICulture);
            var resourceManager = this.CreateResourceManager(resourceKey);

            var resourceSet = resourceManager.GetResourceSet(uiCultureInfo, true, true);
            Dictionary<object, object> result = null;
            result = resourceSet.Cast<DictionaryEntry>().ToDictionary(
                x => x.Key,
                x => resourceManager.GetObject((string)x.Key, uiCultureInfo));

            return result;
        }

        private ResourceManager CreateResourceManager(string resourceKey)
        {
            //var assembly = s_globalAssembly;
            var key = "Resources." + resourceKey;

            ResourceManager resourceManager = null;
            if (s_resourceManagerPool.ContainsKey(key))
            {
                resourceManager = s_resourceManagerPool[key];
            }
            else
            {
                resourceManager = new ResourceManager(key, s_globalAssembly);
                s_resourceManagerPool.Add(key, resourceManager);
            }
            return resourceManager;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}