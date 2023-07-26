using System;

namespace Rational
{
    class Program
    {        
        static void Main(string[] args)
        {
            //--------- EXAMPLES OF USING: 40/35 and -35/6 ---------//
            Rational r1 = new Rational(40,35);
            int den = r1.Denominator;
            int num = r1.Numerator;
            string fraction = r1.ToString();
            Console.WriteLine($"40/35\nDenominator: {den}\nNumerator: {num}\nFraction: {fraction}");
            Rational r2 = new Rational(-36, 6);
            den = r2.Denominator;
            num = r2.Numerator;
            fraction = r2.ToString();
            Console.WriteLine($"-35/6\nDenominator: {den}\nNumerator: {num}\nFraction: {fraction}");
        }
    }
    struct Rational
    {
        public int Numerator { get; }
        public int Denominator { get; }
        public Rational(int den, int num)
        {
            if (num == 0)
            {
                DivideByZeroException ex = new DivideByZeroException();
                throw ex;
            }
            Denominator = den;
            Numerator = num;
            int[] array = Fraction(Denominator, Numerator);
            Denominator = array[0];
            Numerator = array[1];
        }
        public override string ToString()
        {
            string fraccion = Denominator.ToString();
            fraccion = Numerator != 1 ? fraccion + "/" + Numerator.ToString() : fraccion;
            return fraccion;
        }
        private int[] Fraction(int d, int n)
        {
            int den = Math.Abs(d);
            int num = Math.Abs(n);
            int min = den < num ? den : num;
            int number = 1;
            for (int i = 1; i <= min; i++)
            {
                if (den % i == 0 && num % i == 0 && i != 1)
                {
                    number = i;
                }
            }
            den = den / number;
            den = d < 0 ? den * (-1) : den;
            num = num / number;
            num = n < 0 ? num * (-1) : num;
            int[] array = new int[2] { den, num };
            return array;
        }
    }
}