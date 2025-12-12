using NUnit.Framework;
using System;

namespace ModuleTestingLab
{
    public class ProgramFunctions
    {
        // Приложение А: Сортировка пузырьком
        public int[] BubbleSort(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }

        // Приложение Б: Проверка палиндрома
        public bool CheckPalindrom(string str)
        {
            if (str == null) return false;
            int left = 0;
            int right = str.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(str[left])) left++;
                while (left < right && !char.IsLetterOrDigit(str[right])) right--;
                if (char.ToLowerInvariant(str[left]) != char.ToLowerInvariant(str[right])) return false;
                left++;
                right--;
            }
            return true;
        }

        // Приложение В: Факториал
        public int Factorial(int n)
        {
            var factorial = 1;
            for (int i = 1; i <= n; i++)
                factorial *= i;
            return factorial;
        }

        // Приложение Г: Число Фибоначчи
        public int Fibonachi(int n) => n <= 1 ? n : Fibonachi(n - 1) + Fibonachi(n - 2);

        // Приложение Д: Поиск подстроки
        public bool findstr(string str, string find)
        {
            return str.Contains(find);
        }

        // Приложение Е: Проверка простого числа
        public bool IsSimple(int i, int c = 2)
        {
            if (Math.Sqrt(i) + 1 < c) return true;
            else if (i % c == 0) return false;
            else return IsSimple(i, ++c);
        }

        // Приложение Ж/В: Реверс целого числа
        public int ReverseInt32(int x)
        {
            int result = 0;
            while (x != 0)
            {
                int digit = x % 10;
                x /= 10;
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7)) return 0;
                if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8)) return 0;
                result = result * 10 + digit;
            }
            return result;
        }

        // Приложение З: Перевод в римскую систему
        public string IntToRoman(int num)
        {
            if (num <= 0 || num > 3999) return string.Empty;
            int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] romans = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
            var result = new System.Text.StringBuilder();
            for (int i = 0; i < values.Length && num > 0; i++)
            {
                while (num >= values[i])
                {
                    num -= values[i];
                    result.Append(romans[i]);
                }
            }
            return result.ToString();
        }
    }

    [TestFixture]
    public class ProgramFunctionsTests
    {
        private ProgramFunctions _program;

        [SetUp]
        public void Setup()
        {
            _program = new ProgramFunctions();
        }

        // Тесты для сортировки пузырьком
        [Test]
        [TestCase(new int[] { 3, 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 5, -1, 0, 3 }, new int[] { -1, 0, 3, 5 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        [TestCase(new int[] { 2, 2, 1 }, new int[] { 1, 2, 2 })]
        public void BubbleSort_VariousInputs_ReturnsSortedArray(int[] input, int[] expected)
        {
            int[] result = _program.BubbleSort(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тесты для проверки палиндрома
        [Test]
        [TestCase("А роза упала на лапу Азора", true)]
        [TestCase("racecar", true)]
        [TestCase("hello", false)]
        [TestCase("", true)]
        public void CheckPalindrom_VariousInputs_ReturnsCorrectResult(string input, bool expected)
        {
            bool result = _program.CheckPalindrom(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тесты для факториала
        [Test]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(5, 120)]
        [TestCase(7, 5040)]
        public void Factorial_VariousInputs_ReturnsCorrectResult(int input, int expected)
        {
            int result = _program.Factorial(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тесты для чисел Фибоначчи
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 1)]
        [TestCase(6, 8)]
        [TestCase(10, 55)]
        public void Fibonachi_VariousInputs_ReturnsCorrectResult(int input, int expected)
        {
            int result = _program.Fibonachi(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тесты для поиска подстроки
        [Test]
        [TestCase("hello world", "world", true)]
        [TestCase("hello world", "test", false)]
        [TestCase("", "", true)]
        [TestCase("abc", "abcd", false)]
        public void Findstr_VariousInputs_ReturnsCorrectResult(string str, string find, bool expected)
        {
            bool result = _program.findstr(str, find);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тесты для проверки простого числа
        [Test]
        [TestCase(3, true)]
        [TestCase(4, false)]
        [TestCase(17, true)]
        [TestCase(25, false)]
        [TestCase(1, true)] // Внимание: в данной реализации 1 считается простым
        public void IsSimple_VariousInputs_ReturnsCorrectResult(int input, bool expected)
        {
            bool result = _program.IsSimple(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тесты для реверса целого числа
        [Test]
        [TestCase(123, 321)]
        [TestCase(-456, -654)]
        [TestCase(120, 21)]
        [TestCase(0, 0)]
        [TestCase(1534236469, 0)] // Переполнение
        public void ReverseInt32_VariousInputs_ReturnsCorrectResult(int input, int expected)
        {
            int result = _program.ReverseInt32(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        // Тесты для перевода в римскую систему
        [Test]
        [TestCase(1, "I")]
        [TestCase(4, "IV")]
        [TestCase(9, "IX")]
        [TestCase(58, "LVIII")]
        [TestCase(1994, "MCMXCIV")]
        [TestCase(0, "")]
        [TestCase(4000, "")]
        public void IntToRoman_VariousInputs_ReturnsCorrectResult(int input, string expected)
        {
            string result = _program.IntToRoman(input);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}