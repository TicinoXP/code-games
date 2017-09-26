using System;
using System.Collections.Generic;

namespace PondSizeCalculator
{
    public class Pond
    {

        public int[] CalculateSize(int[,] pond)
        {
            if (pond.Length <= 0)
                throw new ArgumentException();

            int width = pond.GetLength(0);
            int height = pond.GetLength(1);
            var mark = new bool[width, height];
            var result = new List<int>();

            for (int r = 0; r < width; r++)
                for (int c = 0; c < height; c++)
                {
                    var size = CountCells(pond, mark, r, c);
                    if (size > 0)
                        result.Add(size);
                }

            result.Sort();
            return result.ToArray();
        }

        public int CountCells(int[,] pond, bool[,] yetMarked, int r, int c)
        {
            if (r >= pond.GetLength(0) || r < 0 ||
                c >= pond.GetLength(1) || c < 0)
                return 0;

            if (yetMarked[r, c])
                return 0;

            yetMarked[r, c] = true;
            if (pond[r, c] != 0)
                return 0;

            return 1 +
                CountCells(pond, yetMarked, r + 1, c) +
                CountCells(pond, yetMarked, r + 1, c + 1) +
                CountCells(pond, yetMarked, r, c + 1) +
                CountCells(pond, yetMarked, r - 1, c + 1) +
                CountCells(pond, yetMarked, r - 1, c) +
                CountCells(pond, yetMarked, r - 1, c - 1) +
                CountCells(pond, yetMarked, r, c - 1) +
                CountCells(pond, yetMarked, r + 1, c - 1);
        }
    }
}
