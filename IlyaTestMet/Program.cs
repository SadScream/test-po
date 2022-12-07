using System;

namespace FuncLab
{
    public class Program
    {
        public static double AmanGetF(double x, double b, double c)
        {
            if (b == 12 || b == 1) 
                throw new DivideByZeroException("b != 12 or b != 1");
            if (c < 20) 
                throw new Exception("c < 20");

            return (
                Math.Sqrt(c - 20) / (b * b - 13 * b + 12)
                ) * Math.Pow(Math.Sin(x), 2);
        }

		static void Main(string[] args)
		{
            Calculations calc = new Calculations();
            calc.Run();
        }
	}
}
