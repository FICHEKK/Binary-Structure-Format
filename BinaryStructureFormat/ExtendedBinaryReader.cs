using System.IO;

namespace BinaryStructureFormat
{
    /// <summary>
    /// Extended binary reader that exposes the Read7BitEncodedInt method,
    /// which is otherwise unreachable due to its protected access modifier.
    /// </summary>
    public class ExtendedBinaryReader : BinaryReader
    {
        internal ExtendedBinaryReader(Stream stream) : base(stream) {}
        internal new int Read7BitEncodedInt() => base.Read7BitEncodedInt();
    }
}