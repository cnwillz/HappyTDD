using System.Collections;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestUnitTest {

        [SetUp]
        public void Setup() {
            Debug.Log("Setup");
        }

        [TearDown]
        public void TearDown() {
            Debug.Log("TearDown");
        }

        [OneTimeSetUp]
        public void OneTimeSetUp() {
            Debug.Log("OneTimeSetUp");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() {
            Debug.Log("OneTimeTearDown");
        }
        
        // A Test behaves as an ordinary method
        [Test]
        public void TestUnitTestSimplePasses() {
            // Use the Assert class to test conditions
            Assert.AreEqual(1, 1);
            Assert.Greater(2, 1);
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestUnitTestWithEnumeratorPasses() {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }

        [Test]
        [MaxTime(500)]
        [Timeout(500)] //play mode
        public void TestSleepTime() {
            Thread.Sleep(100);
        }

        [UnityTest]
        public IEnumerator TestWaitForSec() {
            var startTime = System.DateTime.UtcNow;
            while ((System.DateTime.UtcNow - startTime).TotalMilliseconds < 200) {
                yield return null;
            }
            
            Assert.Pass();
        }

        [Test]
        public void TestErrorExpect() {
            LogAssert.Expect(LogType.Error, "Failed.");
            Debug.LogError("Failed.");
            
            LogAssert.NoUnexpectedReceived();

            LogAssert.ignoreFailingMessages = true;
            Debug.LogError("Failed 2.");
            Debug.LogError("Failed 3.");
            LogAssert.ignoreFailingMessages = false;
        }
    }
}
