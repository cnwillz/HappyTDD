using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestOrder
    {
        [Test]
        [Order(2)]
        public void TestA()
        {
            Debug.LogWarning("Order 2");
        }
        
        [Test]
        [Order(3)]
        public void TestB()
        {
            Debug.LogWarning("Order 3");
        }
        
        [Test]
        [Order(1)]
        public void TestC()
        {
            Debug.LogWarning("Order 1");
        }
    }
}
