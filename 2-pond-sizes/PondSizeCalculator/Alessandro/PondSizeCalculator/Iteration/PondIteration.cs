using System;
using System.Collections.Generic;

namespace PondSizeCalculator.Iteration
{
    public class PondIteration
    {
        public int[] CalculateSize(int[,] pondMatrix)
        {
            if (pondMatrix.Length <= 0)
                throw new ArgumentException();

            int[] result = null;
            var pondCollection = new List<List<PondPortion>>();

            int width = pondMatrix.GetLength(0);
            int height = pondMatrix.GetLength(1);

            for (int r = 0; r < width; r++)
            {
                for (int c = 0; c < height; c++)
                {
                    if (pondMatrix[r, c].IsWater())
                    {
                        var foundContiguous = false;

                        var pp = new PondPortion(new Tuple<int, int>(r, c));
                        foreach (var pond in pondCollection)
                        {
                            if (pond.IsContiguous(pp))
                            {
                                pond.Add(pp);
                                foundContiguous = true;
                                break;
                            }
                        }
                        if (!foundContiguous)
                            pondCollection.Add(new List<PondPortion>() {pp});
                    }
                }
            }

            for (int k = 0; k < pondCollection.Count; k++)
            {
                for (int j = 0; j < pondCollection.Count; j++)
                {
                    if (k == j)
                        continue;

                    var pondExt = pondCollection[k];
                    var pondInt = pondCollection[j];

                    foreach (var pp in pondExt)
                    {
                        if (pondInt.IsContiguous(pp))
                        {
                            pondExt.AddRange(pondInt);
                            pondCollection.Remove(pondInt);
                            break;
                        }
                    }
                }
            }

            result = new int[pondCollection.Count];
            for (int k = 0; k < pondCollection.Count; k++)
                result[k] = pondCollection[k].Count;
            Array.Sort(result);
            return result;
        }
    }
}
