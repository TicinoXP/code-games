using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NoCompare.Test
{
  [TestClass]
  public class ComparerTest
  {
    private readonly Comparer _comparer;

    public ComparerTest()
    {
      _comparer = new Comparer();
    }

    [DataTestMethod]
    [DataRow(2,3,3)]
    [DataRow(3,2,3)]
    [DataRow(-3,2,2)]
    [DataRow(3,-2,3)]
    [DataRow(-3, -2, -2)]
    public void TestMethod1(int firstNumber, int secondNumber, int expected)
    {
      var result = _comparer.Max(firstNumber, secondNumber);

      Assert.AreEqual(expected, result);
    }
  }
}
