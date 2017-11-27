using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace PondSizes
{
    public static class Builder
    {
        public static Land Build(string inp)
        {
            var rows = SplitLines(inp);
            var cells = rows.Select(SplitLine).ToArray();

            var nColumns = cells[0].Length;
            var nRows = rows.Length;


            var vs = new int[nRows, nColumns];

            for (var column = 0; column < nColumns; column++)
            {
                for (var row = 0; row < nRows; row++)
                {
                    vs[row, column] = cells[row][column];
                }
            }

            return new Land {Spots = vs};
        }

        public static string[] SplitLines(string inp)
        {
            return inp.Split('\r').Select(l => l.Trim()).ToArray();
        }

        public static int[] SplitLine(string line)
        {
            line = Clean(line);

            var strings = line.Trim().Split(' ');
            return strings.Select(int.Parse).ToArray();
        }

        public static string Clean(string line)
        {
            var regex = new Regex("[ ]{2,}", RegexOptions.None);
            return regex.Replace(line.Trim().Replace("\r\n", "\r"), " ");
        }
    }
}