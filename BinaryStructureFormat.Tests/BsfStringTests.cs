using System;
using BinaryStructureFormat.Nodes.Primitives;
using NUnit.Framework;

namespace BinaryStructureFormat.Tests
{
    public class BsfStringTests
    {
        [Test]
        public void DefaultConstructor_InitializesValueToEmptyString()
        {
            Assert.AreEqual(string.Empty, new BsfString().Value);
        }
        
        [Test]
        public void ParametrizedConstructor_NullProvided_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BsfString(null));
        }
        
        [Test]
        public void ValueSetter_NullProvided_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BsfString {Value = null});
        }
    }
}