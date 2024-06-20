﻿// C# program for implementing
// Newton divided difference formula
using System;

public class Program

{
    // Function to find the product term
    static float proterm(int i, float value, float[] x)
    {
        float pro = 1;
        for (int j = 0; j < i; j++)
        {
            pro = pro * (value - x[j]);
        }
        return pro;
    }

    // Function for calculating
    // divided difference table
    static void dividedDiffTable(float[] x, float[,] y, int n)
    {
        for (int i = 1; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                y[j, i] = (y[j, i - 1] - y[j + 1, i - 1]) / (x[j] - x[i + j]);
            }
        }
    }

    // Function for applying Newton's
    // divided difference formula
    static float applyFormula(float value, float[] x,
                    float[,] y, int n)
    {
        float sum = y[0, 0];

        for (int i = 1; i < n; i++)
        {
            sum = sum + (proterm(i, value, x) * y[0, i]);
        }
        return sum;
    }

    // Function for displaying
    // divided difference table
    static void printDiffTable(float[,] y, int n)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n - i; j++)
            {
                Console.Write(Math.Round(y[i, j], 4) + "\t ");
            }
            Console.WriteLine("");
        }
    }

    // Driver Function
    public static void Main()
    {
        // number of inputs given
        int n = 4;
        float value;
        float[,] y = new float[10, 10];
        float[] x = { 5, 6, 9, 11 };

        // y[][] is used for divided difference
        // table where y[][0] is used for input
        y[0, 0] = 12;
        y[1, 0] = 13;
        y[2, 0] = 14;
        y[3, 0] = 16;

        // calculating divided difference table
        dividedDiffTable(x, y, n);

        // displaying divided difference table
        printDiffTable(y, n);

        // value to be interpolated
        value = 7;

        // printing the value

        Console.WriteLine("\nValue at " + (value) + " is "
                + Math.Round(applyFormula(value, x, y, n), 2));
    }
}
