using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class TestDecoratorC
    {
        [Test]
        public void TestRandom([Random(0, 10, 5)] int x) {
            Debug.LogFormat("Random {0}", x);
        }

        [Test]
        public void TestRange([NUnit.Framework.Range(0, 5, 1)] int x) {
            Debug.LogFormat("Range {0}", x);
        }

        [TestCase(10, 5, 2)]
        [TestCase(5, 5, 1)]
        [TestCase(1, 1, 1)]
        public void TestDivision(int a, int b, int c) {
            Assert.AreEqual(a / b, c);
        }

        [TestCaseSource("TestDivision2Source")]
        public void TestDivision2(int a, int b, int c) {
            Assert.AreEqual(a / b, c);
        }

        private static object[] TestDivision2Source = {
            new object[] {10, 5, 2},
            new object[] {6, 2, 3},
            new object[] { 0, 2, 0 }
        };

        [DatapointSource] public static readonly float[] Values = { -1f, 0f, 1f, 11f };
        
        [Theory]
        public void TestSquareRootDefination(float value) {
            Assume.That(value >= 0f);
            var root = Mathf.Sqrt(value);
            Assert.GreaterOrEqual(root, 0);
            Assert.That(root * root, Is.EqualTo(value).Within(0.000001f));
        }
        
        [Test]
        public void TestSquareRootDefination2([ValueSource("Values")]float value) {
            Assume.That(value >= 0f);
            var root = Mathf.Sqrt(value);
            Assert.GreaterOrEqual(root, 0);
            Assert.That(root * root, Is.EqualTo(value).Within(0.000001f));
        }
    }
}
