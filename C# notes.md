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



# Summary of C# Keywords

C# has a set of reserved keywords that are predefined and have special meanings to the compiler. These keywords are used to define the syntax and structure of C# programs. Below is a categorised summary of C# keywords:

---

## **1. Access Modifiers**
Used to define the accessibility of types and members.
- `public` - Accessible from any code.
- `private` - Accessible only within the containing type.
- `protected` - Accessible within the containing type and derived types.
- `internal` - Accessible within the same assembly.
- `protected internal` - Accessible within the same assembly or derived types.

---

## **2. Data Types**
Used to define variables and their types.
- **Value Types**:
  - `bool`, `byte`, `sbyte`, `char`, `decimal`, `double`, `float`, `int`, `uint`, `long`, `ulong`, `short`, `ushort`
- **Reference Types**:
  - `object`, `string`, `dynamic`

---

## **3. Control Flow**
Used to control the flow of execution in a program.
- **Conditionals**:
  - `if`, `else`, `switch`, `case`
- **Loops**:
  - `for`, `foreach`, `while`, `do`, `break`, `continue`
- **Jump Statements**:
  - `return`, `goto`, `throw`, `yield`

---

## **4. Exception Handling**
Used to handle runtime errors.
- `try`, `catch`, `finally`, `throw`

---

## **5. Object-Oriented Programming**
Used to define classes, objects, and their behaviour.
- **Class and Object Keywords**:
  - `class`, `struct`, `interface`, `enum`, `delegate`
- **Inheritance and Polymorphism**:
  - `abstract`, `virtual`, `override`, `sealed`, `base`, `this`
- **Access and Reference**:
  - `new`, `readonly`, `const`, `static`

---

## **6. Namespace and Assembly**
Used to organise code and manage scope.
- `namespace`, `using`, `extern`, `assembly`

---

## **7. Modifiers**
Used to modify declarations.
- `const`, `readonly`, `static`, `volatile`, `async`, `await`

---

## **8. LINQ and Query Keywords**
Used for querying data.
- `from`, `where`, `select`, `group`, `orderby`, `join`, `into`, `let`

---

## **9. Miscellaneous Keywords**
- `is` - Checks object compatibility with a type.
- `as` - Performs safe type conversion.
- `typeof` - Gets the `Type` object for a type.
- `sizeof` - Gets the size of a value type.
- `checked` / `unchecked` - Controls overflow checking for arithmetic operations.
- `lock` - Ensures thread safety.
- `using` - Manages resources or imports namespaces.
- `fixed` - Pins a variable in memory.
- `unsafe` - Allows unsafe code blocks.

---

## **10. Contextual Keywords**
These have special meaning in specific contexts but are not reserved.
- `add`, `remove`, `get`, `set`, `partial`, `yield`, `where`, `dynamic`, `global`

---

## **11. Unused or Rarely Used Keywords**
These are less commonly used but have specific purposes.
- `__arglist`, `__makeref`, `__reftype`, `__refvalue`

---

## **Notes**
- Keywords cannot be used as identifiers unless prefixed with `@`.
- Example:
  ```csharp
  int @class = 10; // Valid, but not recommended



## **1. Access Modifiers**

Access modifiers in C# define the visibility and accessibility of classes, methods, and other members. Below are examples and edge cases for each access modifier:

---

### **`public`**

- **Description**: Members declared as `public` are accessible from any code in the same assembly or another assembly that references it.

- **Example**:

  ```csharp

  public class PublicExample

  {

      public string Name = "HEITEC";

      public void Display()

      {

          Console.WriteLine($"Name: {Name}");

      }

  }

  // Accessible from anywhere

  var example = new PublicExample();

  example.Display(); // Works fine

  ```

- **Edge Case**: Be cautious when exposing sensitive data or methods as `public`, as they can be accessed and modified from anywhere.

---

### **`private`**

- **Description**: Members declared as `private` are accessible only within the containing class.

- **Example**:

  ```csharp

  public class PrivateExample

  {

      private string Secret = "Top Secret";

      public void ShowSecret()

      {

          Console.WriteLine($"Secret: {Secret}"); // Accessible within the class

      }

  }

  var example = new PrivateExample();

  // example.Secret = "New Secret"; // Error: Cannot access private member

  example.ShowSecret(); // Works fine

  ```

- **Edge Case**: Overuse of `private` can make testing and extending functionality difficult.

---

### **`protected`**

- **Description**: Members declared as `protected` are accessible within the containing class and any derived classes.

- **Example**:

  ```csharp

  public class BaseClass

  {

      protected string ProtectedData = "Protected Data";

      protected void ShowData()

      {

          Console.WriteLine($"Data: {ProtectedData}");

      }

  }

  public class DerivedClass : BaseClass

  {

      public void AccessProtectedData()

      {

          Console.WriteLine(ProtectedData); // Accessible in derived class

          ShowData(); // Accessible in derived class

      }

  }

  var derived = new DerivedClass();

  derived.AccessProtectedData(); // Works fine

  // derived.ProtectedData; // Error: Not accessible outside the class hierarchy

  ```

- **Edge Case**: `protected` members are not accessible outside the class hierarchy, even if the derived class is instantiated.

---

### **`internal`**

- **Description**: Members declared as `internal` are accessible only within the same assembly.

- **Example**:

  ```csharp

  internal class InternalExample

  {

      internal string InternalData = "Internal Data";

      internal void ShowData()

      {

          Console.WriteLine($"Data: {InternalData}");

      }

  }

  // Accessible within the same assembly

  var example = new InternalExample();

  example.ShowData(); // Works fine

  ```

- **Edge Case**: If the assembly is shared, all code within that assembly can access `internal` members, which might expose sensitive data unintentionally.

---

### **`protected internal`**

- **Description**: Members declared as `protected internal` are accessible within the same assembly or from derived classes in other assemblies.

- **Example**:

  ```csharp

  public class ProtectedInternalExample

  {

      protected internal string Data = "Protected Internal Data";

      protected internal void ShowData()

      {

          Console.WriteLine($"Data: {Data}");

      }

  }

  public class DerivedClass : ProtectedInternalExample

  {

      public void AccessData()

      {

          Console.WriteLine(Data); // Accessible in derived class

          ShowData(); // Accessible in derived class

      }

  }

  // Within the same assembly

  var example = new ProtectedInternalExample();

  example.ShowData(); // Works fine

  ```

- **Edge Case**: If the derived class is in another assembly, the `protected internal` member is accessible only through inheritance, not directly.

---

### **Summary Table**

| **Modifier**         | **Same Class** | **Derived Class (Same Assembly)** | **Other Classes (Same Assembly)** | **Derived Class (Other Assembly)** | **Other Classes (Other Assembly)** |
|-----------------------|----------------|------------------------------------|------------------------------------|-------------------------------------|-------------------------------------|
| `public`             | ✅             | ✅                                 | ✅                                 | ✅                                  | ✅                                  |
| `private`            | ✅             | ❌                                 | ❌                                 | ❌                                  | ❌                                  |
| `protected`          | ✅             | ✅                                 | ❌                                 | ✅                                  | ❌                                  |
| `internal`           | ✅             | ✅                                 | ✅                                 | ❌                                  | ❌                                  |
| `protected internal` | ✅             | ✅                                 | ✅                                 | ✅                                  | ❌                                  |

--- 
