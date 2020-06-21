using System.Collections;
using System.Collections.Generic;

namespace BinaryStructureFormat.Nodes
{
    public sealed class BsfStruct : BsfNode, IEnumerable<KeyValuePair<string, BsfNode>>
    {
        public override BsfType Type => BsfType.Struct;
        public int Count => _dictionary.Count;

        private readonly Dictionary<string, BsfNode> _dictionary = new Dictionary<string, BsfNode>();

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

        // ===================================================================================
        //                               Struct read & write
        // ===================================================================================
        
        public void Add(string identifier, BsfNode node)
        {
            _dictionary.Add(identifier, node);
        }

        public T Get<T>(string identifier) where T : BsfNode
        {
            return _dictionary.TryGetValue(identifier, out var node) ? (T) node : null;
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

        // ===================================================================================
        //                                Struct utility
        // ===================================================================================
        
        public bool ContainsKey(string identifier)
        {
            return _dictionary.ContainsKey(identifier);
        }

        // ===================================================================================
        //                                Struct iteration
        // ===================================================================================

        public IEnumerator<KeyValuePair<string, BsfNode>> GetEnumerator() => _dictionary.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}