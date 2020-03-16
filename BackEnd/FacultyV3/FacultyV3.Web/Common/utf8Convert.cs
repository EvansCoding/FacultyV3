using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace FacultyV3.Web.Common
{
    public  class utf8Convert
    {
        private static utf8Convert instance;

        public static utf8Convert Instance
        {
            get
            {
                if (instance == null) return instance = new utf8Convert();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }
        public utf8Convert()
        {

        }

        public string utf8Convert3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public string ToUrlFriendly(string data)
        {
            var s = utf8Convert3(data).Replace(" ", "-").ToLower();
            return s;
        }
    }
}