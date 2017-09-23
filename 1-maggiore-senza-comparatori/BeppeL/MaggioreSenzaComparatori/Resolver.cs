using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaggioreSenzaComparatori
{
    public class Resolver
    {
        public short Max(short a, short b)
        {
            var list = new List<uint>();

            var uintA = (ushort)(short.MaxValue + a);
            for (var i = 0; i < uintA; i++)
                list.Add(uintA);

            var uintB = (ushort)(short.MaxValue + b);
            for (var i = 0; i < uintB; i++)
                list.Add(uintB);

            return (short)(list[((uintA + uintB) / 2)] - short.MaxValue);
        }
    }
}
