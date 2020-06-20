using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BinaryStructureFormat.Nodes
{
    public sealed class BsfList : BsfNode, IList<BsfNode>
    {
        public override BsfType Type => BsfType.List;
        public BsfType ElementType { get; private set; } = BsfType.Null;
        public int Count => _list.Count;
        public bool IsReadOnly => false;
        
        private readonly List<BsfNode> _list = new List<BsfNode>();

        public override void WriteValue(BinaryWriter writer)
        {
            writer.Write(_list.Count);

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

        public override void ReadValue(BinaryReader reader)
        {
            var count = reader.ReadInt32();

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
        //                              List read & write
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
        
        // ===================================================================================
        //                                List utility
        // ===================================================================================

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
        
        // ===================================================================================
        //                                 List iteration
        // ===================================================================================
        
        public IEnumerator<BsfNode> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}