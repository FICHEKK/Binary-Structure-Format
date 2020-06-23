# Binary Structure Format
Binary structure format (BSF) is a lightweight binary file format for storing tree-like hierarchies of arbitrary data. It is heavily inspired by the Named Binary Tag (NBT) format defined by the Swedish video game programmer Markus Persson, for his widely successful game of Minecraft.

___

### The problem being solved
Today, there exist many popular formats that are capable of storing tree-like hierarchies of data. Popular examples include JSON (JavaScript Object Notation) and XML (Extensible Markup Language). These are great as both are easily read by humans and computers, as they are in a textual format.

However, that readability comes with a great cost of speed and memory. If speed and memory are critical, heavy use of those formats should be avoided. Binary structure format sacrifices readability in order to achieve high efficiency in both speed and memory.

___

### The format
Binary structure format stores its data hierarchy in a series of nodes. Each node type has its unique identifier which is simply a unique `byte` value that identifies each node type. There are three main types of nodes:

1. Primitive node - holds a simple primitive value such as `int` or a `double` value.
2. Array node - holds an array of primitive values such as `int[]` or a `double[]` array.
3. Collection node - holds multiple nodes (and can also hold `null` values).
	* `BsfStruct` that maps the `string` identifier to a specific node.
	* `BsfList` that models a sequential collection of nodes of a specific type.
	
___

### Abstract `BsfNode` base class
Before we take a look at concrete nodes, we should mention that every single concrete node derives from abstract `BsfNode` base class. Classes that derive from `BsfNode` need to implement the following functionality:

1. Return the type of the node. `BsfType` is just a simple enumeration of unique `byte` values. This is the value by which we determine what data is stored in the concrete node.
```cs
public abstract BsfType Type { get; }
```

2. Every concrete node must be able to write its data to the underlying stream.
```cs
public abstract void WriteValue(ExtendedBinaryWriter writer);
```

3. Every concrete node must be able to read its data from the underlying stream.
```cs
public abstract void ReadValue(ExtendedBinaryReader reader);
```

For concrete implementations, take a look at the source code provided in this repository.

___

### Primitive (leaf) nodes
Primitive nodes are nodes that store simple primitive values. Each node is just a wrapper encapsulating a single primitive value.

**Note**: Even though `BsfString` is not considered a primitive type by the C# standard, it is still included here as it is that frequent and important.

| Node | Value | C# type |
| :--: | :---: | :-----: |
| `BsfByte` | Unsigned 8-bit integer. | `byte` |
| `BsfShort` | Signed 16-bit integer. | `short` |
| `BsfInt` | Signed 32-bit integer. | `int` |
| `BsfLong` | Signed 64-bit integer. | `long` |
| `BsfFloat` | Single-precision 32-bit floating point number. | `float` |
| `BsfDouble` | Double-precision 64-bit floating point number. | `double` |
| `BsfBool` | Boolean value (true / false). | `bool` |
| `BsfChar` | Unicode UTF-16 character. | `char` |
| `BsfString` | Length-prefixed ([LEB128](https://en.wikipedia.org/wiki/LEB128)) sequence of UTF-16 characters. | `string` |

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

___

### Array nodes
Array nodes are nodes that store a reference to an array of primitive values. Every primitive node has its corresponding array node. Every array node derives from abstract generic `BsfArray<T>` base class (which itself derives from `BsfNode`).

| Node | Value | C# type |
| :--: | :---: | :-----: |
| `BsfByteArray` | Array of unsigned 8-bit integers. | `byte[]` |
| `BsfShortArray` | Array of signed 16-bit integers. | `short[]` |
| `BsfIntArray` | Array of signed 32-bit integers. | `int[]` |
| `BsfLongArray` | Array of signed 64-bit integers. | `long[]` |
| `BsfFloatArray` | Array of single-precision 32-bit floating point numbers. | `float[]` |
| `BsfDoubleArray` | Array of double-precision 64-bit floating point numbers. | `double[]` |
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

___

### `BsfStruct` node
While primitive and array nodes are used for storing simple values, we need a mechanism that will allow the client to group those nodes into a complex structure. Also, since those complex structures will hold multiple nodes, we need to be able to somehow uniquely reference those same nodes.

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

___

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

___

### `null` values
Binary structure format supports `null` values **exclusively** in `BsfStruct` and `BsfList`. A primitive or an array node is not allowed to hold a `null` reference. Trying to assign a `null` reference to the `BsfString` or any of the array nodes will cause an `ArgumentNullException` to be thrown. `BsfStringArray` elements also must be non-null `string` references, otherwise an `ArgumentNullException` will be thrown during the writing of the binary file.

```cs
var stringNode = new BsfString();
stringNode.Value = null; // ArgumentNullException

var byteArrayNode = new ByteArrayNode(null); // ArgumentNullException

var intArrayNode = new IntArrayNode();
intArrayNode.Array = null; // ArgumentNullException
```

___

### How are nodes written to a binary file?
Before we take a look at an example, we should mention what is actually stored inside a single `.bfs` file. The answer is surprisingly simple: a single `.bfs` file contains a single serialized `BsfStruct`. This is the reason why this format is named *Binary structure* format; it holds a single complex structure, encoded in binary.

Lets take a look at this simple structure:

```cs
var structure = new BsfStruct
{
	["Byte"] = new BsfByte(0xFF),
	["N"] = null,
	["A"] = new BsfShortArray(new short[] {1, 2}),
	["L"] = new BsfList
	{
		new BsfBool(false),
		null
	}
};
```
Serializing this particular structure, we get the following result:

`04 | 03 04 42 79 74 65 FF | 00 01 4E | 0D 01 41 02 01 00 02 00 | 02 01 4C 02 09 00 00`

**Note**: Data of each child node has been separated by the `|` symbol for easier understanding of the format.

Meaning of each byte is as follows:

1. `04` = number of child nodes stored in the `structure`, encoded using *LEB128* encoding
___
2. `03` = type of the first child node, in this case it is `BsfType.Byte`
3. `04` = length of the `string` identifier of the `BsfByte` node, encoded using *LEB128* encoding
4. `42` = `B` character
5. `79` = `y` character
6. `74` = `t` character
7. `65` = `e` character
8. `FF` = value of the `BsfByte` node
___
9. `00` = type of the second child node, in this case it is `BsfType.Null`
10. `01` = length of the `string` identifier of the `null` value (`null` values do not have their own node class, as it is not needed)
11. `4E` = `N` character
___
12. `0D` = type of the third child node, in this case it is `BsfType.ShortArray`
13. `01` = length of the `string` identifier of the `BsfShortArray` node, encoded using *LEB128* encoding
14. `41` = `A` character
15. `02` = number of elements stored in the `short[]`, encoded using *LEB128* encoding
16. `01` = first byte of the first `short` element in the array
17. `00` = second byte of the first `short` element in the array
18. `02` = first byte of the second `short` element in the array
19. `00` = second byte of the second `short` element in the array
___
20. `02` = type of the third child node, in this case it is `BsfType.List`
21. `01` = length of the `string` identifier of the `BsfList` node, encoded using *LEB128* encoding
22. `4C` = `L` character
23. `02` = number of nodes stored in the list, encoded using *LEB128* encoding
24. `09` = type of the first node in the list, in this case it is `BsfType.Bool`
25. `00` = value of the `BsfBool` node, in this case it is `false`
26. `00` = type of the second node in the list, in this case it is `BsfType.Null`

As you might have noticed, every information about the variable length (concretely: `BsfString` length, `BsfArray<T>` length, `BsfStruct` length and `BsfList` length) is encoded using *LEB128* encoding, which saves significant amounts of data, especially when storing many strings, arrays, structs or lists with small number of elements (which is very frequently the case).

___

### `BsfList` vs `BsfArray`
**Note**: `BsfArray` means any of the [array nodes](#array-nodes) (`BsfByteArray`, `BsfIntArray` and so on...).

If you need to store multiple values (for example bytes of an image), do **NOT** use `BsfList`, but rather a `BsfByteArray`. `BsfList` is a fairly expensive structure as each element of the `BsfList` is a `BsfNode` instance (1 element = 1 object on heap, unless element is a `null` reference), compared to `BsfArray` where all elements are simple primitive values stored in contiguous memory locations. Additionally, `BsfList` also has to keep track of storing `null` values, which will increase the memory footprint when storing data in the persistent memory.

So, when should you use `BsfList`?
1. If your element values can be `null`.
2. If you need to store a list of complex structures (use `BsfStruct` for defining those).

If possible, always prefer storing multiple values in a `BsfArray`.

___

### Writing/saving data to a binary `.bsf` file (serialization)
Serializing data hierarchy is made extremely easy using the `BsfFile` component:

```cs
var structure = new BsfStruct { ... };

var bsfFile = new BsfFile(structure);
bsfFile.Save("file.bsf");
```

### Reading/loading data from a binary `.bsf` file (deserialization)
Deserializing is even simpler:

```cs
BsfStruct structure = new BsfFile("file.bsf").Root;
```
