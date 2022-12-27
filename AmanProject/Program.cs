using IlyaProject;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace AmanProject
{
    public class Program {

        public static double IlyaGetF(double b, double c, double x) {
            if (b * b == 100) throw new DivideByZeroException("B != 10");
            if (c > -9 && c < -5) throw new Exception("C > -5 and < -9");
            if (c == -9 || c == -5) throw new DivideByZeroException("C != -9 or C != -5");
            return 100 / (b * b - 100) * Math.Sin(4 * x / Math.Sqrt(c * c + 14 * c + 45));
        }
        public static double GetF(double x, double b, double c) {
            if (b == 12 || b == 1) throw new DivideByZeroException("B != 12 or b != 1");
            if (c < 20) throw new Exception("C < 20");
            return (Math.Sqrt(c - 20) / (Math.Pow(b, 2) - 13 * b + 12)) * Math.Pow(Math.Sin(x), 2);
        }

        public static double[] GetArray(int n, double x1, double x2, double b, double c) {
            if (x2 < x1) throw new Exception("x2 должен быть больше или равен x1");
            if (n <= 0) throw new Exception("n должен быть больше 0");

            double step;

            if (n == 1) {
                double[] ans = new double[] { GetF(x1, b, c) };
                return ans;
            }
            else {
                step = Math.Abs(x1 - x2) / (n - 1);
            }

            double[] answer = new double [n];

            for (int i = 0; i < n; i++) {
                answer[i] = GetF(x1, b, c);
                x1 += step;
            }

            return answer;
        }

        public static void WriteToFile(string name, double[] values) {
            // Exceptions:
            //   T:System.UnauthorizedAccessException:
            //     Access is denied.
            //
            //   T:System.ArgumentException:
            //     path is an empty string (""). -or- path contains the name of a system device
            //     (com1, com2, and so on).
            //
            //   T:System.ArgumentNullException:
            //     path is null.
            //
            //   T:System.IO.DirectoryNotFoundException:
            //     The specified path is invalid (for example, it is on an unmapped drive).
            //
            //   T:System.IO.PathTooLongException:
            //     The specified path, file name, or both exceed the system-defined maximum length.
            //
            //   T:System.IO.IOException:
            //     path includes an incorrect or invalid syntax for file name, directory name, or
            //     volume label syntax.
            StreamWriter sw = new StreamWriter(name);

            foreach (double line in values)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }

        public static string AskForFileName()
        {
            StreamWriter sw = null;

            while (true)
            {
                string filepath;

                try
                {
                    Console.WriteLine($"Введите путь к файлу: ");
                    filepath = Console.ReadLine();

                    sw = new StreamWriter(filepath);
                }
                catch (Exception e)
                {
                    if (sw != null)
                        sw.Close();

                    Console.WriteLine("Неправильный путь к файлу: " + e.Message);
                    continue;
                }

                sw.Close();
                return filepath;
            }
        }

        static void Main(string[] args) {
            //Console.WriteLine(IlyaGetF(8, 1, 3));
            //double[] arr = GetArray(5, 1, 5, 8, 21);
            //foreach (double num in arr){
            //    Console.WriteLine(num);
            //}
            //double[] testArr = new double[] { 1, 2, 3, 4, 5 };
            //WriteToFile("D:\\123/test", testArr);

            InputModule inputHandler = new InputModule();

            int N = inputHandler.AskForN();
            double B = inputHandler.AskForB();
            double C = inputHandler.AskForC();

            (double x1, double x2) = inputHandler.AskForXRange(N);
            var fValues = Program.GetArray(N, x1, x2, B, C);
            var filePath = Program.AskForFileName();

            Program.WriteToFile(filePath, fValues);
        }
    }
}
