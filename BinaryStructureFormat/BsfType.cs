namespace BinaryStructureFormat
{
    /// <summary>
    /// Enumeration of all of the supported node types. Each enumeration constant is a named and unique byte value.
    /// </summary>
    public enum BsfType : byte
    {
        /// <summary> Special type that represents a null reference (it has no node class associated with it). </summary>
        Null,
        
        /// <summary> Collection node that maps string identifiers to particular nodes. </summary>
        Struct,
        
        /// <summary> Collection node that holds a sequence of nodes of a specific type. </summary>
        List,
        
        /// <summary> Primitive node that holds a single unsigned 8-bit integer value. </summary>
        Byte,
        
        /// <summary> Primitive node that holds a single signed 16-bit integer value. </summary>
        Short,
        
        /// <summary> Primitive node that holds a single signed 32-bit integer value. </summary>
        Int,
        
        /// <summary> Primitive node that holds a single signed 64-bit integer value. </summary>
        Long,
        
        /// <summary> Primitive node that holds a single 32-bit single-precision floating point number. </summary>
        Float,
        
        /// <summary> Primitive node that holds a single 64-bit double-precision floating point number. </summary>
        Double,
        
        /// <summary> Primitive node that holds a single boolean value. </summary>
        Bool,
        
        /// <summary> Primitive node that holds a single Unicode UTF-16 character value. </summary>
        Char,
        
        /// <summary> Primitive node that holds a single non-null string. </summary>
        String,
        
        /// <summary> Array node that holds a single array of unsigned 8-bit integer values. </summary>
        ByteArray,
        
        /// <summary> Array node that holds a single array of signed 16-bit integer values. </summary>
        ShortArray,
        
        /// <summary> Array node that holds a single array of signed 32-bit integer values. </summary>
        IntArray,
        
        /// <summary> Array node that holds a single array of signed 64-bit integer values. </summary>
        LongArray,
        
        /// <summary> Array node that holds a single array of 32-bit single-precision floating point numbers. </summary>
        FloatArray,
        
        /// <summary> Array node that holds a single array of 64-bit double-precision floating point numbers. </summary>
        DoubleArray,
        
        /// <summary> Array node that holds a single array of boolean values. </summary>
        BoolArray,
        
        /// <summary> Array node that holds a single array of Unicode UTF-16 characters. </summary>
        CharArray,
        
        /// <summary> Array node that holds a single array of strings. </summary>
        StringArray
    }
}