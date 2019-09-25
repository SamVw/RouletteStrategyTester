using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roulette.Core.Interfaces;

namespace Roulette.Infrastructure.Reader
{
    public class ConsoleReader : IInputReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
