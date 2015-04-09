using Newtonsoft.Json;
using System;
using System.Web;

namespace Simple.OperCookie
{
    internal class Core
    {
        internal static string s_ShareName = "Share_Cookie";
        internal static string s_MainName = "Main_Cookie";
        internal static string s_SubName = "Sub_Cookie";

        public static void CreateCookie()
        {
            SetCookieData(new Info() { Name = s_ShareName, Path = "/Login", Data = "共用 資料", Id = Guid.NewGuid(), Stamp = DateTime.Now });
            SetCookieData(new Info() { Name = s_MainName, Path = "/Login/Main.aspx", Data = "@main.aspx", Id = Guid.NewGuid(), Stamp = DateTime.Now });
            SetCookieData(new Info() { Name = s_SubName, Path = "/Login/Sub.aspx", Data = "@sub.aspx", Id = Guid.NewGuid(), Stamp = DateTime.Now });
        }

        public static void ReadCookie()
        {
            GetCookieData(s_ShareName);
            GetCookieData(s_MainName);
            GetCookieData(s_SubName);
        }

        public static void DeleteCookie()
        {
            DelateCookieData(s_ShareName, "/Login");
            DelateCookieData(s_MainName, "/Login/Main.aspx");
            DelateCookieData(s_SubName, "/Login/Sub.aspx");
        }

        private static void DelateCookieData(string cookieName, string path)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieName] ?? new HttpCookie(cookieName);
            cookie.Expires = DateTime.Now.AddDays(-1);
            cookie.Path = path;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private static void SetCookieData(Info info)
        {
            var cookie = HttpContext.Current.Request.Cookies[info.Name] ?? new HttpCookie(info.Name);
            //cookie.Domain = "azurewebsites.net";
            //cookie.Domain = "localhost";
            cookie.HttpOnly = true;
            cookie.Path = info.Path;
            var json = JsonConvert.SerializeObject(info);
            cookie.Value = HttpContext.Current.Server.UrlEncode(json);// HttpUtility.UrlEncode(json);
            //cookie.Value = json;// HttpUtility.UrlEncode(json);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private static Info GetCookieData(string cookieName)
        {
            var shareCookie = HttpContext.Current.Request.Cookies[cookieName];

            if (shareCookie != null)
            {
                var result = JsonConvert.DeserializeObject<Info>(HttpUtility.UrlDecode(shareCookie.Value));

                HttpContext.Current.Response.Write(string.Format("Cookie Name:{0}<br/>", result.Name));

                HttpContext.Current.Response.Write(
                    string.Format(@"
<pre>
Path:{0}
Stamp:{1}
Data:{2}
Id:{3}
</pre>",
                    result.Path, result.Stamp, result.Data, result.Id));
                HttpContext.Current.Response.Write("<br/>");
                return result;
            }
            return null;
        }
    }
}