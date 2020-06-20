using System;
using BinaryStructureFormat.Nodes;
using BinaryStructureFormat.Nodes.Primitives;
using NUnit.Framework;

namespace BinaryStructureFormat.Tests
{
    public class BsfStructTests
    {
        [Test]
        public void Get_IdentifierDoesNotExist_ReturnsNull()
        {
            Assert.AreEqual(null, new BsfStruct().Get<BsfNode>("NonExistent"));
        }
        
        [Test]
        public void Get_IdentifierExists_ReturnsCorrectNode()
        {
            var structure = new BsfStruct {["Node"] = new BsfInt(1)};
            Assert.AreEqual(1, structure.Get<BsfInt>("Node").Value);
        }
        
        [Test]
        public void Get_IdentifierExistsButInvalidType_ThrowsInvalidCastException()
        {
            var structure = new BsfStruct {["Node"] = new BsfInt(1)};
            Assert.Throws<InvalidCastException>(() => structure.Get<BsfBool>("Node"));
        }
        
        [Test]
        public void Indexer_IdentifierDoesNotExist_ReturnsNull()
        {
            Assert.AreEqual(null, new BsfStruct()["NonExistent"]);
        }
        
        [Test]
        public void Indexer_IdentifierExists_ReturnsCorrectNode()
        {
            var structure = new BsfStruct {["Node"] = new BsfInt(1)};
            Assert.AreEqual(1, ((BsfInt) structure["Node"]).Value);
        }
        
        [Test]
        public void Indexer_OverridingValue_DoesNotThrow()
        {
            var structure = new BsfStruct {["Node"] = new BsfInt(1)};
            Assert.DoesNotThrow(() => structure["Node"] = new BsfBool(true));
            Assert.DoesNotThrow(() => structure["Node"] = null);
        }
    }
}