# Binary Structure Format
Binary structure format (BSF) is a lightweight binary file format for storing tree-like hierarchies of arbitrary data. It is heavily inspired by the Named Binary Tag (NBT) format defined by the Swedish video game programmer Markus Persson, for his widely successful game of Minecraft.

### The problem being solved
Today, there exist many popular formats that are capable of storing tree-like hierarchies of data. Popular examples include JSON (JavaScript Object Notation) and XML (Extensible Markup Language). These are great as both are easily read by humans and computers, as they are in a textual format.

However, that readability comes with a great cost of speed and memory. If speed and memory are critical, heavy use of those formats should be avoided. Binary structure format sacrifices readability in order to achieve high efficiency in both speed and memory.

### Primitive (leaf) nodes
Primitive nodes are nodes that store simple primitive values. Each node is just a wrapper encapsulating a single primitive value.

| Node | Value | C# type |
| ---- | ----- | -------- |
| `BsfByte` | Signed 8-bit integer. | `byte` |
| `BsfShort` | Signed 16-bit integer. | `short` |
| `BsfInt` | Signed 32-bit integer. | `int` |
| `BsfLong` | Signed 64-bit integer. | `long` |
| `BsfFloat` | Single precision 32-bit floating point value. | `float` |
| `BsfDouble` | Double precision 64-bit floating point value. | `double` |
| `BsfBool` | Boolean value (true / false). | `bool` |
| `BsfChar` | Unicode UTF-16 character. | `char` |
| `BsfString` | Sequence of UTF-16 code units. | `string` |

Examples of using primitive nodes:

```cs
// Each node has a default constructor...
var byteNode1 = new BsfByte();

// ...and a parameterized constructor.
var byteNode2 = new BsfByte(13);

// String node will default to empty string.
var stringNode = new BsfString();

// Values from nodes can be fetched like this:
byte value1 = byteNode1.Value; // value1 = 0
byte value2 = byteNode2.Value; // value2 = 13
string str = stringNode.Value; // str = ""
```

### Array nodes
Array nodes are nodes that store a reference to an array of primitive values. Every primitive node has its corresponding array node.

| Node | Value | C# type |
| ---- | ----- | ------- |
| `BsfByteArray` | Array of signed 8-bit integers. | `byte[]` |
| `BsfShortArray` | Array of signed 16-bit integers. | `short[]` |
| `BsfIntArray` | Array of signed 32-bit integers. | `int[]` |
| `BsfLongArray` | Array of signed 64-bit integers. | `long[]` |
| `BsfFloatArray` | Array of single precision 32-bit floating point values. | `float[]` |
| `BsfDoubleArray` | Array of double precision 64-bit floating point values. | `double[]` |
| `BsfBoolArray` | Array of boolean values. | `bool[]` |
| `BsfCharArray` | Array of Unicode UTF-16 characters. | `char[]` |
| `BsfStringArray` | Array of strings. | `string[]` |

Examples of using array nodes:

```cs
// Default array value will be an empty array, never null.
var byteArrayNode1 = new BsfByteArray();

// Array can be passed in a constructor.
var byteArrayNode2 = new BsfByteArray(new byte[] {1, 2, 3});

// Arrays from nodes can be fetched like this:
byte[] array1 = byteArrayNode1.Array; // array1 = []
byte[] array2 = byteArrayNode2.Array; // array2 = [1, 2, 3]
```

### `BsfStruct` node
While primitive and array nodes are used for storing simple values, we need a mechanism that will allow the client to group those nodes into a complex structure. Also, since those complex structures will hold multiple nodes, we need to be able to somehow uniquely reference said nodes.

Both problems are solved by using the `BsfStruct` node. `BsfStruct` is essentially just a simple dictionary (key-value pair collection) that maps a unique `string` identifier to the corresponding `BsfNode`. Since `BsfStruct` itself is a `BsfNode`, nested structures of arbitrary depths are possible.

Structure can be easily defined using the indexer notation:

```cs
var structure = new BsfStruct
{
	["ByteValue"] = new BsfByte(1),
	["IntValue"] = new BsfInt(123),
	["NullValue"] = null,
	["NestedStruct"] = new BsfStruct
	{
		["Text"] = new BsfString("Some text..."),
		["NestedNull"] = null
	}
};
```

Fetching and modifying data in the structure is also very simple:

```cs
// Fetching data:
string text = structure.Get<BsfStruct>("NestedStruct").Get<BsfString>("Text").Value;

// Modifying data:
structure.Get<BsfByte>("ByteValue").Value = 5;
```

### `BsfList` node
Another special kind of node is `BsfList` node. It offers an interface for adding, removing or accessing multiple `BsfNode` instances. Only one type of `BsfNode` can be stored by the `BsfList`. List type is defined by the type of the first non-null node added to the list. For example, if the first node added to the list is an instance of `BsfByte`, then only `BsfByte` instances or `null` references are further allowed to be added to the list, otherwise an exception is thrown. Since `BsfList` is a `BsfNode`, nesting lists is possible.

```cs
var list = new BsfList
{
	new BsfByte(2),
	new BsfByte(7),
	null,
	new BsfByte(11)
};

// Adding another element to the list:
list.Add(new BsfByte(25));

// Adding another null value to the list:
list.Add(null);

// Adding an element of wrong type will cause an exception:
list.Add(new BsfString("Exception will be thrown on this line."));
```
