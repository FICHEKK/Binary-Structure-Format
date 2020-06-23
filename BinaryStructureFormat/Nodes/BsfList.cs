using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryStructureFormat.Nodes
{
    /// <summary>
    /// Collection node that holds a sequence of nodes of a specific type.
    /// </summary>
    public sealed class BsfList : BsfNode, IList<BsfNode>
    {
        public override BsfType Type => BsfType.List;
        private readonly List<BsfNode> _list = new List<BsfNode>();
        
        /// <summary>
        /// Type of nodes that are held by this list. Defaults to "Null", but
        /// changes to the type of the first inserted non-null node.
        /// </summary>
        public BsfType ElementType { get; private set; } = BsfType.Null;
        
        /// <summary>
        /// Returns the number of elements contained in this list node.
        /// </summary>
        public int Count => _list.Count;
        
        /// <summary>
        /// Indicates whether this list is read-only (always returns false).
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Writes all of the nodes contained in this list to the underlying stream, prefixed
        /// by the number of elements encoded using LEB128 encoding.
        /// </summary>
        /// <param name="writer">Writer used for writing to the underlying stream.</param>
        public override void WriteValue(ExtendedBinaryWriter writer)
        {
            writer.Write7BitEncodedInt(_list.Count);

            foreach (var node in _list)
            {
                if (node == null)
                {
                    writer.Write((byte) BsfType.Null);
                }
                else
                {
                    node.WriteType(writer);
                    node.WriteValue(writer);
                }
            }
        }

        /// <summary>
        /// Reads a list of nodes from the underlying stream, where the number of
        /// nodes is determined by the LEB128 encoded integer prefix.
        /// </summary>
        /// <param name="reader">Reader used for reading from the underlying stream.</param>
        public override void ReadValue(ExtendedBinaryReader reader)
        {
            var count = reader.Read7BitEncodedInt();

            for (var i = 0; i < count; i++)
            {
                var type = (BsfType) reader.ReadByte();

                if (type == BsfType.Null)
                {
                    _list.Add(null);
                }
                else
                {
                    if (ElementType == BsfType.Null)
                        ElementType = type;
                    
                    if (type != ElementType)
                        throw new InvalidOperationException($"List contains elements of both type '{ElementType}' and '{type}");
                    
                    var node = Create(ElementType);
                    node.ReadValue(reader);
                    _list.Add(node);
                }
            }
        }

        // ===================================================================================
        //                         IList interface implementation
        // ===================================================================================
        
        public void Add(BsfNode node)
        {
            ValidateNodeType(node);
            _list.Add(node);
        }
        
        public void Insert(int index, BsfNode node)
        {
            ValidateNodeType(node);
            _list.Insert(index, node);
        }

        public bool Remove(BsfNode node)
        {
            return _list.Remove(node);
        }
        
        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        public void Clear()
        {
            _list.Clear();
        }
        
        public BsfNode this[int index]
        {
            get => _list[index];
            set
            {
                ValidateNodeType(value);
                _list[index] = value;
            }
        }

        private void ValidateNodeType(BsfNode node)
        {
            if (node == null) return;
            
            if (ElementType == BsfType.Null)
                ElementType = node.Type;
            
            if (ElementType != node.Type)
                throw new InvalidOperationException($"Cannot add/insert node of type '{node.Type}' to a list of type '{ElementType}'");
        }

        public void CopyTo(BsfNode[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public int IndexOf(BsfNode node)
        {
            return _list.IndexOf(node);
        }

        public bool Contains(BsfNode node)
        {
            return _list.Contains(node);
        }

        public IEnumerator<BsfNode> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}