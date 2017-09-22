using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxWithoutComparators
{
    public class Arialdo
    {
        public int Max(int a, int b)
        {
            var k = int.MaxValue / 2;

            var ab = ConvertToBinary(a + k);
            var bb = ConvertToBinary(b + k);

            var aLenght = ab.Count();
            var bLenght = bb.Count();

            for (var i = 0; i < aLenght - bLenght; i++)
                bb.Insert(0, false);
            for (var i = 0; i < bLenght - aLenght; i++)
                ab.Insert(0, false);

            var reduce = AIsBigger(ab, bb);
            var bit = ToBit(reduce);
            return a * bit + b * (1 - bit);
        }

        public static int Combine(int a, int b)
        {
            return (a << 1) + b;
        }

        public int ToBit(bool value)
        {
            var dictionary = new Dictionary<bool, int>
            {
                {true, 1},
                {false, 0}
            };

            return dictionary[value];
        }

        public static bool ToBoolean(int value)
        {
            return Convert.ToBoolean(value);
        }

        public bool AIsBigger(List<bool> ab, List<bool> bb)
        {
            var headA = ab.First();
            var headB = bb.First();

            var tailA = ab.Skip(1).ToList();
            var tailB = bb.Skip(1).ToList();

            var aIsBigger = IsBigger(headA, headB);

            var areEqual = AreEqual(headA, headB);

            var thereAreOtherItems = ThereAreOtherItems(tailA);

            return 
                (
                    aIsBigger
                )
                || 
                (
                    areEqual
                    && 
                    (
                        (thereAreOtherItems && AIsBigger(tailA, tailB))
                        || 
                        !thereAreOtherItems
                    )
                );
        }

        public static bool ThereAreOtherItems(List<bool> ab)
        {
            return ToBoolean(ab.Count());
        }

        public static List<bool> ConvertToBinary(int number)
        {
            return Convert.ToString(number, 2).Select(c => ToBoolean(int.Parse(c.ToString()))).ToList();
        }

        public bool IsBigger(bool a, bool b)
        {
            return a && !b;
        }

        public bool AreEqual(bool a, bool b)
        {
            return a && b || (!a && !b);
        }
    }
}