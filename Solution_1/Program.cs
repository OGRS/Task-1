using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    class Program
    {
        public static void Matrix()
        {
            double[,] numbers = new double[,] { { 1, 2.35, 4 }, { 2, 3, 6 }, { 3, 4, 8 }, { 3, 4, 8 } };
            double[,] numbers1 = new double[,] { { 1, 2.35, 4 }, { 2, 3, 6 }, { 3, 4, 8 } };

            Matrix left = new Matrix(numbers);
            Matrix right = new Matrix(numbers);

            Matrix result = left * right;

            if (result != null)
            {
                int col = result.Columns, row = result.Rows;

                for (int i = 0; i < col; i++)
                {
                    for (int j = 0; j < row; j++)
                    {
                        Console.Write(result[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }

        public static void Polynomial()
        {
            List<double> coefficient1 = new List<double>() { 2, 3, 1 };
            List<uint> power1 = new List<uint>() { 3, 1 };

            List<double> coefficient2 = new List<double>() { 1, 2, 1, 3, 5 };
            List<uint> power2 = new List<uint>() { 5, 3, 2, 1 };

            Polynomial pol1 = new Polynomial(coefficient1, power1);
            Polynomial pol2 = new Polynomial(coefficient2, power2);

            Console.WriteLine(pol1.coefficients[1]);

            pol1.coefficients[1] = 4;
            Console.WriteLine(pol1.coefficients[1]);

            Console.WriteLine($"\npolynomial1 = {pol1}");
            Console.WriteLine($"\npolynomial2 = {pol2}");

            Polynomial pol3 = pol1 - pol2;

            Console.WriteLine($"\nResult = {pol3}");
        }

        static void Main(string[] args)
        {
            //Matrix();
            //Polynomial();

            Console.ReadKey();
        }
    }
}
