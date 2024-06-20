// C# program for implementation of
// Newton Raphson Method for solving
// equations
using System;

public class Program
{

    static double TERMINATINGCONDITION = 0.00001;

    // The function is x^3 - 4x^2 + x - 2
    static double mainFunction(double x)
    {
        return x * x * x - 4 * x * x + x - 10;
    }

    // Derivative of the above function
    // which is 3*x^2 - 8*x + 1
    static double firstDerivative(double x)
    {
        return 3 * x * x - 8 * x + 1;
    }

    static double secondDerivative(double x)
    {
        return 6 * x - 8;
    }

    //Test for convergence
    static double convergenceTest(double x)
    {
        return (Math.Abs(mainFunction(x)) * Math.Abs(secondDerivative(x))) / Math.Abs(firstDerivative(x) * Math.Abs(firstDerivative(x)));
    }

    // Function to find the root
    static void newtonRaphson(double x)
    {
        var convergence = convergenceTest(x);

        double h = mainFunction(x) / firstDerivative(x);
        //test for convergence
        if (convergence > 0 && convergence < 1)
        {
            Console.WriteLine("The value is divergent. Please enter another number.");

        }
        else
        {
            while (Math.Abs(h) >= TERMINATINGCONDITION)
            {
                h = mainFunction(x) / firstDerivative(x);

                // x(i+1) = x(i) - f(x) / f'(x)
                x = x - h;
            }

            Console.Write("The value of the"
                        + " root is : "
                        + Math.Round(x * 10000.0) / 10000.0);
        }
        
    }

    public static void Main()
    {
        Console.WriteLine("This program is applicable to function x^3 - 4x^2 + x - 10");
        Console.WriteLine("Enter an initial value: ");
        string initialValue = Console.ReadLine();

        //convert initial value to double
        double result = Convert.ToDouble(initialValue);

        newtonRaphson(result);
    }
}

