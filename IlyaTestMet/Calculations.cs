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

			(double x1, double x2) = AskForXRange(N);
            var fValues = GetArray(N, x1, x2, B, C);
			var filePath = FileModule.AskForFileName();

            FileModule.WriteToFile(filePath, fValues);
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

		public double[] GetArray(int N, double x1, double x2, double B, double C)
        {
            if (x2 <= x1 && N != 1)
            {
				throw new Exception($"X2({x2}) должен быть больше X1({x1})");
            }

            if (N == 0)
            {
                throw new IndexOutOfRangeException($"n должен быть больше, либо равен единице");
            }

            if (N == 1)
                return new double[] { Function(B, C, x1) };

            List<double> fValues = new List<double>();
            double step = (x2 - x1) / (N - 1);

            for (int i = 0; i < N; i++)
            {
                fValues.Add(Function(B, C, x1 + step * i));
            }

			return fValues.ToArray();
		}

		public int AskForN()
        {
			return (int)AskForVariable("N", N_ValueChecker, (x) => Math.Floor(x));
		}

		public double AskForB()
        {
			return AskForVariable("B", B_ValueChecker, null);
		}

		public double AskForC()
		{
			return AskForVariable("C", C_ValueChecker, null);
		}

        /// <summary>
        /// В бесконечном цикле просит ввести значение промежутка X1:X2 до тех пор,
        /// пока не будут введены корректные значения X1 и X2.
		/// 
        /// Если передаваемый параметр `N` > 1, то выводит сначала:
        ///		`Введите X1  (включительно): `
		///	Затем (если X1 корретный):
		///		`Введите X2 (включительно): `
		///		
		///	Если `N` = 1:
		///		`Введите X: `
		///	При это введенное значение X приравнивается к `X1` и `X2`.
		///	
		/// Если какое-то из введенных значений не является действительным числом,
		/// в консоль с новой строки печатается ошибка.
        /// </summary>
        /// <returns>(double X1, double X2)</returns>
        private (double, double) AskForXRange(int N)
        {
            while (true)
            {
                double x1, x2 = 0.0;

				try
                {
					Console.WriteLine($"Введите X{(N == 1 ? "" : "1  (включительно)")}: ");
					string x1_FromInput = Console.ReadLine();
					x1 = CheckNumberValue(x1_FromInput);

					if (N > 1)
					{
						Console.WriteLine("Введите X2 (включительно): ");
						string x2_FromInput = Console.ReadLine();
						x2 = CheckNumberValue(x2_FromInput);
					}
					else if (N == 1)
						x2 = x1;
				}
                catch (Exception e)
                {
					Console.WriteLine(e.Message);
					continue;
				}

				return (x1, x2);
			}
        }

        /// <summary>
        /// В бесконечном цикле просит ввести значение переменной с именем `variableName` до тех пор,
		/// пока не будет введено корретное значение (число)
		/// 
		/// Сначала выводит с новой строки просьбу ввести значение:
		///		`Введите значение <variableName>: `
		/// Затем присваивает введенное значение переменной `var` и проверяет, является ли `var` числом.
		/// 
		/// Если была передана функция `checker`, то происходит ее вызов и при этом в нее передается `var`
		/// 
		/// Если была передана функция `modificator`, то происходит ее вызов и при этом в нее передается `var`
		/// Возвращенное функцией `modificator` значение присваивается переменной `var`
        /// 
        /// Если `CheckNumberValue` или `checker` генерируют Exception, то его текст выводится в консоль
        /// </summary>
        /// <param name="variableName">Имя переменной, которую просим ввести</param>
        /// <param name="checker">Callback функция, в которую будет передано введенное значение</param>
        /// <param name="modificator">Callback функция, в которую будет переданно введенное значение для модификации</param>
        /// <returns>Значение переменной `var`</returns>
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

        /// <summary>
        /// Проверяет строку по 2 критериям:
        ///     1. Не пуста ли она
        ///     2. Является ли содержащееся в ней значение числом.
        /// Допускаются положительные/отрицательные, дробные/целые числа.
        /// 
        /// Если строка удовлетворяет критерям, то возвращается ее значение сконвертированное в double.
        /// Иначе вызывается ошибка
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        /// <exception cref="Exception">Введена пустая строка</exception>
        /// <exception cref="Exception">Введено не число</exception>
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
