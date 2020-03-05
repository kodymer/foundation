using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore
{
    public class NullLogger : ILogger
    {
        public static NullLogger Instance;

        static NullLogger()
        {
            Instance = new NullLogger();
        }

        public void Write(string message)
        {
            
        }
    }
}
