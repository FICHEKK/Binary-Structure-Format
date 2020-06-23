using System.IO;

namespace BinaryStructureFormat
{
    /// <summary>
    /// Extended binary writer that exposes the Write7BitEncodedInt method,
    /// which is otherwise unreachable due to its protected access modifier.
    /// </summary>
    public class ExtendedBinaryWriter : BinaryWriter
    {
        internal ExtendedBinaryWriter(Stream stream) : base(stream) {}
        internal new void Write7BitEncodedInt(int value) => base.Write7BitEncodedInt(value);
    }
}