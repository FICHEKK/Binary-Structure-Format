namespace BinaryStructureFormat
{
    public enum BsfType : byte
    {
        Null,
        Struct,
        List,
        
        // Primitives
        Byte,
        Short,
        Int,
        Long,
        Float,
        Double,
        Bool,
        Char,
        String,
        
        // Primitive arrays
        ByteArray,
        ShortArray,
        IntArray,
        LongArray,
        FloatArray,
        DoubleArray,
        BoolArray,
        CharArray,
        StringArray,
    }
}