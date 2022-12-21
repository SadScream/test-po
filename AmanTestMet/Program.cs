using System;
using System.IO;

namespace AmanTestMet
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
            //if (name.IndexOfAny(Path.GetInvalidFileNameChars()) != -1) {
            //    throw new Exception("Имя файла содержит не разрешенные символы");
            //} else
            //{
            //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), name + ".txt");

            //    using (StreamWriter outputFile = new StreamWriter(filePath)) {
            //        foreach (double line in values)
            //        {
            //            outputFile.WriteLine(line);
            //        }
            //    }
            //} 

            try {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(name + ".txt");
                foreach (double line in values)
                {
                    sw.WriteLine(line);
                }
                sw.Close();
            }
            catch (Exception e) {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        static void Main(string[] args) {
            //Console.WriteLine(IlyaGetF(8, 1, 3));
            //double[] arr = GetArray(5, 1, 5, 8, 21);
            //foreach (double num in arr){
            //    Console.WriteLine(num);
            //}
            double[] testArr = new double[] { 1, 2, 3, 4, 5 };
            WriteToFile("D:\\123/test", testArr);
        }
    }
}
