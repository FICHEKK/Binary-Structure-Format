using BinaryStructureFormat.Nodes;
using BinaryStructureFormat.Nodes.Arrays;
using BinaryStructureFormat.Nodes.Primitives;
using NUnit.Framework;

namespace BinaryStructureFormat.Tests
{
    public class BsfTypeTests
    {
        [Test]
        public void BsfPrimitives_ReturnAppropriateTypeValue()
        {
            Assert.AreEqual(BsfType.Bool, new BsfBool().Type);
            Assert.AreEqual(BsfType.Byte, new BsfByte().Type);
            Assert.AreEqual(BsfType.Short, new BsfShort().Type);
            Assert.AreEqual(BsfType.Int, new BsfInt().Type);
            Assert.AreEqual(BsfType.Long, new BsfLong().Type);
            Assert.AreEqual(BsfType.Float, new BsfFloat().Type);
            Assert.AreEqual(BsfType.Double, new BsfDouble().Type);
            Assert.AreEqual(BsfType.Char, new BsfChar().Type);
            Assert.AreEqual(BsfType.String, new BsfString().Type);
        }
        
        [Test]
        public void BsfArrays_ReturnAppropriateTypeValue()
        {
            Assert.AreEqual(BsfType.BoolArray, new BsfBoolArray().Type);
            Assert.AreEqual(BsfType.ByteArray, new BsfByteArray().Type);
            Assert.AreEqual(BsfType.ShortArray, new BsfShortArray().Type);
            Assert.AreEqual(BsfType.IntArray, new BsfIntArray().Type);
            Assert.AreEqual(BsfType.LongArray, new BsfLongArray().Type);
            Assert.AreEqual(BsfType.FloatArray, new BsfFloatArray().Type);
            Assert.AreEqual(BsfType.DoubleArray, new BsfDoubleArray().Type);
            Assert.AreEqual(BsfType.CharArray, new BsfCharArray().Type);
            Assert.AreEqual(BsfType.StringArray, new BsfStringArray().Type);
        }
        
        [Test]
        public void BsfList_ReturnsAppropriateTypeValue()
        {
            Assert.AreEqual(BsfType.List, new BsfList().Type);
        }
        
        [Test]
        public void BsfStruct_ReturnsAppropriateTypeValue()
        {
            Assert.AreEqual(BsfType.Struct, new BsfStruct().Type);
        }
    }
}