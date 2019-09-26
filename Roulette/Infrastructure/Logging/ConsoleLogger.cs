using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Interfaces;

namespace Roulette.Infrastructure.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(object output)
        {
            Console.WriteLine(output);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
