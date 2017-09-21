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

      var result = new Comparer().Max(number1, number2);
      Console.WriteLine($"The bigger number is: {result}");

      Console.ReadLine();
    }

    
  }
}
