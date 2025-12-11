using System;

namespace MathFunctions
{
    public class Mathematics
    {
        public static double Sqrt(double x)
        {
            if (x < 0) return double.NaN;
            if (x == 0) return 0;
            if (x == 1) return 1;

            double guess = x / 2.0;
            double epsilon = 1e-10;

            for (int i = 0; i < 100; i++)
            {
                double newGuess = 0.5 * (guess + x / guess);

                if (Abs(newGuess - guess) < epsilon)
                    return newGuess;

                guess = newGuess;
            }

            return guess;
        }

        public static double Power(double baseValue, int exponent)
        {
            if (exponent == 0) return 1.0;
            if (exponent == 1) return baseValue;

            double result = 1.0;
            int absExponent = Abs(exponent);

            for (int i = 0; i < absExponent; i++)
            {
                result *= baseValue;
            }

            return exponent > 0 ? result : 1.0 / result;
        }

        public static int Abs(int value)
        {
            return value < 0 ? -value : value;
        }

        public static double Abs(double value)
        {
            return value < 0 ? -value : value;
        }

        public static long Factorial(int n)
        {
            if (n < 0) return -1;
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static double Sin(double x, int terms = 15)
        {
            // Приводим x к диапазону [-π, π] для лучшей точности
            x = x % (2 * Math.PI);
            double result = 0;
            for (int n = 0; n < terms; n++)
            {
                double term = Power(-1, n) * Power(x, 2 * n + 1) / Factorial(2 * n + 1);
                result += term;
            }
            return result;
        }

        public static double Cos(double x, int terms = 15)
        {
            // Приводим x к диапазону [-π, π]
            x = x % (2 * Math.PI);
            double result = 0;
            for (int n = 0; n < terms; n++)
            {
                double term = Power(-1, n) * Power(x, 2 * n) / Factorial(2 * n);
                result += term;
            }
            return result;
        }

        public static double Ln(double x, int terms = 30)
        {
            if (x <= 0) return double.NaN;
            if (x > 2)
                return Ln(x / 2, terms) + Ln(2, terms);

            double result = 0;
            double z = (x - 1) / (x + 1);

            for (int n = 0; n < terms; n++)
            {
                double term = (2.0 / (2 * n + 1)) * Power(z, 2 * n + 1);
                result += term;
            }
            return result;
        }

        public static double Exp(double x, int terms = 20)
        {
            double result = 0;
            for (int n = 0; n < terms; n++)
            {
                double term = Power(x, n) / Factorial(n);
                result += term;
            }
            return result;
        }

        public static double CustomFunction(double x)
        {
            if (x < 0)
            {
                double xSquared = x * x;
                double sinX2 = Sin(xSquared);
                double cos2x = Cos(2 * x);

                double absXPlus1 = Abs(x + 1);
                double lnTerm = Ln(absXPlus1);

                if (lnTerm == 0) return double.NaN;
                return sinX2 * cos2x + 1.0 / lnTerm;
            }
            else
            {
                double expTerm = Exp(-2 * x);
                double xSquaredPlus1 = x * x + 1;
                double lnTerm = Ln(xSquaredPlus1);
                double sqrtX = Sqrt(x);

                return expTerm * lnTerm - sqrtX;
            }
        }

        // Для сравнения с библиотечными функциями
        public static double ReferenceFunction(double x)
        {
            if (x < 0)
            {
                return Math.Sin(x * x) * Math.Cos(2 * x) + 1 / Math.Log(Math.Abs(x + 1));
            }
            else
            {
                return Math.Exp(-2 * x) * Math.Log(x * x + 1) - Math.Sqrt(x);
            }
        }
    }

    // Класс алгоритмов для второй части лабораторной
    public class Algorithms
    {
        // Приложение А: Сортировка пузырьком
        public static int[] BubbleSort(int[] array)
        {
            if (array == null) return new int[0];

            int[] result = (int[])array.Clone();
            int n = result.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (result[j] > result[j + 1])
                    {
                        int temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }
            return result;
        }

        // Приложение Б: Проверка палиндрома
        public static bool IsPalindrome(string str)
        {
            if (str == null) return false;

            int left = 0;
            int right = str.Length - 1;

            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(str[left])) left++;
                while (left < right && !char.IsLetterOrDigit(str[right])) right--;

                if (char.ToLowerInvariant(str[left]) != char.ToLowerInvariant(str[right]))
                    return false;

                left++;
                right--;
            }
            return true;
        }

        // Приложение В: Факториал (итеративный)
        public static long FactorialIterative(int n)
        {
            if (n < 0) return -1;
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        // Приложение Г: Число Фибоначчи
        public static int Fibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 1) return 1;

            int a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                int temp = a + b;
                a = b;
                b = temp;
            }
            return b;
        }

        // Приложение Д: Поиск подстроки
        public static bool ContainsSubstring(string text, string substring)
        {
            if (string.IsNullOrEmpty(substring)) return true;
            if (string.IsNullOrEmpty(text)) return false;

            return text.Contains(substring);
        }

        // Приложение Е: Проверка простого числа
        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int limit = (int)Math.Sqrt(number);
            for (int i = 3; i <= limit; i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        // Приложение Ж: Реверс целого числа
        public static int ReverseInteger(int x)
        {
            int result = 0;

            while (x != 0)
            {
                int digit = x % 10;
                x /= 10;

                // Проверка переполнения
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7))
                    return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8))
                    return 0;

                result = result * 10 + digit;
            }

            return result;
        }

        // Приложение З: Перевод в римскую систему
        public static string ToRoman(int num)
        {
            if (num <= 0 || num > 3999) return string.Empty;

            var values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            var symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            var result = new System.Text.StringBuilder();

            for (int i = 0; i < values.Length && num > 0; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    result.Append(symbols[i]);
                }
            }

            return result.ToString();
        }
    }
}