using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaggioreSenzaComparatori
{
    public class Resolver
    {
        public int Max(int a, int b)
        {
            var media = ((double)a + b) / 2;
            var diff = Math.Abs((double)a - b) / 2;
            
            return (int)(media + diff);
        }
    }
}
