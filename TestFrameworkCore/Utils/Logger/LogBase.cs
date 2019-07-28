using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFrameworkCore.Utils.Logger
{
    public abstract class LogBase
    {
        public abstract void Log(string message);

        public abstract void Log(string message, CustomLogType type);
    }
}
