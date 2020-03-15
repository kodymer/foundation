using System;
using System.Collections.Generic;
using System.Text;

namespace Contoso.OnlineStore.Logging
{
    public class Logger : ILogger
    {

        public Logger()
        {

        }

        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
