using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    public sealed class Matrix
    {
        public readonly double[,] numbers;
        private readonly int columns;
        private readonly int rows;

        //constructor for the left or right matrix
        public Matrix(double[,] numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException(nameof(numbers));

            if (numbers.Length == 0)
                throw new ArgumentException($"{nameof(numbers)} is empty.");

            columns = numbers.GetLength(0);
            rows = numbers.GetLength(1);
            this.numbers = numbers;
        }

        //matrix indexer
        public double this[int i, int j]
        {
            get
            {
                if (i < columns && j < rows)
                    return numbers[i, j];
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (i < columns && j < rows)
                    numbers[i, j] = value;
                else
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static bool isMatrixesValid(Matrix left, Matrix right)
        {
            return (left == null || right == null);
        }

        //operator overload "+"
        public static Matrix operator +(Matrix left, Matrix right)
        {
            if (isMatrixesValid(left, right))
                throw new ArgumentNullException();

            double[,] numbers = new double[left.columns, left.rows];

            //matrices must be equal
            if (left.columns == right.columns && left.rows == right.rows)
            {
                for (int i = 0; i < left.columns; i++)
                {
                    for (int j = 0; j < left.rows; j++)
                    {
                        numbers[i, j] = left[i, j] + right[i, j];
                    }
                }
                return new Matrix(numbers);
            }
            else
            {
                numbers = null;
                throw new ArgumentException("Matrices are not equal.");
            }
        }

        //operator overload "-"
        public static Matrix operator -(Matrix left, Matrix right)
        {
            if (isMatrixesValid(left, right))
                throw new ArgumentNullException();

            double[,] numbers = new double[left.columns, left.rows];

            //matrices must be equal
            if (left.columns == right.columns && left.rows == right.rows)
            {
                for (int i = 0; i < left.columns; i++)
                {
                    for (int j = 0; j < left.rows; j++)
                    {
                        numbers[i, j] = left[i, j] - right[i, j];
                    }
                }
                return new Matrix(numbers);
            }
            else
            {
                numbers = null;
                throw new ArgumentException("Matrices are not equal.");
            }
        }

        //operator overload "*"
        public static Matrix operator *(Matrix left, Matrix right)
        {
            if (isMatrixesValid(left, right))
                throw new ArgumentNullException();

            double[,] numbers = new double[left.columns, left.rows];

            //the rows of the left matrix must be equal to the columns of the right matrix
            if (left.rows == right.columns)
            {
                for (int i = 0; i < left.columns; i++)
                {
                    for (int j = 0; j < right.rows; j++)
                    {
                        numbers[i, j] = 0;
                        for (int k = 0; k < left.rows; k++)
                        {
                            numbers[i, j] += left[i, k] * right[k, j];
                        }
                    }
                }
                return new Matrix(numbers); 
            }
            else
            {
                numbers = null;
                throw new ArgumentException("rows of the Left matrix  != columns of the right matrix.");
            }
        }
    }
}
