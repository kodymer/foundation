using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    public static class Check
    {

        public static T NotNull<T>(T value, string name){
        
            if(value == null)
            {
                throw new ArgumentNullException("The argument could not null", name);
            }

            return value;
        }

        public static string NotNull(string value, string name)
        {

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("The argument could not null", name);
            }

            return value;
        }
    }
}
