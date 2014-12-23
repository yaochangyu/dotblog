using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simple.Utility
{
    public class Security
    {
        public bool IsVerify(string userId, string password)
        {
            return userId == "yao" && password == "1234";
        }
    }
}
