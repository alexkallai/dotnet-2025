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

<br><br>

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
  ```

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

<br><br>

## **5. Object-Oriented Programming** in detail

Object-Oriented Programming (OOP) in C# revolves around defining classes, objects, and their behaviour. Below are examples and edge cases for the key OOP keywords:

---

### **Class and Object Keywords**

#### **`class`**

- **Description**: Defines a blueprint for creating objects.

- **Example**:

  ```csharp
  public class Person
   
      public string Name;
      public int Age;
      public void DisplayInfo()
       
          Console.WriteLine($"Name:  Name , Age:  Age ");
       
   
  var person = new Person();
  person.Name = "John";
  person.Age = 30;
  person.DisplayInfo(); // Outputs: Name: John, Age: 30
  ```

- **Edge Case**: Avoid creating overly large classes; use smaller, focused classes to maintain readability and reusability [[1]](690a06ed4ccfa2a2002c2ec9).

#### **`struct`**

- **Description**: Defines a value type that is typically used for small, lightweight objects.

- **Example**:

  ```csharp
  public struct Point
   
      public int X;
      public int Y;
      public Point(int x, int y)
       
          X = x;
          Y = y;
       
   
  var point = new Point(10, 20);
  Console.WriteLine($"Point: ( point.X ,  point.Y )"); // Outputs: Point: (10, 20)
  ```

- **Edge Case**: Structs do not support inheritance and are passed by value, which can lead to performance issues if used for large data [[3]](690a06ed4ccfa2a2002c2ee0).

#### **`interface`**

- **Description**: Defines a contract that implementing classes or structs must follow.

- **Example**:

  ```csharp
  public interface IShape
   
      void Draw();
   
  public class Circle : IShape
   
      public void Draw()
       
          Console.WriteLine("Drawing a Circle");
       
   
  IShape shape = new Circle();
  shape.Draw(); // Outputs: Drawing a Circle
  ```

- **Edge Case**: Interfaces cannot contain implementation (except default implementations in C# 8.0+) [[2]](690a06ed4ccfa2a2002c2ecf).

#### **`enum`**

- **Description**: Defines a set of named constants.

- **Example**:

  ```csharp
  public enum DaysOfWeek
   
      Sunday,
      Monday,
      Tuesday,
      Wednesday,
      Thursday,
      Friday,
      Saturday
   
  var today = DaysOfWeek.Monday;
  Console.WriteLine($"Today is:  today "); // Outputs: Today is: Monday
  ```

- **Edge Case**: Avoid assigning overlapping values to enum members unless intentional.

#### **`delegate`**

- **Description**: Represents a reference to a method.

- **Example**:

  ```csharp
  public delegate void PrintMessage(string message);
  public class Messenger
   
      public void Print(string message)
       
          Console.WriteLine(message);
       
   
  var messenger = new Messenger();
  PrintMessage print = messenger.Print;
  print("Hello, World!"); // Outputs: Hello, World!
  ```

- **Edge Case**: Be cautious of null delegates; always check before invoking.

---

### **Inheritance and Polymorphism**

#### **`abstract`**

- **Description**: Defines a class or method that must be implemented in derived classes.

- **Example**:

  ```csharp
  public abstract class Animal
   
      public abstract void Speak();
   
  public class Dog : Animal
   
      public override void Speak()
       
          Console.WriteLine("Woof!");
       
   
  Animal animal = new Dog();
  animal.Speak(); // Outputs: Woof!
  ```

- **Edge Case**: Abstract classes cannot be instantiated directly [[4]](690a06ed4ccfa2a2002c2ee5).

#### **`virtual` and `override`**

- **Description**: `virtual` allows a method to be overridden in a derived class; `override` provides the new implementation.

- **Example**:

  ```csharp
  public class BaseClass
   
      public virtual void Greet()
       
          Console.WriteLine("Hello from BaseClass");
       
   
  public class DerivedClass : BaseClass
   
      public override void Greet()
       
          Console.WriteLine("Hello from DerivedClass");
       
   
  BaseClass obj = new DerivedClass();
  obj.Greet(); // Outputs: Hello from DerivedClass
  ```

- **Edge Case**: Forgetting `override` in the derived class will not override the base method [[5]](690a06ed4ccfa2a2002c2ee6).

#### **`sealed`**

- **Description**: Prevents further inheritance of a class or method.

- **Example**:

  ```csharp
  public sealed class FinalClass
   
      public void Display()
       
          Console.WriteLine("This class cannot be inherited");
       
   
  // class DerivedClass : FinalClass // Error: Cannot derive from sealed class
  ```

- **Edge Case**: Overuse of `sealed` can limit extensibility.

#### **`base`**

- **Description**: Refers to the base class of the current class.

- **Example**:

  ```csharp
  public class Parent
   
      public virtual void Show()
       
          Console.WriteLine("Parent class");
       
   
  public class Child : Parent
   
      public override void Show()
       
          base.Show(); // Calls the base class method
          Console.WriteLine("Child class");
       
   
  var child = new Child();
  child.Show();
  // Outputs:
  // Parent class
  // Child class
  ```

- **Edge Case**: Ensure `base` is used only when necessary to avoid redundant calls.

#### **`this`**

- **Description**: Refers to the current instance of the class.

- **Example**:

  ```csharp
  public class Person
   
      private string name;
      public Person(string name)
       
          this.name = name;
       
      public void Display()
       
          Console.WriteLine($"Name:  this.name ");
       
   
  var person = new Person("Alice");
  person.Display(); // Outputs: Name: Alice
  ```

- **Edge Case**: Avoid overusing `this` when it is not required.

---

### **Access and Reference**

#### **`new`**

- **Description**: Creates a new instance of a class or hides a member in a derived class.

- **Example**:

  ```csharp
  public class BaseClass
   
      public void Display()
       
          Console.WriteLine("Base class method");
       
   
  public class DerivedClass : BaseClass
   
      public new void Display()
       
          Console.WriteLine("Derived class method");
       
   
  BaseClass obj = new DerivedClass();
  obj.Display(); // Outputs: Base class method
  ```

- **Edge Case**: Using `new` to hide a member can lead to confusion; prefer `override` when possible.

#### **`readonly`**

- **Description**: Declares a field that can only be assigned during declaration or in the constructor.

- **Example**:

  ```csharp
  public class Example
   
      public readonly int Value;
      public Example(int value)
       
          Value = value;
       
   
  var example = new Example(10);
  // example.Value = 20; // Error: Cannot modify readonly field
  ```

- **Edge Case**: `readonly` fields can still be modified via reflection, so use cautiously.

#### **`const`**

- **Description**: Declares a compile-time constant.

- **Example**:

  ```csharp
  public class Constants
   
      public const double Pi = 3.14159;
   
  Console.WriteLine($"Pi:  Constants.Pi "); // Outputs: Pi: 3.14159
  ```

- **Edge Case**: `const` values are replaced at compile time, so changing their value requires recompilation of dependent assemblies.

#### **`static`**

- **Description**: Declares a member that belongs to the type itself rather than an instance.

- **Example**:

  ```csharp
  public class MathUtils
   
      public static int Add(int a, int b)
       
          return a + b;
       
   
  Console.WriteLine(MathUtils.Add(3, 4)); // Outputs: 7
  ```

- **Edge Case**: Static members cannot access instance members directly.

---

### **Summary Table**

| **Keyword**       | **Purpose**                                                                 |
|-------------------|-----------------------------------------------------------------------------|
| `class`           | Defines a blueprint for objects.                                           |
| `struct`          | Defines a value type for lightweight objects.                              |
| `interface`       | Defines a contract for classes or structs.                                 |
| `enum`            | Defines a set of named constants.                                          |
| `delegate`        | Represents a reference to a method.                                        |
| `abstract`        | Defines a class or method to be implemented in derived classes.            |
| `virtual`         | Allows a method to be overridden in derived classes.                       |
| `override`        | Provides a new implementation for a virtual method.                       |
| `sealed`          | Prevents further inheritance of a class or method.                        |
| `base`            | Refers to the base class of the current class.                             |
| `this`            | Refers to the current instance of the class.                               |
| `new`             | Creates a new instance or hides a member in a derived class.               |
| `readonly`        | Declares a field that can only be assigned during declaration or in a constructor. |
| `const`           | Declares a compile-time constant.                                          |
| `static`          | Declares a member that belongs to the type itself.                         |

<br>
<br>

## **6. Namespace and Assembly** in detail

In C#, namespaces and assemblies are used to organise code and manage scope. Below are examples and edge cases for the relevant keywords:

---

### **`namespace`**

- **Description**: Used to organise code into logical groups and prevent name conflicts.

- **Example**:

  ```csharp
  namespace MyApplication.Utilities
   
      public class MathHelper
       
          public static int Add(int a, int b)
           
              return a + b;
           
       
   
  namespace MyApplication.Main
   
      using MyApplication.Utilities;
      public class Program
       
          public static void Main()
           
              int result = MathHelper.Add(5, 10);
              Console.WriteLine($"Result:  result "); // Outputs: Result: 15
           
       
  ```

- **Edge Case**: Avoid deeply nested namespaces as they can make code harder to read and maintain.

---

### **`using`**

- **Description**: Imports a namespace or provides a scope for resource management.

- **Example 1**: **Importing a Namespace**

  ```csharp
  using System;
  public class Program
   
      public static void Main()
       
          Console.WriteLine("Hello, World!");
       
  ```

- **Example 2**: **Resource Management**

  ```csharp
  using (var file = new System.IO.StreamWriter("example.txt"))
   
      file.WriteLine("This is a test.");
   
  // The file is automatically closed when exiting the `using` block.
  ```

- **Edge Case**: Forgetting to use `using` for resource management can lead to resource leaks, such as open file handles.

---

### **`extern`**

- **Description**: Declares a method or alias that is implemented externally, often used for interoperability with unmanaged code or external assemblies.

- **Example**:

  ```csharp
  using System.Runtime.InteropServices;
  class Program
   
      [DllImport("user32.dll")]
      public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
      public static void Main()
       
          MessageBox(IntPtr.Zero, "Hello, World!", "Message", 0);
       
  ```

- **Edge Case**: Ensure the external method exists and is compatible with the platform; otherwise, runtime errors will occur.

---

### **`assembly`**

- **Description**: Refers to a compiled code library (DLL or EXE) that contains metadata and code. It is the fundamental unit of deployment in .NET.

- **Example**: **Assembly Attribute**

  ```csharp
  using System.Reflection;
  [assembly: AssemblyTitle("My Application")]
  [assembly: AssemblyVersion("1.0.0.0")]
  public class Program
   
      public static void Main()
       
          Console.WriteLine("Assembly attributes set.");
       
  ```

- **Edge Case**: Incorrect assembly attributes (e.g., versioning) can cause issues with deployment and compatibility.

---

### **Summary Table**

| **Keyword**   | **Purpose**                                                                 |
|---------------|-----------------------------------------------------------------------------|
| `namespace`   | Organises code into logical groups and prevents name conflicts.             |
| `using`       | Imports namespaces or manages resources within a defined scope.            |
| `extern`      | Declares external methods or aliases for interoperability.                 |
| `assembly`    | Refers to a compiled code library and allows setting assembly attributes.   |

<br>
<br>

# **7. Modifiers** in detail

Modifiers in C# are used to alter the behaviour of declarations, such as variables, methods, or classes. Below are examples and edge cases for the key modifiers:

---

### **`const`**

- **Description**: Declares a compile-time constant. The value must be assigned at the time of declaration and cannot be changed later [[1]](690a0e86df96efc04e639bf8).

- **Example**:

  ```csharp
  public class Constants
  {
      public const double Pi = 3.14159;
      public void Display()
      {
          Console.WriteLine($"Value of Pi: {Pi}");
      }
  }
  var constants = new Constants();
  constants.Display(); // Outputs: Value of Pi: 3.14159
  ```

- **Edge Case**: `const` values are replaced at compile time. If a `const` value is changed, all dependent assemblies must be recompiled to reflect the updated value [[2]](690a0e86df96efc04e639be4).

---

### **`readonly`**

- **Description**: Declares a field that can only be assigned during its declaration or in the constructor. It is evaluated at runtime.

- **Example**:

  ```csharp
  public class ReadOnlyExample
  {
      public readonly int MaxValue;
      public ReadOnlyExample(int maxValue)
      {
          MaxValue = maxValue; // Can only be assigned here or during declaration
      }
  }
  var example = new ReadOnlyExample(100);
  Console.WriteLine(example.MaxValue); // Outputs: 100
  // example.MaxValue = 200; // Error: Cannot modify a readonly field
  ```

- **Edge Case**: Unlike `const`, `readonly` fields can have different values for each instance of a class.

---

### **`static`**

- **Description**: Declares a member that belongs to the type itself rather than an instance of the type.

- **Example**:

  ```csharp
  public class StaticExample
  {
      public static int Counter = 0;
      public static void IncrementCounter()
      {
          Counter++;
      }
  }
  StaticExample.IncrementCounter();
  Console.WriteLine(StaticExample.Counter); // Outputs: 1
  ```

- **Edge Case**: Static members cannot access instance members directly. Overusing static members can lead to tightly coupled code.

---

### **`volatile`**

- **Description**: Indicates that a field may be modified by multiple threads simultaneously. Prevents the compiler from optimising the code in a way that assumes the value does not change unexpectedly.

- **Example**:

  ```csharp
  public class VolatileExample
  {
      private volatile bool _isRunning;
      public void Stop()
      {
          _isRunning = false; // Ensures changes are visible across threads
      }
  }
  ```

- **Edge Case**: `volatile` only works with simple types (e.g., `int`, `bool`) and does not guarantee atomicity for compound operations like incrementing a value.

---

### **`async`**

- **Description**: Marks a method as asynchronous, allowing it to run asynchronously and return a `Task` or `Task<T>`.

- **Example**:

  ```csharp
  public async Task FetchDataAsync()
  {
      Console.WriteLine("Fetching data...");
      await Task.Delay(2000); // Simulates an asynchronous operation
      Console.WriteLine("Data fetched.");
  }
  var example = new Program();
  await example.FetchDataAsync();
  ```

- **Edge Case**: An `async` method must contain at least one `await` statement; otherwise, it will run synchronously and may cause confusion.

---

### **`await`**

- **Description**: Pauses the execution of an `async` method until the awaited `Task` is complete.

- **Example**:

  ```csharp
  public async Task ProcessDataAsync()
  {
      Console.WriteLine("Processing...");
      await Task.Delay(1000); // Waits for 1 second
      Console.WriteLine("Processing complete.");
  }
  await ProcessDataAsync();
  ```

- **Edge Case**: `await` can only be used inside an `async` method. Forgetting to use `await` on an asynchronous call can lead to unexpected behaviour, as the method will continue executing without waiting for the task to complete.

---

### **Summary Table**

| **Modifier**   | **Purpose**                                                                 |
|-----------------|-----------------------------------------------------------------------------|
| `const`         | Declares a compile-time constant.                                           |
| `readonly`      | Declares a field that can only be assigned during declaration or in a constructor. |
| `static`        | Declares a member that belongs to the type itself rather than an instance.  |
| `volatile`      | Ensures a field is not optimised by the compiler and is visible across threads. |
| `async`         | Marks a method as asynchronous, allowing it to return a `Task` or `Task<T>`. |
| `await`         | Pauses execution of an `async` method until the awaited `Task` is complete. |

<br>
<br>

# **9. Miscellaneous Keywords** in detail

### **`is`**

- **Description**: Checks if an object is compatible with a specific type.

- **Example**:

  ```csharp
  object obj = "Hello, World!";
  if (obj is string)
      Console.WriteLine("The object is a string.");
  ```

- **Edge Case**: `is` returns `false` for `null` values, even if the type matches [[1]](690a10caf626bc4a3fdaf6ff).

---

### **`as`**

- **Description**: Performs a safe type conversion. Returns `null` if the conversion fails instead of throwing an exception.

- **Example**:

  ```csharp
  object obj = "Hello, World!";
  string str = obj as string;
  if (str != null)
      Console.WriteLine($"String value: {str}");
  ```

- **Edge Case**: Use `as` only with reference types or nullable types. For value types, use explicit casting [[1]](690a10caf626bc4a3fdaf6ff).

---

### **`typeof`**

- **Description**: Gets the `Type` object for a specified type.

- **Example**:

  ```csharp
  Type type = typeof(int);
  Console.WriteLine(type.FullName); // Outputs: System.Int32
  ```

- **Edge Case**: Use `GetType()` for runtime type checking of an object instance instead of `typeof`.

---

### **`sizeof`**

- **Description**: Gets the size (in bytes) of a value type.

- **Example**:

  ```csharp
  unsafe
  {
      Console.WriteLine($"Size of int: {sizeof(int)}"); // Outputs: Size of int: 4
  }
  ```

- **Edge Case**: `sizeof` can only be used in an `unsafe` context for custom structs.

---

### **`checked` / `unchecked`**

- **Description**: Controls overflow checking for arithmetic operations.

- **Example**:

  ```csharp
  int max = int.MaxValue;
  try
  {
      int result = checked(max + 1); // Throws OverflowException
  }
  catch (OverflowException)
  {
      Console.WriteLine("Overflow occurred.");
  }
  int uncheckedResult = unchecked(max + 1); // No exception, wraps around
  Console.WriteLine(uncheckedResult); // Outputs: -2147483648
  ```

- **Edge Case**: Use `checked` for critical calculations to avoid silent overflows.

---

### **`lock`**

- **Description**: Ensures that a block of code is executed by only one thread at a time.

- **Example**:

  ```csharp
  private static readonly object _lock = new object();
  void CriticalSection()
  {
      lock (_lock)
      {
          Console.WriteLine("Thread-safe operation.");
      }
  }
  ```

- **Edge Case**: Deadlocks can occur if multiple threads lock resources in different orders.

---

### **`using`**

- **Description**: Manages resources or imports namespaces.

- **Example 1**: **Resource Management**

  ```csharp
  using (var file = new System.IO.StreamWriter("example.txt"))
  {
      file.WriteLine("This is a test.");
  }
  // The file is automatically closed when exiting the `using` block.
  ```

- **Example 2**: **Namespace Import**

  ```csharp
  using System;
  Console.WriteLine("Hello, World!");
  ```

- **Edge Case**: Forgetting to use `using` for resource management can lead to resource leaks [[2]](690a10caf626bc4a3fdaf707).

---

### **`fixed`**

- **Description**: Pins a variable in memory to prevent the garbage collector from moving it.

- **Example**:

  ```csharp
  unsafe
  {
      int[] numbers = new int[] { 1, 2, 3 };
      fixed (int* p = numbers)
      {
          Console.WriteLine(*p); // Outputs: 1
      }
  }
  ```

- **Edge Case**: Can only be used in an `unsafe` context and is limited to unmanaged types.

---

### **`unsafe`**

- **Description**: Allows the use of pointer types and unsafe code blocks.

- **Example**:

  ```csharp
  unsafe
  {
      int number = 42;
      int* p = &number;
      Console.WriteLine($"Value: {*p}"); // Outputs: Value: 42
  }
  ```

- **Edge Case**: Unsafe code can lead to memory corruption if not used carefully.

---

# **10. Contextual Keywords** in detail

### **`add` and `remove`**

- **Description**: Used to define custom event accessors.

- **Example**:

  ```csharp
  public class EventExample
  {
      private event EventHandler _myEvent;
      public event EventHandler MyEvent
      {
          add { _myEvent += value; }
          remove { _myEvent -= value; }
      }
  }
  ```

- **Edge Case**: Ensure proper handling of event subscriptions to avoid memory leaks.

---

### **`get` and `set`**

- **Description**: Define accessors for properties.

- **Example**:

  ```csharp
  public class PropertyExample
  {
      private int _value;
      public int Value
      {
          get { return _value; }
          set { _value = value; }
      }
  }
  ```

- **Edge Case**: Avoid complex logic in `get` and `set` to maintain property simplicity.

---

### **`partial`**

- **Description**: Allows a class, struct, or method to be split across multiple files.

- **Example**:

  ```csharp
  // File1.cs
  public partial class PartialClass
  {
      public void Method1() => Console.WriteLine("Method1");
  }
  // File2.cs
  public partial class PartialClass
  {
      public void Method2() => Console.WriteLine("Method2");
  }
  var obj = new PartialClass();
  obj.Method1();
  obj.Method2();
  ```

- **Edge Case**: Overuse of `partial` can make code harder to navigate.

---

### **`yield`**

- **Description**: Returns elements one at a time in an iterator method.

- **Example**:

  ```csharp
  public IEnumerable<int> GetNumbers()
  {
      for (int i = 0; i < 5; i++)
          yield return i;
  }
  foreach (var number in GetNumbers())
      Console.WriteLine(number);
  ```

- **Edge Case**: Using `yield` in non-iterator methods will result in a compile-time error.

---

### **`where`**

- **Description**: Specifies constraints on generic type parameters.

- **Example**:

  ```csharp
  public class GenericExample<T> where T : class
  {
      public T Value { get; set; }
  }
  ```

- **Edge Case**: Ensure constraints are meaningful to avoid unnecessary complexity.

---

### **`dynamic`**

- **Description**: Allows operations to be resolved at runtime instead of compile time.

- **Example**:

  ```csharp
  dynamic obj = "Hello, World!";
  Console.WriteLine(obj.Length); // Resolved at runtime
  ```

- **Edge Case**: Overuse of `dynamic` can lead to runtime errors that are hard to debug.

---

### **`global`**

- **Description**: Refers to the global namespace, avoiding conflicts with local namespaces.

- **Example**:

  ```csharp
  namespace MyNamespace
  {
      class Program
      {
          static void Main()
          {
              global::System.Console.WriteLine("Hello, World!");
          }
      }
  }
  ```

- **Edge Case**: Use `global` only when necessary to avoid confusion in namespace resolution.

---

### **Summary Table**

| **Keyword**   | **Purpose**                                                                 |
|---------------|-----------------------------------------------------------------------------|
| `is`          | Checks object compatibility with a type.                                   |
| `as`          | Performs safe type conversion.                                             |
| `typeof`      | Gets the `Type` object for a type.                                         |
| `sizeof`      | Gets the size of a value type.                                             |
| `checked`     | Enables overflow checking for arithmetic operations.                       |
| `unchecked`   | Disables overflow checking for arithmetic operations.                      |
| `lock`        | Ensures thread safety by locking a block of code.                          |
| `using`       | Manages resources or imports namespaces.                                   |
| `fixed`       | Pins a variable in memory to prevent garbage collection.                   |
| `unsafe`      | Allows unsafe code blocks for pointer manipulation.                        |
| `add`/`remove`| Define custom event accessors.                                             |
| `get`/`set`   | Define property accessors.                                                 |
| `partial`     | Splits a class, struct, or method across multiple files.                   |
| `yield`       | Returns elements one at a time in an iterator method.                      |
| `where`       | Specifies constraints on generic type parameters.                          |
| `dynamic`     | Allows runtime resolution of operations.                                   |
| `global`      | Refers to the global namespace to avoid conflicts.                         |


```