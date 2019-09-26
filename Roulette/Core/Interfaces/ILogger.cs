using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Core.Interfaces
{
    public interface ILogger
    {
        void Log(object output);
        void Clear();
    }
}
