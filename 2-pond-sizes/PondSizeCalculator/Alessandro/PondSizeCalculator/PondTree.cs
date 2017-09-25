using System;
using System.Collections.Generic;

namespace PondSizeCalculator
{
    public class PondTree
    {

        public int[] CalculateSize(int[,] pond)
        {
            if (pond.Length <= 0)
                throw new ArgumentException();

            int[] result = null;
            var treeCollection = new List<PondPiece>();

            int width = pond.GetLength(0);
            int height = pond.GetLength(1);

            for (int r = 0; r < width; r++)
                for (int c = 0; c < height; c++)
                {
                    if (pond[r, c].IsWater())
                    {
                        var findParent = false;

                        var pp = new PondPiece(new Tuple<int, int>(r, c));
                        foreach (var tree in treeCollection)
                        {
                            if (tree.Is(pp))
                                continue;

                            if (tree.HasChild(pp))
                                continue;

                            var parent = tree.Find(pondPiece => pondPiece.IsNear(pp));
                            if (parent != null)
                            {
                                tree.AddChild(pp);
                                findParent = true;
                                break;
                            }
                        }
                        if (!findParent)
                            treeCollection.Add(pp);
                    }
                }

            result = new int[treeCollection.Count];
            for (int k = 0; k < treeCollection.Count; k++)
                result[k] = treeCollection[k].CountChild();
            Array.Sort(result);
            return result;
        }

        public class PondPiece
        {
            public PondPiece Parent;
            public List<PondPiece> Childs = new List<PondPiece>();

            public Tuple<int, int> Position { get; }

            public PondPiece(Tuple<int, int> position)
            {
                Parent = null;
                Position = position;
            }

            public void AddChild(PondPiece pondPiece)
            {
                Childs.Add(pondPiece);
            }

            public bool Is(PondPiece pondPiece) => this.Equals(pondPiece);

            public bool HasChild(PondPiece pondPiece) => Childs.Contains(pondPiece);

            public int CountChild() => 1 + Childs.Count;

            public override bool Equals(object obj)
            {
                if (obj is PondPiece && (obj as PondPiece).Position == this.Position)
                    return true;

                return false;
            }

            public bool IsNear(PondPiece pp)
            {
                return pp.Position.Item1 - 1 <= Position.Item1 && pp.Position.Item1 + 1 >= Position.Item1 &&
                       pp.Position.Item2 - 1 <= Position.Item2 && pp.Position.Item2 + 1 >= Position.Item2;
            }

            public PondPiece Find(Predicate<PondPiece> func)
            {
                if (func.Invoke(this))
                    return this;

                return Childs.Find(func);
            }
        }
    }

    public static class Extension
    {
        public static bool IsWater(this int pond)
        {
            return pond == 0;
        }
    }
}
