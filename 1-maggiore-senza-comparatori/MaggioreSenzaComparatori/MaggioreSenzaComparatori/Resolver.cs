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
            var queue = new Queue<int>();

            for (int i = 0; i < a; i++)
                queue.Enqueue(a);

            for (int i = 0; i < b; i++)
                queue.Enqueue(b);

            var t = (a + b) / 2;
            int value = 0;
            for (int i = 0; i <= t; i++)
                value = queue.Dequeue();

            return value;
        }
    }
}
