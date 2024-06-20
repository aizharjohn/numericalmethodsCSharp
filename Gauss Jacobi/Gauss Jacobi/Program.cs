using System;

class Program
{
    static float fx(float y, float z)
    {
        float x1;
        x1 = 4 - 2 * y - 3 * z;
        return x1;
    }

    static float fy(float x, float z)
    {
        float y1;
        y1 = (8 - 5 * x - 7 * z) / 6;
        return y1;
    }

    static float fz(float x, float y)
    {
        float z1;
        z1 = (3 - 9 * x - y) / 2;
        return z1;
    }

    static void Main()
    {
        int i, j, n;
        float a1, b1, c1;
        float a, b, c;
        float[,] ar = new float[3, 4];
        float[] x = new float[3];

        Console.WriteLine("Enter the no. of Iteration : ");
        n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter The initial value : ");
        string[] input = Console.ReadLine().Split(' ');
        a = float.Parse(input[0]);
        b = float.Parse(input[1]);
        c = float.Parse(input[2]);

        for (i = 0; i < n; i++)
        {
            for (j = 0; j < n; j++)
            {
                a1 = fx(b, c);
                b1 = fy(a, c);
                c1 = fz(a, b);
                a = a1;
                b = b1;
                c = c1;
            }
        }

        Console.WriteLine("a1 = {0}\n a2 = {1}\n a3 = {2}", a, b, c);
    }
}