using NUnit.Framework;

namespace MathFunctions.Tests
{
    [TestFixture]
    public class MathematicsTests
    {
        private const double Tolerance = 0.0001;

        [TestCase(4, 2.0)]
        [TestCase(9, 3.0)]
        [TestCase(1, 1.0)]
        [TestCase(0, 0.0)]
        [TestCase(2, 1.41421356)]
        public void Sqrt_ValidInput_ReturnsCorrectValue(double input, double expected)
        {
            var result = Mathematics.Sqrt(input);
            Assert.That(result, Is.EqualTo(expected).Within(Tolerance));
        }

        [Test]
        public void Sqrt_NegativeInput_ReturnsNaN()
        {
            var result = Mathematics.Sqrt(-1);
            Assert.That(double.IsNaN(result), Is.True);
        }

        [TestCase(2, 3, 8.0)]
        [TestCase(3, 2, 9.0)]
        [TestCase(5, 0, 1.0)]
        [TestCase(2, -2, 0.25)]
        public void Power_ValidInput_ReturnsCorrectValue(double baseValue, int exponent, double expected)
        {
            var result = Mathematics.Power(baseValue, exponent);
            Assert.That(result, Is.EqualTo(expected).Within(Tolerance));
        }

        [TestCase(0, 0.0)]
        [TestCase(Math.PI / 2, 1.0)]
        [TestCase(Math.PI, 0.0)]
        [TestCase(Math.PI / 6, 0.5)]
        public void Sin_ValidInput_ReturnsCorrectValue(double input, double expected)
        {
            var result = Mathematics.Sin(input);
            Assert.That(result, Is.EqualTo(expected).Within(Tolerance));
        }

        [TestCase(0, 1.0)]
        [TestCase(Math.PI, -1.0)]
        [TestCase(Math.PI / 2, 0.0)]
        [TestCase(Math.PI / 3, 0.5)]
        public void Cos_ValidInput_ReturnsCorrectValue(double input, double expected)
        {
            var result = Mathematics.Cos(input);
            Assert.That(result, Is.EqualTo(expected).Within(Tolerance));
        }

        [TestCase(1, 0.0)]
        [TestCase(Math.E, 1.0)]
        [TestCase(10, 2.302585)]
        public void Ln_ValidInput_ReturnsCorrectValue(double input, double expected)
        {
            var result = Mathematics.Ln(input);
            Assert.That(result, Is.EqualTo(expected).Within(Tolerance * 10));
        }

        [Test]
        public void Ln_NonPositiveInput_ReturnsNaN()
        {
            var result = Mathematics.Ln(0);
            Assert.That(double.IsNaN(result), Is.True);

            result = Mathematics.Ln(-5);
            Assert.That(double.IsNaN(result), Is.True);
        }

        [TestCase(0, 1.0)]
        [TestCase(1, 2.718281828)]
        [TestCase(-1, 0.367879441)]
        public void Exp_ValidInput_ReturnsCorrectValue(double input, double expected)
        {
            var result = Mathematics.Exp(input);
            Assert.That(result, Is.EqualTo(expected).Within(Tolerance));
        }

        [TestCase(5, 120)]
        [TestCase(0, 1)]
        [TestCase(1, 1)]
        [TestCase(7, 5040)]
        public void Factorial_ValidInput_ReturnsCorrectValue(int input, long expected)
        {
            var result = Mathematics.Factorial(input);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Factorial_NegativeInput_ReturnsNegativeOne()
        {
            var result = Mathematics.Factorial(-5);
            Assert.That(result, Is.EqualTo(-1));
        }

        [TestCase(-2.0)]
        [TestCase(0.0)]
        [TestCase(1.0)]
        [TestCase(2.0)]
        public void CustomFunction_ValidInput_ReturnsCloseToReference(double input)
        {
            var customResult = Mathematics.CustomFunction(input);
            var referenceResult = Mathematics.ReferenceFunction(input);

            // Для больших значений используем относительную погрешность
            if (Math.Abs(referenceResult) > 1)
            {
                double relativeError = Math.Abs(customResult - referenceResult) / Math.Abs(referenceResult);
                Assert.That(relativeError, Is.LessThan(0.01)); // 1% погрешность
            }
            else
            {
                Assert.That(customResult, Is.EqualTo(referenceResult).Within(0.1));
            }
        }

        [TestCase(-1.0)] // Логарифм от 0 даст NaN
        public void CustomFunction_EdgeCases_HandlesCorrectly(double input)
        {
            Assert.DoesNotThrow(() => Mathematics.CustomFunction(input));
        }
    }
}