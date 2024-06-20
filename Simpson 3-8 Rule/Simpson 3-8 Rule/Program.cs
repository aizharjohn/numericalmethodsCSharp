using System;

namespace CodeTranslation
{
    class Program
    {
        static double function(double x)
        {
            return 0.2 + 25*x - 200*x*x + 675*x*x*x - 900*x*x*x*x + 400*x*x*x*x*x;
        }

        static void Main(string[] args)
        {
            double lower, upper, integration = 0.0, stepSize, k;
            int i, segment;

            Console.WriteLine("This program computes the approximate integral of the function");
            Console.WriteLine("f(x) = 0.2 + 25x - 200x^2 + 675x^3 - 900x^4 + 400x^5");

            Console.WriteLine("\nEnter lower limit of integration: ");
            
            lower = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter upper limit of integration: ");

            upper = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter number of segments: ");

            segment = Convert.ToInt32(Console.ReadLine());

            stepSize = (upper - lower) / segment;

            integration = function(lower) + function(upper);
            for (i = 1; i <= segment - 1; i++)
            {
                k = lower + i * stepSize;
                if (i % 3 == 0)
                {
                    integration = integration + 2 * function(k);
                }
                else
                {
                    integration = integration + 3 * function(k);
                }
            }
            integration = integration * stepSize * 3 / 8;

            Console.WriteLine($"\nThe step size is {stepSize:F5}");
    
            Console.WriteLine($"\nThe approximate of integral is: {integration:F5}");
        }
    }
}