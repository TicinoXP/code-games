using System;
using System.Collections.Generic;
using System.Text;
using PondSizeCalculator.Iteration;

namespace PondSizeCalculator
{
    public static class Extension
    {
        public static bool IsWater(this int pond)
        {
            return pond == 0;
        }

        public static bool IsContiguous(this List<PondPortion> source, PondPortion target) =>
            source.Find(pp => pp.IsNear(target)) != null;
    }
}
