﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1
{
    public static class HttpContextFactory
    {
        [ThreadStatic]
        private static HttpContextBase s_mockHttpContext;

        public static void SetHttpContext(HttpContextBase httpContextBase)
        {
            s_mockHttpContext = httpContextBase;
        }

        public static void ResetHttpContext()
        {
            s_mockHttpContext = null;
        }

        public static HttpContextBase GetHttpContext()
        {
            if (s_mockHttpContext != null)
            {
                return s_mockHttpContext;
            }
            if (HttpContext.Current != null)
            {
                return new HttpContextWrapper(HttpContext.Current);
            }
            return null;
        }
    }
}