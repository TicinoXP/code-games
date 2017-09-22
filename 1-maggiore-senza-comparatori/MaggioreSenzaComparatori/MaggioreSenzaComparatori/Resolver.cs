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
            var list = new List<int>();

            for (var i = 0; i < a; i++)
                list.Add(a);
            for (var i = 0; i < b; i++)
                list.Add(b);

            return list[(a + b) / 2];
        }
    }
}
