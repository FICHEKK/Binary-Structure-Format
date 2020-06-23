using System;

namespace BinaryStructureFormat.Nodes.Primitives
{
    /// <summary>
    /// Primitive node that stores a single non-null string.
    /// </summary>
    public sealed class BsfString : BsfNode
    {
        private string _value;
        
        /// <summary>
        /// Non-null string stored by this node.
        /// </summary>
        public string Value
        {
            get => _value;
            set => _value = value ?? throw new ArgumentNullException(nameof(value), "BsfString's value cannot be set to null.");
        }

        /// <summary>
        /// Constructs a new node initialized with the default value of an empty string.
        /// </summary>
        public BsfString() => Value = string.Empty;
        
        /// <summary>
        /// Constructs a new node initialized with the provided value.
        /// </summary>
        /// <param name="value">Initial value of this node.</param>
        public BsfString(string value) => Value = value;

        public override BsfType Type => BsfType.String;
        public override void WriteValue(ExtendedBinaryWriter writer) => writer.Write(Value);
        public override void ReadValue(ExtendedBinaryReader reader) => Value = reader.ReadString();
    }
}