using System.Collections.Generic;
using System.Linq;

namespace PondSizes
{
    public class Land
    {
        public int[,] Spots { get; set; }

        public List<int> Solve()
        {
            var sizes = new List<int>();
            for (var x = 0; x < Spots.GetLength(0); x++)
            for (var y = 0; y < Spots.GetLength(1); y++)
            {
                var size = CalculateSize(x, y);
                if (size > 0)
                    sizes.Add(size);
            }
            return sizes;
        }

        private int CalculateSize(int x, int y)
        {
            var maxX = Spots.GetLength(0);
            var maxY = Spots.GetLength(1);

            if (x < 0 || x >= maxX || y < 0 || y >= maxY || Spots[x, y] != 0) return 0;

            Spots[x, y] = -1;

            return 
                NeighborsOf(x, y).Aggregate(1, (current, neighbor) => current + CalculateSize(neighbor.X, neighbor.Y));
        }


        private static IEnumerable<Spot> NeighborsOf(int x, int y)
        {
            return new List<Spot>
            {
                new Spot(x, y - 1),
                new Spot(x - 1, y - 1),
                new Spot(x + 1, y - 1),
                new Spot(x - 1, y),
                new Spot(x + 1, y),
                new Spot(x - 1, y + 1),
                new Spot(x + 0, y + 1),
                new Spot(x + 1, y + 1)
            };
        }
    }
}