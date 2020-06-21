using System;
using System.IO;
using System.Text;
using BinaryStructureFormat.Nodes;
using BinaryStructureFormat.Nodes.Arrays;
using BinaryStructureFormat.Nodes.Primitives;

namespace BinaryStructureFormat
{
    public class BsfFile
    {
        public BsfStruct Root { get; private set; }
        public string IndentPattern { get; set; } = "\t";

        public BsfFile(BsfStruct root) => Root = root ?? throw new ArgumentNullException(nameof(root));
        public BsfFile(string sourcePath) => Load(sourcePath);

        public void Save(string path)
        {
            using (var writer = new ExtendedBinaryWriter(new FileStream(path, FileMode.Create)))
            {
                Root.WriteValue(writer);
            }
        }
        
        public void Load(string path)
        {
            using (var reader = new ExtendedBinaryReader(File.OpenRead(path)))
            {
                Root = new BsfStruct();
                Root.ReadValue(reader);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            ToStringRecursive("Root", Root, sb, 0);
            return sb.ToString();
        }

        private void ToStringRecursive(string identifier, BsfNode node, StringBuilder builder, int depth)
        {
            builder.Append(Repeat(IndentPattern, depth));

            if (identifier == null)
            {
                if (node == null)
                {
                    builder.Append("null\n");
                    return;
                }
                
                builder.Append($"[{node.Type}]: ");
            }
            else
            {
                if (node == null)
                {
                    builder.Append($"\"{identifier}\": null\n");
                    return;
                }

                builder.Append($"[{node.Type}] \"{identifier}\": ");
            }

            if (node.Type == BsfType.Struct)
            {
                builder.Append('\n');
                foreach (var (id, element) in (BsfStruct) node)
                {
                    ToStringRecursive(id, element, builder, depth + 1);
                }
            }
            else if (node.Type == BsfType.List)
            {
                builder.Append('\n');
                foreach (var element in (BsfList) node)
                {
                    ToStringRecursive(null, element, builder, depth + 1);
                }
            }
            else
            {
                builder.Append(ToString(node)).Append('\n');
            }
        }

        private static string ToString(BsfNode node)
        {
            switch (node.Type)
            {
                case BsfType.Byte:   return ((BsfByte) node).Value.ToString();
                case BsfType.Short:  return ((BsfShort) node).Value.ToString();
                case BsfType.Int:    return ((BsfInt) node).Value.ToString();
                case BsfType.Long:   return ((BsfLong) node).Value.ToString();
                case BsfType.Float:  return ((BsfFloat) node).Value.ToString();
                case BsfType.Double: return ((BsfDouble) node).Value.ToString();
                case BsfType.Bool:   return ((BsfBool) node).Value.ToString();
                case BsfType.Char:   return ((BsfChar) node).Value.ToString();
                case BsfType.String: return "\"" + ((BsfString) node).Value + "\"";
                    
                case BsfType.ByteArray:   return "[" + string.Join(' ', ((BsfByteArray) node).Array) + "]";
                case BsfType.ShortArray:  return "[" + string.Join(' ', ((BsfShortArray) node).Array) + "]";
                case BsfType.IntArray:    return "[" + string.Join(' ', ((BsfIntArray) node).Array) + "]";
                case BsfType.LongArray:   return "[" + string.Join(' ', ((BsfLongArray) node).Array) + "]";
                case BsfType.FloatArray:  return "[" + string.Join(' ', ((BsfFloatArray) node).Array) + "]";
                case BsfType.DoubleArray: return "[" + string.Join(' ', ((BsfDoubleArray) node).Array) + "]";
                case BsfType.BoolArray:   return "[" + string.Join(' ', ((BsfBoolArray) node).Array) + "]";
                case BsfType.CharArray:   return "[" + string.Join(' ', ((BsfCharArray) node).Array) + "]";
                case BsfType.StringArray: return "[" + string.Join(' ', ((BsfStringArray) node).Array) + "]";
                
                default: throw new ArgumentOutOfRangeException();
            }
        }
        
        private static string Repeat(string pattern, int count)
        {
            return new StringBuilder(pattern.Length * count).Insert(0, pattern, count).ToString();
        }
    }
}