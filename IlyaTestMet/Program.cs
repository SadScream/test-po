using System;

namespace IlyaTestMet
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
            Program p = new Program();
            p.Run();
        }

        public void Run()
        {
            Calculations calc = new Calculations();
            InputModule inputHandler = new InputModule();

            int N = inputHandler.AskForN();
            double B = inputHandler.AskForB();
            double C = inputHandler.AskForC();

            (double x1, double x2) = inputHandler.AskForXRange(N);
            var fValues = calc.GetArray(N, x1, x2, B, C);
            var filePath = FileModule.AskForFileName();

            FileModule.WriteToFile(filePath, fValues);
        }
    }
}
