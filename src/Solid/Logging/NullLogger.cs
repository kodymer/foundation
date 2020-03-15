using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.OnlineStore.Logging
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
