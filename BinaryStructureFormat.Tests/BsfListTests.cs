using BinaryStructureFormat.Nodes;
using BinaryStructureFormat.Nodes.Primitives;
using NUnit.Framework;

namespace BinaryStructureFormat.Tests
{
    public class BsfListTests
    {
        [Test]
        public void ElementTypeTest()
        {
            Assert.AreEqual(BsfType.Null, new BsfList().ElementType);
            Assert.AreEqual(BsfType.Byte, new BsfList {new BsfByte(0)}.ElementType);
        }
        
        [Test]
        public void Add_NullProvided_DoesNotThrowException()
        {
            Assert.DoesNotThrow(() => new BsfList().Add(null));
        }
        
        [Test]
        public void Clear_DoesNotResetElementTypeToNull()
        {
            var list = new BsfList();
            Assert.AreEqual(BsfType.Null, list.ElementType);
            
            list.Add(new BsfByte(0));
            Assert.AreEqual(BsfType.Byte, list.ElementType);
            
            list.Clear();
            Assert.AreNotEqual(BsfType.Null, list.ElementType);
        }
        
        [Test]
        public void Add_NullProvided_DoesNotChangeElementType()
        {
            var list = new BsfList();
            Assert.AreEqual(BsfType.Null, list.ElementType);
            
            list.Add(null);
            Assert.AreEqual(BsfType.Null, list.ElementType);
            
            list.Add(new BsfByte(0));
            Assert.AreEqual(BsfType.Byte, list.ElementType);
            
            list.Add(null);
            Assert.AreEqual(BsfType.Byte, list.ElementType);
        }
    }
}