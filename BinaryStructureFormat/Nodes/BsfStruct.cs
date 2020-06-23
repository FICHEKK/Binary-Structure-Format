using System.Collections;
using System.Collections.Generic;

namespace BinaryStructureFormat.Nodes
{
    /// <summary>
    /// Collection node that maps string identifiers to particular nodes.
    /// </summary>
    public sealed class BsfStruct : BsfNode, IEnumerable<KeyValuePair<string, BsfNode>>
    {
        public override BsfType Type => BsfType.Struct;
        private readonly Dictionary<string, BsfNode> _dictionary = new Dictionary<string, BsfNode>();
        
        /// <summary>
        /// Returns the number of key/value pairs contained in this struct node.
        /// </summary>
        public int Count => _dictionary.Count;

        /// <summary>
        /// Writes all of the identifier/node pairs contained in this struct to the underlying stream,
        /// prefixed by the number of pairs encoded using LEB128 encoding.
        /// </summary>
        /// <param name="writer">Writer used for writing to the underlying stream.</param>
        public override void WriteValue(ExtendedBinaryWriter writer)
        {
            writer.Write7BitEncodedInt(_dictionary.Count);
            
            foreach (var (identifier, node) in _dictionary)
            {
                if (node == null)
                {
                    writer.Write((byte) BsfType.Null);
                    writer.Write(identifier);
                }
                else
                {
                    node.WriteType(writer);
                    writer.Write(identifier);
                    node.WriteValue(writer);
                }
            }
        }

        /// <summary>
        /// Reads a sequence of identifier/node pairs from the underlying stream, where
        /// the number of pairs is determined by the LEB128 encoded integer prefix.
        /// </summary>
        /// <param name="reader">Reader used for reading from the underlying stream.</param>
        public override void ReadValue(ExtendedBinaryReader reader)
        {
            var count = reader.Read7BitEncodedInt();

            for (var i = 0; i < count; i++)
            {
                var type = (BsfType) reader.ReadByte();
                var identifier = reader.ReadString();

                if (type == BsfType.Null)
                {
                    _dictionary.Add(identifier, null);
                }
                else
                {
                    var node = Create(type);
                    node.ReadValue(reader);
                    _dictionary.Add(identifier, node);
                }
            }
        }
        
        /// <summary>
        /// Returns the node associated with the specified identifier.
        /// </summary>
        /// <param name="identifier">Unique node identifier.</param>
        /// <typeparam name="T">Type of the requested node.</typeparam>
        /// <returns>Node associated with the identifier if found, otherwise null.</returns>
        public T Get<T>(string identifier) where T : BsfNode
        {
            return _dictionary.TryGetValue(identifier, out var node) ? (T) node : null;
        }

        // ===================================================================================
        //                       IEnumerable interface implementation
        // ===================================================================================
        
        public void Add(string identifier, BsfNode node)
        {
            _dictionary.Add(identifier, node);
        }

        public bool Remove(string identifier)
        {
            return _dictionary.Remove(identifier);
        }

        public void Clear()
        {
            _dictionary.Clear();
        }

        public BsfNode this[string identifier]
        {
            get => Get<BsfNode>(identifier);
            set => _dictionary[identifier] = value;
        }
        
        public bool ContainsKey(string identifier)
        {
            return _dictionary.ContainsKey(identifier);
        }

        public IEnumerator<KeyValuePair<string, BsfNode>> GetEnumerator()
        {
            return _dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}