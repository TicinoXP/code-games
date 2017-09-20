using System;
using System.Linq.Expressions;

namespace NoCompare
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("No Compare!");

      Console.WriteLine("Insert first number:");
      var number1 = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Insert second number:");
      var number2 = Convert.ToInt32(Console.ReadLine());

      var result = Max(number1, number2);
      Console.WriteLine($"The bigger number is: {result}");

      Console.ReadLine();
    }

    private static int Max(int number1, int number2)
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
