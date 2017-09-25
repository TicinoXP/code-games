using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PondSizeCalculator.Test
{
    [TestClass]
    public class PondCalculationTest
    {
        private readonly List<int[,]> _ponds;
        private readonly List<int[]> _expectedResults;

        public PondCalculationTest()
        {
            _ponds = new List<int[,]>();
            _expectedResults = new List<int[]>();

            FillTestData(_ponds, _expectedResults);
        }

        private void FillTestData(List<int[,]> ponds, List<int[]> expectedResults)
        {
            ponds.Add(new[,] {
                    { 0, 2, 1, 0 },
                    { 0, 1, 0, 1 },
                    { 1, 1, 0, 1 },
                    { 0, 1, 0, 1 }
            });
            expectedResults.Add(new[] { 1, 2, 4 });

            ponds.Add(new[,] {
                    { 0, 0, 1, 0 },
                    { 0, 0, 0, 1 },
                    { 1, 1, 0, 1 },
                    { 0, 1, 0, 1 }
            });
            expectedResults.Add(new[] { 1, 8 });

            ponds.Add(new[,] {
                    { 0, 2, 1 },
                    { 0, 1, 0 },
                    { 1, 1, 0 }
            });
            expectedResults.Add(new[] {2, 2 });

            ponds.Add(new[,] {
                    { 1, 2, 1 },
                    { 1, 0, 0 },
                    { 1, 1, 0 }
            });
            expectedResults.Add(new[] { 3 });

            ponds.Add(new[,] {
                    { 1, 2, 1 },
                    { 1, 0, 1 },
                    { 1, 1, 1 }
            });
            expectedResults.Add(new[] { 1 });

            ponds.Add(new[,] {
                    { 1, 2, 1, 0, 1, 2, 0 }, // | | | X | | X
                    { 1, 0, 1, 0, 0, 1, 0 }, // | X | X X | X
                    { 1, 1, 2, 1, 0, 0, 1 }, // | | | | X X |
                    { 0, 2, 1, 1, 0, 0, 2 }, // X | | | x x |
                    { 1, 0, 1, 2, 1, 0, 1 }, // | X | | | X |
                    { 1, 0, 1, 1, 2, 1, 1 }, // | X | | | | |
                    { 0, 1, 0, 0, 0, 0, 1 }, // X | X X X X |
                    { 1, 1, 1, 2, 2, 1, 1 }, // | | | | | | |
                    { 0, 0, 0, 1, 1, 2, 0 }, // X X X | | | X
                    { 1, 1, 1, 0, 2, 3, 0 }, // | | | X | | X
                    { 1, 1, 0, 1, 1, 0, 1 }  // | | X | | X |
            });
            expectedResults.Add(new[] { 1, 3, 5, 8, 10 });

        }

        [TestMethod]
        public void TestCalculateMethod()
        {
            var pond = new PondTree();

            for (int k = 0; k < _ponds.Count; k++)
            {
                var actual = pond.CalculateSize(_ponds[k]);

                CollectionAssert.AreEqual(_expectedResults[k], actual);
            }
        }
    }
}
