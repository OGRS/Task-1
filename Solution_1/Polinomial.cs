using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_1
{
    public sealed class Polynomial
    {
        public List<double> coefficients { get; set; }
        public List<uint> powers { get; set; }

        public Polynomial(List<double> coefficients, List<uint> powers)
        {
            if (coefficients == null || powers == null)
                throw new ArgumentNullException();

            if (powers.Count > coefficients.Count)
                throw new ArgumentException("powers > coefficients");

            if (coefficients.Count == 0)
                throw new Exception($"{nameof(coefficients)} is empty.");

            //add zero in power for free member polinomial
            for (int i = 0; i < coefficients.Count; i++)
            {
                if (i >= powers.Count)
                    powers.Add(0);
            }

            //check for zero in coefficient
            for (int i = 0; i < coefficients.Count; i++)
            {
                //coefficient
                if (coefficients[i] == 0)
                {
                    if (i < powers.Count)
                        powers.RemoveAt(i);
                    coefficients.RemoveAt(i);
                }
            }

            double tmp;

            // sort the power and the corresponding coefficients
            for (int i = 0; i < powers.Count; i++)
            {
                for (int j = i + 1; j < powers.Count; j++)
                {
                    tmp = powers[i];

                    if (tmp < powers[j])
                    {
                        tmp = powers[j];
                        powers[j] = powers[i];
                        powers[i] = (uint)tmp;

                        tmp = coefficients[j];
                        coefficients[j] = coefficients[i];
                        coefficients[i] = tmp;
                    }
                }
            }

            this.powers = powers;
            this.coefficients = coefficients;
        }

        //Polynomial final form
        public override string ToString()
        {
            string result = "";

            for (int i = 0; i < coefficients.Count; i++)
            {
                if (i < powers.Count)
                {
                    if (powers[i] == 1)
                    {
                        if (coefficients[i] == 1)
                            result += "x";
                        else
                            result += coefficients[i].ToString() + "x";
                    }
                    else if (powers[i] == 0)
                    {
                        result += coefficients[i].ToString();
                    }
                    else
                    {
                        if (coefficients[i] == 1)
                            result += "x^" + powers[i].ToString();
                        else
                            result += coefficients[i].ToString() + "x^" + powers[i].ToString();
                    }

                    if (coefficients.Count != 1 && i + 1 != powers.Count)
                    {
                        if (coefficients[i + 1] > 0)
                            result += "+";
                    }
                }
            }

            return result;
        }

        private static bool isPolynomialValid(Polynomial left, Polynomial right)
        {
            return (left == null || right == null);
        }

        private static void PlusOrMinus(List<double> coefficients, List<uint> powers, char operation)
        {
            uint tmp;

            //check the identical monomials and summarize them
            for (int i = 0; i < coefficients.Count;)
            {
                if (i + 1 < powers.Count)
                {
                    for (int j = i + 1; j < coefficients.Count;)
                    {
                        tmp = powers[i];

                        if (tmp == powers[j])
                        {
                            powers.RemoveAt(j);

                            if (operation == '+')
                            {
                                coefficients[i] += coefficients[j];
                                coefficients.RemoveAt(j);
                            }
                            else if (operation == '-')
                            {
                                coefficients[i] -= coefficients[j];
                                coefficients.RemoveAt(j);
                            }
                        }
                        else
                        {
                            i++; j++;
                        }
                    }
                }
                else i++;
            }
        }

        public static Polynomial operator +(Polynomial left, Polynomial right)
        {
            if (isPolynomialValid(left, right))
                throw new ArgumentNullException();

            List<double> coefficients = new List<double>();
            List<uint> powers = new List<uint>();

            coefficients.AddRange(left.coefficients);
            coefficients.AddRange(right.coefficients);

            powers.AddRange(left.powers);
            powers.AddRange(right.powers);

            new Polynomial(coefficients, powers);

            PlusOrMinus(coefficients, powers, '+');

            return new Polynomial(coefficients, powers);
        }

        public static Polynomial operator -(Polynomial left, Polynomial right)
        {
            if (isPolynomialValid(left, right))
                throw new ArgumentNullException();

            List<double> coefficients = new List<double>();
            List<uint> powers = new List<uint>();

            coefficients.AddRange(left.coefficients);
            coefficients.AddRange(right.coefficients);

            powers.AddRange(left.powers);
            powers.AddRange(right.powers);

            new Polynomial(coefficients, powers);

            PlusOrMinus(coefficients, powers, '-');

            return new Polynomial(coefficients, powers);
        }

        public static Polynomial operator *(Polynomial left, Polynomial right)
        {
            if (isPolynomialValid(left, right))
                throw new ArgumentNullException();

            List<double> coefficients = new List<double>();
            List<uint> powers = new List<uint>();

            for (int i = 0; i < left.coefficients.Count; i++)
            {
                for (int j = 0; j < right.coefficients.Count; j++)
                {
                    coefficients.Add(left.coefficients[i] * right.coefficients[j]);
                    powers.Add(left.powers[i] + right.powers[j]);
                }
            }

            new Polynomial(coefficients, powers);

            PlusOrMinus(coefficients, powers, '+');

            return new Polynomial(coefficients, powers);
        }
    }
}

