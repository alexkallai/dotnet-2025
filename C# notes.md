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


<br><br>

# **1. Access Modifiers** in detail

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

<br><br>

# **3. Control Flow** in detail

Control flow keywords in C# are used to dictate the execution path of a program. Below are examples and edge cases for each keyword:

---

### **Conditionals**

#### **`if` and `else`**

- **Description**: Executes a block of code if a condition is true; otherwise, executes the `else` block.

- **Example**:

  ```csharp

  int number = 10;

  if (number > 5)

  {

      Console.WriteLine("Number is greater than 5");

  }

  else

  {

      Console.WriteLine("Number is 5 or less");

  }

  ```

- **Edge Case**: Ensure the condition is not ambiguous (e.g., avoid using floating-point comparisons due to precision issues) [[1]](690a05cb19377a2c24b73311).

#### **`switch` and `case`**

- **Description**: Evaluates an expression and executes the matching `case` block.

- **Example**:

  ```csharp

  int day = 3;

  switch (day)

  {

      case 1:

          Console.WriteLine("Monday");

          break;

      case 2:

          Console.WriteLine("Tuesday");

          break;

      case 3:

          Console.WriteLine("Wednesday");

          break;

      default:

          Console.WriteLine("Invalid day");

          break;

  }

  ```

- **Edge Case**: Forgetting the `break` statement can cause fall-through behaviour, which might lead to unintended execution [[2]](690a05cb19377a2c24b73312).

---

### **Loops**

#### **`for`**

- **Description**: Executes a block of code a specific number of times.

- **Example**:

  ```csharp

  for (int i = 0; i < 5; i++)

  {

      Console.WriteLine($"Iteration:  i ");

  }

  ```

- **Edge Case**: Ensure the loop condition prevents infinite loops (e.g., incorrect increment/decrement logic) [[3]](690a05cb19377a2c24b73313).

#### **`foreach`**

- **Description**: Iterates over each element in a collection.

- **Example**:

  ```csharp

  string[] fruits = { "Apple", "Banana", "Cherry" };

  foreach (string fruit in fruits)

  {

      Console.WriteLine(fruit);

  }

  ```

- **Edge Case**: Modifying the collection during iteration can throw an exception [[4]](690a05cb19377a2c24b73314).

#### **`while`**

- **Description**: Executes a block of code as long as the condition is true.

- **Example**:

  ```csharp

  int count = 0;

  while (count < 3)

  {

      Console.WriteLine($"Count:  count ");

      count++;

  }

  ```

- **Edge Case**: Ensure the condition eventually becomes false to avoid infinite loops [[5]](690a05cb19377a2c24b73315).

#### **`do`**

- **Description**: Executes a block of code at least once, then continues while the condition is true.

- **Example**:

  ```csharp

  int count = 0;

  do

  {

      Console.WriteLine($"Count:  count ");

      count++;

  } while (count < 3);

  ```

- **Edge Case**: The block always executes at least once, even if the condition is false initially [[6]](690a05cb19377a2c24b73316).

#### **`break`**

- **Description**: Exits the nearest enclosing loop or `switch` statement.

- **Example**:

  ```csharp

  for (int i = 0; i < 10; i++)

  {

      if (i == 5)

      {

          break;

      }

      Console.WriteLine(i);

  }

  ```

- **Edge Case**: Use carefully to avoid prematurely exiting loops unintentionally [[7]](690a05cb19377a2c24b73317).

#### **`continue`**

- **Description**: Skips the current iteration and moves to the next iteration of the loop.

- **Example**:

  ```csharp

  for (int i = 0; i < 5; i++)

  {

      if (i == 2)

      {

          continue;

      }

      Console.WriteLine(i);

  }

  ```

- **Edge Case**: Ensure the skipped iteration does not cause logical errors in subsequent iterations [[8]](690a05cb19377a2c24b73318).

---

### **Jump Statements**

#### **`return`**

- **Description**: Exits from the current method and optionally returns a value.

- **Example**:

  ```csharp

  int Add(int a, int b)

  {

      return a + b;

  }

  Console.WriteLine(Add(3, 4)); // Outputs: 7

  ```

- **Edge Case**: Ensure all code paths in a method return a value if the method has a return type [[9]](690a05cb19377a2c24b73319).

#### **`goto`**

- **Description**: Transfers control to a labelled statement.

- **Example**:

  ```csharp

  int number = 5;

  if (number > 0)

  {

      goto Positive;

  }

  Console.WriteLine("This will not execute");

  Positive:

  Console.WriteLine("Number is positive");

  ```

- **Edge Case**: Overuse of `goto` can make code difficult to read and maintain [[10]](690a05cb19377a2c24b7331a).

#### **`throw`**

- **Description**: Throws an exception.

- **Example**:

  ```csharp

  void ValidateAge(int age)

  {

      if (age < 18)

      {

          throw new ArgumentException("Age must be 18 or older");

      }

  }

  try

  {

      ValidateAge(16);

  }

  catch (Exception ex)

  {

      Console.WriteLine(ex.Message);

  }

  ```

- **Edge Case**: Avoid throwing exceptions for normal control flow; use them for exceptional cases only [[11]](690a05cb19377a2c24b7331b).

#### **`yield`**

- **Description**: Returns an element to the caller in an iterator method.

- **Example**:

  ```csharp

  IEnumerable<int> GetNumbers()

  {

      for (int i = 0; i < 5; i++)

      {

          yield return i;

      }

  }

  foreach (var number in GetNumbers())

  {

      Console.WriteLine(number);

  }

  ```

- **Edge Case**: Using `yield` in non-iterator methods will result in a compile-time error [[12]](690a05cb19377a2c24b7331c).

---

### **Other Control Flow Keywords**

#### **`try`, `catch`, `finally`**

- **Description**: Handles exceptions and ensures cleanup code is executed.

- **Example**:

  ```csharp

  try

  {

      int result = 10 / 0;

  }

  catch (DivideByZeroException ex)

  {

      Console.WriteLine("Cannot divide by zero");

  }

  finally

  {

      Console.WriteLine("Cleanup code executed");

  }

  ```

- **Edge Case**: Avoid catching general exceptions (e.g., `Exception`) unless necessary [[13]](690a05cb19377a2c24b7331d).

#### **`lock`**

- **Description**: Ensures that a block of code is executed by only one thread at a time.

- **Example**:

  ```csharp

  private static readonly object _lock = new object();

  void CriticalSection()

  {

      lock (_lock)

      {

          Console.WriteLine("Thread-safe operation");

      }

  }

  ```

- **Edge Case**: Deadlocks can occur if multiple threads lock resources in different orders [[14]](690a05cb19377a2c24b7331e).

---

### **Summary Table**

| **Keyword**   | **Purpose**                                                                 |

|---------------|-----------------------------------------------------------------------------|

| `if`, `else`  | Conditional execution based on a boolean expression.                       |

| `switch`, `case` | Multi-way branching based on a single expression.                       |

| `for`, `foreach`, `while`, `do` | Looping constructs for repeated execution.               |

| `break`       | Exits the nearest enclosing loop or `switch`.                              |

| `continue`    | Skips the current iteration of a loop.                                     |

| `return`      | Exits a method and optionally returns a value.                             |

| `goto`        | Transfers control to a labelled statement.                                 |

| `throw`       | Throws an exception.                                                      |

| `yield`       | Returns elements one at a time in an iterator method.                      |

| `try`, `catch`, `finally` | Handles exceptions and ensures cleanup code is executed.       |

| `lock`        | Ensures thread-safe execution of a code block.                             |

Let me know if you need further clarification or additional examples!

```