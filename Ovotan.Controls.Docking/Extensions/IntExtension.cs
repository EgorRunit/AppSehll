using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class DoubleExtension
    {
        public static double GetPercent(this double x, int percent)
        {
            return x * (percent / 100.0);
        }
    }
}
