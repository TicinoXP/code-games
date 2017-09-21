using System;
using System.Collections.Generic;
using System.Text;

namespace NoCompare
{
  public class Comparer
  {
    public int Max(int number1, int number2)
    {
      try
      {
        var result = number1 - number2;
        Convert.ToUInt32(result);

        return number1;
      }
      catch
      {
        return number2;
      }
    }
  }
}
