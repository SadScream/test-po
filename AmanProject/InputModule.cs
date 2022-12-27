using System;
using System.Text.RegularExpressions;

namespace IlyaProject
{
    public class InputModule
    {
        public int AskForN()
        {
            // колбэк отбрасывает у N заднюю часть, чтобы затем преобразовать вернувшееся значение из double в int
            return (int)AskForVariable("N", N_ValueChecker, (double n) => Math.Floor(n));
        }

        public double AskForB()
        {
            return AskForVariable("B", B_ValueChecker, null);
        }

        public double AskForC()
        {
            return AskForVariable("C", C_ValueChecker, null);
        }

        public (double, double) AskForXRange(int N)
        {
            double x1 = AskForVariable($"X{(N == 1 ? "" : "1  (включительно)")}", null, null);
            double x2 = 0.0;

            if (N > 1)
            {
                x2 = AskForVariable("X2 (включительно)", null, null);
            }
            else if (N == 1)
                x2 = x1;

            return (x1, x2);
        }

        private double AskForVariable(string variableName, Action<double>? checker, Func<double, double>? modificator)
        {
            while (true)
            {
                double var;

                try
                {
                    Console.WriteLine($"Введите значение {variableName}: ");
                    string var_FromInput = Console.ReadLine();
                    var = CheckNumberValue(var_FromInput);

                    if (checker != null)
                        checker(var);
                    if (modificator != null)
                        var = modificator(var);
                    return var;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void N_ValueChecker(double N)
        {
            if (N < 1)
                throw new Exception("N не должен быть отрицательным, либо равным нулю");
        }

        private void B_ValueChecker(double B)
        {
            if (B == 12 || B == 1)
                throw new DivideByZeroException("B != 12 or b != 1");
        }

        private void C_ValueChecker(double C)
        {
            if (C < 20)
                throw new Exception("C < 20");
        }

		private double CheckNumberValue(string number)
        {
            if (number.Length == 0)
            {
                throw new Exception("Введена пустая строка");
            }
            else if (!Regex.IsMatch(number, "\\-?\\d+(\\.\\d+)?"))
            {
                throw new Exception("Введено не число");
            }

            return Double.Parse(number);
        }
    }
}
