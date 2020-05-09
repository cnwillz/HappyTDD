using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestDecoratorB
    {
        // A Test behaves as an ordinary method
        [Test]
        [Ignore("test")]
        public void TestIgnored() {
            //never reach
            Assert.Fail();
        }

        [UnityTest]
        [Description("desc")]
        [Author("author")]
        [Category("cate")]
        [Apartment(System.Threading.ApartmentState.STA)]
        public IEnumerator TestDecrotaors() {
            yield return null;
        }

        #region TEST_PALTFORMS
        [Test]
        [UnityPlatform(exclude = new RuntimePlatform[] { },
            include = new RuntimePlatform[] {RuntimePlatform.WindowsEditor})]
        public void TestPlatformInclude() {
            
        }
        
        [Test]
        [UnityPlatform(exclude = new RuntimePlatform[] { RuntimePlatform.WindowsEditor },
            include = new RuntimePlatform[] {})]
        public void TestPlatformExclude() {
            
        }

#if UNITY_IPHONE
        [Test]
        public void TestIphone() {}
#endif
        #endregion

        [Test]
        [Repeat(3)]
        public void TestRepeat() {
            Debug.Log("Repeated.");
        }

        private static int _retryCount = 0;
        
        [Test]
        [Retry(5)]
        public void TestRetry() {
            Debug.Log("Retried.");
            _retryCount++;
            if(_retryCount < 3)
                Assert.That(false);
            else
                Assert.That(true);

        }
    }
}
