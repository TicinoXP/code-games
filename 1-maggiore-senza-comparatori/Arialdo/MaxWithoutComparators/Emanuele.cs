using System;

namespace MaxWithoutComparators
{
    public class Emanuele
    {
        public int Max(int a, int b)
        {
            return (a + b + Math.Abs(a - b)) / 2;
        }
    }
}