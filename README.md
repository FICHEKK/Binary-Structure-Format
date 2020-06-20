# Binary Structure Format
Binary structure format (BSF) is a lightweight binary file format for storing tree-like hierarchies of arbitrary data. It is heavily inspired by the Named Binary Tag (NBT) format defined by the Swedish video game programmer Markus Persson, for his widely successful game of Minecraft.

## The problem being solved
Today, there exist many popular formats that are capable of storing tree-like hierarchies of data. Popular examples include JSON (JavaScript Object Notation) and XML (Extensible Markup Language). These are great as both are easily read by humans and computers, as they are in a textual format.

However, that readability comes with a great cost of speed and memory. If speed and memory are critical, heavy use of those formats should be avoided. Binary structure format sacrifices readability in order to achieve high efficiency in both speed and memory.

## Primitive (leaf) nodes
Primitive nodes are nodes that store simple primitive values. Each node contains only a single primitive value.

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

## Array nodes
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
