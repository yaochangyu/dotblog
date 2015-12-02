using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simple.JavaScriptUseResource
{
    public class Utility
    {
        private static string LANGUAGE = "Language";

        public static string GetLanguage()
        {
            string language = HttpContext.Current.Request.UserLanguages[0];
            var cookie = HttpContext.Current.Request.Cookies[LANGUAGE];
            if (cookie != null)
            {
                language = cookie.Value;
            }

            return language;
        }

        public static void WriteLanguage(string culture)
        {
            var cookie = HttpContext.Current.Request.Cookies[LANGUAGE];
            if (cookie == null)
            {
                cookie = new HttpCookie(LANGUAGE);
            }
            cookie.HttpOnly = true;
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Value = culture;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
    }
}