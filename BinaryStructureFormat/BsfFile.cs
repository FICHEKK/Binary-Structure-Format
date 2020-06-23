using System;
using System.IO;
using System.Text;
using BinaryStructureFormat.Nodes;
using BinaryStructureFormat.Nodes.Arrays;
using BinaryStructureFormat.Nodes.Primitives;

namespace BinaryStructureFormat
{
    /// <summary>
    /// Models a single binary-structure-format file and offers a simple interface
    /// for saving, loading and converting its contents to a readable string format.
    /// </summary>
    public class BsfFile
    {
        /// <summary>
        /// Root of the structure held by this instance.
        /// </summary>
        public BsfStruct Root { get; private set; }

        /// <summary>
        /// Constructs a new binary-structure-format file with the given structure.
        /// </summary>
        /// <param name="root">Root of the structure. Cannot be null.</param>
        public BsfFile(BsfStruct root) => Root = root ?? throw new ArgumentNullException(nameof(root));
        
        /// <summary>
        /// Constructs a new binary-structure-format file and loads its structure from the specified file.
        /// </summary>
        /// <param name="sourcePath">Path of the source file.</param>
        public BsfFile(string sourcePath) => Load(sourcePath);

        /// <summary>
        /// Saves the structure held by this instance to the specified file.
        /// </summary>
        /// <param name="path">Path of the destination file.</param>
        public void Save(string path)
        {
            using (var writer = new ExtendedBinaryWriter(new FileStream(path, FileMode.Create)))
            {
                Root.WriteValue(writer);
            }
        }
        
        /// <summary>
        /// Loads the structure from the specified file.
        /// </summary>
        /// <param name="path">Path of the source file.</param>
        public void Load(string path)
        {
            using (var reader = new ExtendedBinaryReader(File.OpenRead(path)))
            {
                Root = new BsfStruct();
                Root.ReadValue(reader);
            }
        }

        /// <summary>
        /// Converts the underlying structure to a single string and returns that string.
        /// </summary>
        /// <param name="indentPattern">Pattern used to display indentation.</param>
        /// <returns>String version of the underlying structure.</returns>
        public string Stringify(string indentPattern = "\t")
        {
            var sb = new StringBuilder();
            StringifyRecursive("Root", Root, sb, 0, indentPattern);
            return sb.ToString();
        }

        private static void StringifyRecursive(string identifier, BsfNode node, StringBuilder builder, int depth, string indentPattern)
        {
            builder.Append(Repeat(indentPattern, depth));
            AppendIdentifier(identifier, node, builder);

            var type = node?.Type ?? BsfType.Null;
            
            switch (type)
            {
                case BsfType.Struct: StringifyStruct(identifier, (BsfStruct) node, builder, depth, indentPattern); break;
                case BsfType.List:   StringifyList(identifier, (BsfList) node, builder, depth, indentPattern); break;
                default:             builder.Append(Stringify(node)); break;
            }
            
            builder.Append('\n');
        }
        
        private static void AppendIdentifier(string identifier, BsfNode node, StringBuilder builder)
        {
            if (identifier == null) return;
            builder.Append($"\"{identifier}\"");

            if (node == null || node.Type != BsfType.Struct && node.Type != BsfType.List)
            {
                builder.Append(" = ");
            }
        }

        private static void StringifyStruct(string identifier, BsfStruct structure, StringBuilder builder, int depth, string indentPattern)
        {
            if (identifier != null) builder.Append('\n').Append(Repeat(indentPattern, depth));
            builder.Append('{').Append('\n');
                
            foreach (var (id, element) in structure)
                StringifyRecursive(id, element, builder, depth + 1, indentPattern);

            builder.Append(Repeat(indentPattern, depth)).Append('}');
        }
        
        private static void StringifyList(string identifier, BsfList list, StringBuilder builder, int depth, string indentPattern)
        {
            if (identifier != null) builder.Append('\n').Append(Repeat(indentPattern, depth));
            builder.Append('[').Append('\n');

            foreach (var element in list)
                StringifyRecursive(null, element, builder, depth + 1, indentPattern);

            builder.Append(Repeat(indentPattern, depth)).Append(']');
        }

        private static string Stringify(BsfNode node)
        {
            if (node == null) return "null";

            return node.Type switch
            {
                BsfType.Byte =>   ((BsfByte) node).Value.ToString(),
                BsfType.Short =>  ((BsfShort) node).Value.ToString(),
                BsfType.Int =>    ((BsfInt) node).Value.ToString(),
                BsfType.Long =>   ((BsfLong) node).Value.ToString(),
                BsfType.Float =>  ((BsfFloat) node).Value.ToString(),
                BsfType.Double => ((BsfDouble) node).Value.ToString(),
                BsfType.Bool =>   ((BsfBool) node).Value.ToString(),
                BsfType.Char =>   ((BsfChar) node).Value.ToString(),
                BsfType.String => ("\"" + ((BsfString) node).Value + "\""),
                BsfType.ByteArray =>   ("[" + string.Join(' ', ((BsfByteArray) node).Array) + "]"),
                BsfType.ShortArray =>  ("[" + string.Join(' ', ((BsfShortArray) node).Array) + "]"),
                BsfType.IntArray =>    ("[" + string.Join(' ', ((BsfIntArray) node).Array) + "]"),
                BsfType.LongArray =>   ("[" + string.Join(' ', ((BsfLongArray) node).Array) + "]"),
                BsfType.FloatArray =>  ("[" + string.Join(' ', ((BsfFloatArray) node).Array) + "]"),
                BsfType.DoubleArray => ("[" + string.Join(' ', ((BsfDoubleArray) node).Array) + "]"),
                BsfType.BoolArray =>   ("[" + string.Join(' ', ((BsfBoolArray) node).Array) + "]"),
                BsfType.CharArray =>   ("[" + string.Join(' ', ((BsfCharArray) node).Array) + "]"),
                BsfType.StringArray => ("[" + string.Join(' ', ((BsfStringArray) node).Array) + "]"),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
        
        private static string Repeat(string pattern, int count)
        {
            return new StringBuilder(pattern.Length * count).Insert(0, pattern, count).ToString();
        }
    }
}