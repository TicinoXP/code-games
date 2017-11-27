using System.Collections.Generic;
using System.Linq;

namespace PondSizes
{
    public struct Pond
    {
        public Pond(IEnumerable<Spot> spots)
        {
            Spots = spots;
        }

        public IEnumerable<Spot> Spots { get; }

        public static Pond Build(int x, int y)
        {
            return Build(new Spot(x, y));
        }

        public static Pond Build(Spot spot)
        {
            return new Pond(new List<Spot> {spot});
        }

        public bool Contains(int x, int y)
        {
            return Contains(new Spot(x, y));
        }

        public bool Contains(Spot spot)
        {
            return Spots.Contains(spot);
        }

        public Pond MeltWith(Pond another)
        {
            return new Pond(Spots.Concat(another.Spots));
        }
    }
}