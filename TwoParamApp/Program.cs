//giving access to the system library
using System;
using System.IO.Pipelines;

namespace TwoParamApp
{
    public class MathOperations
    {
        //method that takes two parameters and does 
        //some math with them
        public void DoMath(int num1, int num2)
        {
            //perform a math operation on the first number
            int result = num1 * 2;
            //displaying the result of the first number
            Console.WriteLine($"The result of {num1} * 2 is: {result}");

            //displaying the second number to the user
            Console.WriteLine($"Second number is: {num2}");
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            //creating an instance of the MathOperations class
            MathOperations mathOps = new MathOperations();

            //calliing the DoMath method with two numbers as arguments
            mathOps.DoMath(5, 10);

            Console.WriteLine("-----------------");

            //call the method again using named parameters
            //this allows us to specify the parameters in any order
            mathOps.DoMath(num2: 20, num1: 15);
        }
    }
}