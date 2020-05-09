using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestDecoratorA
    {
        [Test]
        [Combinatorial]
        public void TestCombinatorial([Values(1, 2)] int a, [Values("A", "B")] string b, [Values(true, false)] bool c) {
            Debug.LogWarningFormat("TestCombinatorial {0} {1} {2}", a, b, c);
        }
        
        [Test]
        [Pairwise]
        public void TestPairwise([Values(1, 2)] int a, [Values("A", "B")] string b, [Values(true, false)] bool c) {
            Debug.LogWarningFormat("TestPairwise {0} {1} {2}", a, b, c);
        }
        
        [Test]
        [Sequential]
        public void TestSequential([Values(1, 2)] int a, [Values("A", "B")] string b, [Values(true, false)] bool c) {
            Debug.LogWarningFormat("TestSequential {0} {1} {2}", a, b, c);
        }
    }
}
