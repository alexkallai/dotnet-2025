### **C# (.NET) Base Types Categorised**

In C#, all types are derived from the ultimate base type `System.Object`. The Common Type System (CTS) divides types into two main categories: **Value Types** and **Reference Types**. Below is a detailed categorisation of base types in C#:

---

### **1. Value Types**

Value types directly contain their data and are stored in the stack. They are derived from `System.ValueType`.

#### **Subcategories:**

1. **Simple Types**:

   - **Integral Types**:

     - `byte` (`System.Byte`) - Unsigned 8-bit integer.

     - `sbyte` (`System.SByte`) - Signed 8-bit integer.

     - `short` (`System.Int16`) - Signed 16-bit integer.

     - `ushort` (`System.UInt16`) - Unsigned 16-bit integer.

     - `int` (`System.Int32`) - Signed 32-bit integer.

     - `uint` (`System.UInt32`) - Unsigned 32-bit integer.

     - `long` (`System.Int64`) - Signed 64-bit integer.

     - `ulong` (`System.UInt64`) - Unsigned 64-bit integer.

   - **Floating-Point Types**:

     - `float` (`System.Single`) - Single-precision floating-point.

     - `double` (`System.Double`) - Double-precision floating-point.

     - `decimal` (`System.Decimal`) - High-precision decimal type for financial calculations.

   - **Other Types**:

     - `char` (`System.Char`) - Represents a single Unicode character.

     - `bool` (`System.Boolean`) - Represents `true` or `false`.

2. **Enumerations**:

   - Derived from `System.Enum`.

   - Example: `enum Days { Sunday, Monday }`.

3. **Structs**:

   - User-defined value types.

   - Example: `struct Point { public int X; public int Y; }`.

4. **Nullable Types**:

   - Allow value types to represent `null`.

   - Example: `int?` (`System.Nullable<int>`).

---

### **2. Reference Types**

Reference types store references to their data, which is allocated on the heap. They are derived from `System.Object`.

#### **Subcategories:**

1. **Classes**:

   - **System.Object**: Base class for all types.

   - **System.String**: Represents a sequence of characters (immutable).

   - **System.Array**: Base class for all arrays.

   - **Custom Classes**: User-defined reference types.

   - Example: `class Person { public string Name; }`.

2. **Interfaces**:

   - Define contracts that classes or structs must implement.

   - Example: `interface IShape { void Draw(); }`.

3. **Delegates**:

   - Represent references to methods.

   - Derived from `System.Delegate`.

   - Example: `delegate void PrintMessage(string message);`.

4. **Dynamic**:

   - Represents objects whose operations are resolved at runtime.

   - Example: `dynamic obj = "Hello";`.

5. **Object**:

   - Can represent any type.

   - Example: `object obj = 42;`.

---

### **3. Special Types**

1. **Void**:

   - Represents the absence of a type.

   - Used as the return type for methods that do not return a value.

   - Example: `void MethodName() { }`.

2. **Pointer Types**:

   - Store memory addresses.

   - Example: `int* ptr;` (requires unsafe context).

---

### **4. Common Characteristics**

- **Boxing and Unboxing**:

  - Value types can be converted to reference types (`boxing`).

  - Reference types can be converted back to value types (`unboxing`).

  - Example:

    ```csharp

    int num = 10;

    object obj = num; // Boxing

    int unboxedNum = (int)obj; // Unboxing

    ```

- **Type Conversion**:

  - Implicit and explicit conversions between compatible types.

  - Example:

    ```csharp

    double d = 10; // Implicit conversion

    int i = (int)d; // Explicit conversion

    ```

---

### **Summary Table**

| **Category**       | **Type**                | **Description**                              |
|---------------------|-------------------------|----------------------------------------------|
| **Value Types**     | `int`, `float`, `bool` | Directly store data, derived from `ValueType`. |
| **Reference Types** | `string`, `object`     | Store references to data, derived from `Object`. |
| **Special Types**   | `void`, `dynamic`      | Special-purpose types for specific scenarios. |

