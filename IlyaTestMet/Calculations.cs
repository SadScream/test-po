using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace IlyaTestMet
{
    public class Calculations
    {
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
    }
}
