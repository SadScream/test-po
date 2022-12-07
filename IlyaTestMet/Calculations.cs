using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace IlyaTestMet
{
    public class Calculations
    {
        public void Run()
        {
			int N = AskForN();
			double B = AskForB();
            double C = AskForC();

			var fValues = GetArray(N, B, C);
			var filePath = AskForFile();

            File.WriteAllLines(filePath, fValues
				.Select(x => Convert.ToString(x)));
		}

        public double Function(double b, double c, double x)
        {
            if (b * b == 100)
                throw new DivideByZeroException("B не должно быть равно 10 или -10");
            if (c > -9 && c < -5)
                throw new Exception("C должно быть больше чем -5 и меньше чем-9");
            if (c == -9 || c == -5)
                throw new DivideByZeroException("C не должно быть равно -9 или -5");

            return 100 / (b * b - 100) * 
                Math.Sin(4 * x / Math.Sqrt(c * c + 14 * c + 45));
        }

		public List<double> GetArray(int N, double B, double C)
		{
			double[] arr = AskForXRange(N);
			var fValues = CalculateFunction(arr, B, C);

			return fValues;
		}

		public List<double> CalculateFunction(double[] arr, double B, double C)
        {
			List<double> fValues = new List<double>();

			foreach (double x in arr)
			{
				fValues.Add(Function(B, C, x));
			}

			return fValues;
		}

		public int AskForN()
        {
			return (int)AskForVariable("N", N_ValueChecker, (x) => Convert.ToInt32(Math.Floor(x)));
		}

		public double AskForB()
        {
			return AskForVariable("B", B_ValueChecker, null);
		}

		public double AskForC()
		{
			return AskForVariable("C", C_ValueChecker, null);
		}

		private double[] AskForXRange(int N)
        {
            while (true)
            {
                double x1, x2;

				try
                {
					Console.WriteLine("Введите X1 (включительно): ");
					string x1_FromInput = Console.ReadLine();
					x1 = CheckNumberValue(x1_FromInput);

					Console.WriteLine("Введите X2 (включительно): ");
					string x2_FromInput = Console.ReadLine();
					x2 = CheckNumberValue(x2_FromInput);
				}
                catch (Exception e)
                {
					Console.WriteLine(e.Message);
					continue;
				}

				if (x2 <= x1 && N != 1)
                {
                    Console.WriteLine($"X2({x2}) должен быть больше X1({x1}), повторите ввод");
                    continue;
                }

				if (N > 1 && x2 == x1)
                {
					Console.WriteLine($"Когда N > 1, x2 должен быть больше x1");
					continue;
				}

				if (N == 1 && x2 != x1)
                {
					Console.WriteLine($"Когда N = 1, x2 должен быть равен x1");
					continue;
				}

				double[] XArr = new double[N];
				double step = (x2 - x1) / N;

				if (N == 1)
					return new double[] { x1 };

				for (int i = 0; i < N; i++)
				{
					XArr[i] = x1 + step * (i + 1);
				}

				return XArr;
			}
        }

        private double AskForVariable(string variableName, Action<double>? checker, Func<double, Int32>? modificator)
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

		private string AskForFile()
        {
			while (true)
			{
				string filePath;

				try
				{
					Console.WriteLine($"Введите название файла: ");
					string filename = Console.ReadLine();

					FilenameChecker(filename);
					filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					continue;
				}

				return filePath;
			}
		}

		private void FilenameChecker(string filename)
		{
			var isValid = !string.IsNullOrEmpty(filename) &&
			  filename.IndexOfAny(Path.GetInvalidFileNameChars()) < 0;

			if (!isValid)
				throw new Exception("Неверное имя файла");
		}

		private void N_ValueChecker(double N)
		{
			if (N < 1)
				throw new Exception("N не должен быть отрицательным");
		}

		private void B_ValueChecker(double B)
        {
            if (B * B == 100)
				throw new DivideByZeroException("B не должно быть равно 10 или -10");
		}

		private void C_ValueChecker(double C)
		{
			if (C > -9 && C < -5)
				throw new Exception("C должно быть больше чем -5 и меньше чем-9");
			if (C == -9 || C == -5)
				throw new DivideByZeroException("C не должно быть равно -9 или -5");
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
