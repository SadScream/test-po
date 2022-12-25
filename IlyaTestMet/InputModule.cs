using System;
using System.Text.RegularExpressions;

namespace IlyaTestMet
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

        /// <summary>
        /// В бесконечном цикле просит ввести значение промежутка X1:X2 до тех пор,
        /// пока не будут введены корректные значения X1 и X2.
		/// 
        /// Если передаваемый параметр `N` > 1, то выводит сначала:
        ///		`Введите значение X1  (включительно): `
		///	Затем (если X1 корретный):
		///		`Введите значение X2 (включительно): `
		///		
		///	Если `N` = 1:
		///		`Введите значение X: `
		///	При это введенное значение X приравнивается к `X1` и `X2`.
		///	
		/// Если какое-то из введенных значений не является действительным числом,
		/// в консоль с новой строки печатается ошибка.
        /// </summary>
        /// <returns>(double X1, double X2)</returns>
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
