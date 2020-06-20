using System;
using BinaryStructureFormat.Nodes.Arrays;
using NUnit.Framework;

namespace BinaryStructureFormat.Tests
{
    public class BsfArraysTests
    {
        [Test]
        public void ArrayNodeConstructor_NullProvided_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BsfBoolArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfByteArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfShortArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfIntArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfLongArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfFloatArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfDoubleArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfCharArray(null));
            Assert.Throws<ArgumentNullException>(() => new BsfStringArray(null));
        }
        
        [Test]
        public void ArrayNodeConstructor_NoParametersProvided_InitializesToEmptyArray()
        {
            var boolArrayNode = new BsfBoolArray();
            Assert.AreNotEqual(null, boolArrayNode.Array);
            Assert.AreEqual(0, boolArrayNode.Array.Length);
            
            var byteArrayNode = new BsfByteArray();
            Assert.AreNotEqual(null, byteArrayNode.Array);
            Assert.AreEqual(0, byteArrayNode.Array.Length);
            
            var shortArrayNode = new BsfShortArray();
            Assert.AreNotEqual(null, shortArrayNode.Array);
            Assert.AreEqual(0, shortArrayNode.Array.Length);
            
            var intArrayNode = new BsfIntArray();
            Assert.AreNotEqual(null, intArrayNode.Array);
            Assert.AreEqual(0, intArrayNode.Array.Length);
            
            var longArrayNode = new BsfLongArray();
            Assert.AreNotEqual(null, longArrayNode.Array);
            Assert.AreEqual(0, longArrayNode.Array.Length);
            
            var floatArrayNode = new BsfFloatArray();
            Assert.AreNotEqual(null, floatArrayNode.Array);
            Assert.AreEqual(0, floatArrayNode.Array.Length);
            
            var doubleArrayNode = new BsfDoubleArray();
            Assert.AreNotEqual(null, doubleArrayNode.Array);
            Assert.AreEqual(0, doubleArrayNode.Array.Length);
            
            var charArrayNode = new BsfCharArray();
            Assert.AreNotEqual(null, charArrayNode.Array);
            Assert.AreEqual(0, charArrayNode.Array.Length);
            
            var stringArrayNode = new BsfStringArray();
            Assert.AreNotEqual(null, stringArrayNode.Array);
            Assert.AreEqual(0, stringArrayNode.Array.Length);
        }
        
        [Test]
        public void ArrayNodeSetter_NullProvided_ThrowsArgumentNullException()
        {
            var boolArrayNode = new BsfBoolArray();
            var byteArrayNode = new BsfByteArray();
            var shortArrayNode = new BsfShortArray();
            var intArrayNode = new BsfIntArray();
            var longArrayNode = new BsfLongArray();
            var floatArrayNode = new BsfFloatArray();
            var doubleArrayNode = new BsfDoubleArray();
            var charArrayNode = new BsfCharArray();
            var stringArrayNode = new BsfStringArray();

            Assert.Throws<ArgumentNullException>(() => boolArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => byteArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => shortArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => intArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => longArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => floatArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => doubleArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => charArrayNode.Array = null);
            Assert.Throws<ArgumentNullException>(() => stringArrayNode.Array = null);
        }
    }
}