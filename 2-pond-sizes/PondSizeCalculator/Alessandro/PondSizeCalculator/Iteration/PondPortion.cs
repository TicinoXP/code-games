using System;
using System.Collections.Generic;
using System.Text;

namespace PondSizeCalculator.Iteration
{
    public class PondPortion
    {
        public Tuple<int, int> Position { get; }

        public PondPortion(Tuple<int, int> position)
        {
            Position = position;
        }

        public bool Is(PondPortion pondPortion) => this.Equals(pondPortion);

        public static bool operator ==(PondPortion a, PondPortion b) => a is null ? b is null : a.Equals(b);

        public static bool operator !=(PondPortion a, PondPortion b) => !(a == b);

        public override bool Equals(object obj)
        {
            if (obj is PondPortion && (obj as PondPortion).Position == this.Position)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            return Position.GetHashCode();
        }

        public bool IsNear(PondPortion pp)
        {
            return pp.Position.Item1 - 1 <= Position.Item1 && pp.Position.Item1 + 1 >= Position.Item1 &&
                   pp.Position.Item2 - 1 <= Position.Item2 && pp.Position.Item2 + 1 >= Position.Item2;
        }
    }
}
