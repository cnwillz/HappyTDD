using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSeverity
    {
        public enum  TestSeverityLevel {
            Minor,
            Major
        }
        
        public class TestSeverityAttribute: NUnit.Framework.PropertyAttribute {
            public TestSeverityAttribute(TestSeverityLevel level) {
                Debug.LogFormat("Test Severity: {0}", level);
            }
        }

        [Test]
        [TestSeverity(TestSeverityLevel.Minor)]
        public void TestSeverities() {
            
        }
    }
}
