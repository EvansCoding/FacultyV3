using FacultyV3.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacultyV3.Web.Common
{
    public class ProcessString
    {
        private static ProcessString instance;

        public static ProcessString Instance {
            get
            {
                if (instance == null) return instance = new ProcessString();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public string ShortCutString(string str)
        {
            if(str.Count() < Constant.SERIALACCEPT)
            {
                return str;
            }

            var s = str.Substring(0, Constant.SERIALACCEPT - 1) + "...";

            return s;
        }
    }
}