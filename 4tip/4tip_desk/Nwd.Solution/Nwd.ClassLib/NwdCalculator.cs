using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nwd.ClassLib
{
    public class NwdCalculator

    {
        public int CalculateNwd(int a, int b) {
            if (a==0 && b==0) 
                  throw new ArgumentException(
                      "NWD is not defined for both numbers being zero."
                      );
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (b==0) return a;
            return CalculateNwd(b, a % b);
        }
    }
}
