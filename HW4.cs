/*
01 Introduction to C# and Data Types – Questions
1.	What type would you choose for the following “numbers”?
o	A person’s telephone number
String

o	A person’s height
double

o	A person’s age
byte

o	A person’s gender (Male, Female, Prefer Not To Answer)
enum

o	A person’s salary
decimal

o	A book’s ISBN
String

o	A book’s price
decimal

o	A book’s shipping weight
double

o	A country’s population
long

o	The number of stars in the universe
BigInteger

o	The number of employees in each of the small or medium businesses in the United Kingdom (up to about 50,000 employees per business)
ushort

2.	What are the differences between value type and reference type variables?
Value type store data directly on the stack while reference type store reference on the stack, the data is stored on the heap.
When you do the copy, value type will copy the value and changing copy won’t affect the value. While reference type will change the original value because all the data point to the same memory address. 

3.	What is meant by the terms managed resource and unmanaged resource in .NET?
managed resource can be managed by CLR and garbage collector like c# object.
unmanaged resource are outside of CLR that garbage collector cannot release the resource like file handles, network sockets.

4.	What is the purpose of the Garbage Collector in .NET?
Garbage Collector can automatically manage memory after the lifetime of objects. It can prevent memory leak and optimize the program. Developers don’t need to manually allocate memory. 

Controlling Flow and Converting Types – Questions
1.	What happens when you divide an int variable by 0?
it will throw DivideByZeroException

2.	What happens when you divide a double variable by 0?
a positive double divided by 0 will get infinity
a negative double divided by 0 will get negative infinity
0 divided by 0 will get NaN

3.	What happens when you overflow an int variable (assign a value beyond its range)?
it will wrap around to the opposite end of the range.

4.	What is the difference between x = y++; and x = ++y;?
x = y++; will assign x=y then increment
x = ++y, will increment y first, then assign x=y

5.	What is the difference between break, continue, and return when used inside a loop statement?
break will jump out of loop immediately 
Continue will skip the current iteration and moves to next iteration
Return will jump out of the function return to caller

6.	What are the three parts of a for statement and which of them are required?
initialization, condition, iteration
Noe of them are required to run for statement.

7.	What is the difference between the = and == operators?
= used to assign value 
== is the equality operator to check if two value are equal

8.	Does the following statement compile? for ( ; true; ) ;
Yes, it’s an infinite loop

9.	What interface must an object implement to be enumerated by the foreach statement?
IEnumerable interface must be implemented so foreach can iterate, for build-in collections like array, list, .NET has already implemented iEnumerable, so developers don’t need to implement.

*/




// Coding：
// 1. How can we find the minimum and maximum values, as well as the number of bytes, for the following data types: sbyte, byte, short, ushort, int, uint, long, ulong, float, double, and decimal?

using System.Runtime.InteropServices;

class Question1
{
    public static void Property()
    {
        Console.WriteLine("For sbyte, Min =  " + sbyte.MinValue + ", Max = " + sbyte.MaxValue + ", size is " + sizeof(sbyte) + " bytes");
        Console.WriteLine("For byte, Min = " + byte.MinValue + ", Max = " + byte.MaxValue + ", size = " + sizeof(byte) + " bytes");
        Console.WriteLine("For short, Min = " + short.MinValue + ", Max = " + short.MaxValue + ", size = " + sizeof(short) + " bytes");
        Console.WriteLine("For ushort, Min = " + ushort.MinValue + ", Max = " + ushort.MaxValue + ", size = " + sizeof(ushort) + " bytes");
        Console.WriteLine("For int, Min = " + int.MinValue + ", Max = " + int.MaxValue + ", size = " + sizeof(int) + " bytes");
        Console.WriteLine("For uint, Min = " + uint.MinValue + ", Max = " + uint.MaxValue + ", size = " + sizeof(uint) + " bytes");
        Console.WriteLine("For long, Min = " + long.MinValue + ", Max = " + long.MaxValue + ", size = " + sizeof(long) + " bytes");
        Console.WriteLine("For ulong, Min = " + ulong.MinValue + ", Max = " + ulong.MaxValue + ", size = " + sizeof(ulong) + " bytes");
        Console.WriteLine("For float, Min = " + float.MinValue + ", Max = " + float.MaxValue + ", size = " + sizeof(float) + " bytes");
        Console.WriteLine("For double, Min = " + double.MinValue + ", Max = " + double.MaxValue + ", size = " + sizeof(double) + " bytes");
        Console.WriteLine("For decimal, Min = " + decimal.MinValue + ", Max = " + decimal.MaxValue + ", size = " + sizeof(decimal) + " bytes");
    }
}


// 2. Write a method in C# called FizzBuzz that takes an integer num and prints numbers from 1 up to num, but:
// Print Fizz if the number is divisible by 3.
// Print Buzz if the number is divisible by 5.
// Print FizzBuzz if the number is divisible by both 3 and 5.
// Otherwise, print the number itself.

class Question2
{
    public static void FizzBuzz(int num)
    {
        for (int i = 1; i <= num; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}

// 3. What will happen if this code executes?
// int max = 500;
// for (byte i = 0; i < max; i++)
// {
//     Console.WriteLine(i);
// }
/*
Since the up bound of byte is 255, i in loop will always smaller than 500, it's an infinite loop. 
i will jump to 0 after increment from 255. so the code will print from 0 to 255 infinitely
*/



// 4. Two Sum
// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
// You may assume that each input would have exactly one solution.
// You may not use the same element twice.
// You can return the answer in any order.
class Question4
{
    public static (int, int) TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    Console.WriteLine($"answer is {nums[i]},{nums[j]}");
                    return (nums[i], nums[j]);
                }
            }
        }
        return (0, 0);
    }
}

class Program
{
    static void Main()
    {
        Question1.Property();
        Question2.FizzBuzz(15);

        int[] nums = [5, 4, 2, 1, 7, 9, 10, 3, 15];
        int target = 18;
        Question4.TwoSum(nums, target);

    }
}

/*
Interview Questions 
*Please make sure you fully understand both the interview question and your answer 
What is the purpose of the params keyword? Can you give a practical example?
The params keyword in C# allows a method to accept a variable number of arguments of a specific type.
Instead of forcing the caller to explicitly create and pass an array, they can just pass a comma-separated list of arguments. The compiler automatically bundles those arguments into an array behind the scenes.
static double CalculateTotal(string customerName, params double[] prices)
    {
        Console.WriteLine($"Calculating total for {customerName}...");
        double total = 0;
        
        foreach (double price in prices)
        {
            total += price;
        }
        
        return total;
    }


What is the difference between value types and reference types in C#? Can you explain how boxing and unboxing work?
Value Types: Store the actual data directly. Typically live on the Stack. Assignment copies the data (changes to the copy do not affect the original). Examples: int, bool, struct.
Reference Types: Store a memory address (pointer). The actual data lives on the Heap. Assignment copies the pointer (both variables point to the same data). Examples: class, string, array.
Boxing is the implicit conversion of a value type (like an int) to a reference type (object), where the CLR allocates memory on the managed heap and copies the value from the stack into it. Unboxing is the reverse process—an explicit cast that verifies the object's type and copies the value back from the heap onto the stack.


What is the difference between nullable value types and nullable reference types?
Nullable Value Types (e.g., int?) change the runtime structure by wrapping the value type in a System.Nullable<T> struct to allow primitive types to represent a null state, whereas Nullable Reference Types (e.g., string?) are a compile-time safety feature that introduces no runtime changes or memory overhead. Because reference types are already inherently capable of being null, the compiler simply uses static analysis and metadata attributes to generate warnings that prevent NullReferenceException errors without altering the compiled code. In short, nullable value types are a runtime reality that changes the underlying data type, while nullable reference types are a compiler tool designed purely for API design safety.


Can you explain some new features introduced in C# 7, 8, 9, and 10?
C# 7: Code Cleanliness & Data Handling
Tuples & Deconstruction: Return multiple values from a method cleanly without custom types (var (id, name) = GetUser();).
Out Variables: Declare out variables inline directly inside the method call (if (int.TryParse(s, out int result))).
Local Functions: Nest private helper functions inside another method to restrict their scope.

C# 8: Safety & Expressive Syntax
Nullable Reference Types: Enforces compile-time null safety to prevent NullReferenceException bugs.
Switch Expressions: Streamlined, functional syntax for pattern matching using the lambda arrow (=>).
Async Streams: Process data streams asynchronously using IAsyncEnumerable<T> and await foreach.

C# 9: Immutability & Less Boilerplate
Records: Immutable reference types designed for data structures, featuring built-in value-based equality.
Init-Only Setters: Allows properties to be set during object initialization but makes them read-only afterward.
Top-Level Statements: Removes the boilerplate Main method, class, and namespace wrapper from the program's entry file.

C# 10: Global Scope & File Optimization
Global Using Directives: Define a project-wide namespace import in a single file to eliminate repeating using lines.
File-Scoped Namespaces: Removes the nesting curly braces for namespaces, reducing indentation across files.
Record Structs: Brings the value-based equality and conciseness of C# 9 records to value types (struct).



What is the Garbage Collector in .NET? What problem does it solve?
The Garbage Collector (GC) in .NET is an automatic memory management engine. It acts as an automated custodian for your application's memory, specifically managing the Managed Heap (where reference types live).

What Problem Does It Solve?
In older languages like C or C++, developers must manually manage memory: allocating it using malloc or new and explicitly freeing it using free or delete. Manual memory management is highly error-prone and leads to two severe problems:
Memory Leaks: Forgetting to free memory after you are done with it. Over time, the app consumes more and more RAM until it crashes.
Dangling Pointers / Dangling References: Freeing memory too early while another part of the program is still trying to read or write to it, causing data corruption or unpredictable crashes.


What is the Garbage Collector? What is its purpose? What are the different generations of the Garbage Collector?
The Garbage Collector (GC) in .NET is an automatic memory management engine that acts as a custodian for your application's memory, specifically managing the Managed Heap where reference types live.

Purpose: What Problem Does It Solve?
In languages like C or C++, developers must manually allocate and free memory. This frequently leads to bugs like memory leaks (forgetting to release memory) or dangling pointers (releasing memory while it's still in use).

The GC eliminates these issues by:
Automatically reclaiming memory occupied by objects that are no longer being used by the application.
Allocating objects on the managed heap efficiently.
Compacting the heap to prevent memory fragmentation.

The Generations of the Garbage Collector
To optimize performance, the .NET GC uses a generational mechanism. Instead of inspecting every single object in memory during every cleanup (which is incredibly slow), it divides the heap into three generations based on an object's lifespan. The core assumption is that "new objects tend to die young."

1. Generation 0 (Gen 0)
What it holds: This is the youngest generation and contains short-lived objects. Almost all newly allocated objects start here (except for large objects).
Behavior: Local variables created inside a method live and die here. Garbage collection happens here most frequently because Gen 0 is small and takes very little time to clean.

2. Generation 1 (Gen 1)
What it holds: This acts as a buffer layer between short-lived and long-lived objects.
Behavior: If the GC runs a collection on Gen 0 and finds an object that is still being actively used, that object survives and is promoted to Gen 1.

3. Generation 2 (Gen 2)
What it holds: This contains long-lived objects.
Behavior: If an object survives a Gen 1 collection, it is promoted to Gen 2. This includes things like application-wide configuration data, singletons, or static variables that stay alive for the entire duration of the process. Collection here (often called a Full GC) is expensive and happens least frequently because it requires scanning a large amount of memory.


What is IDisposable? When should a class implement it?
IDisposable is a built-in interface in .NET (System namespace) that contains a single method: void Dispose(). Its core purpose is to provide a deterministic mechanism for releasing unmanaged resources before the Garbage Collector (GC) automatically reclaims the memory.
You should implement IDisposable whenever your class directly or indirectly owns resources that the .NET Garbage Collector cannot track or clean up on its own.


What are managed and unmanaged resources in .NET?
Managed resources are everything that the .NET Garbage Collector (GC) directly tracks, allocates, and reclaims.
Unmanaged resources are resources that are allocated outside the .NET runtime environment. They are typically provided directly by the operating system or third-party native libraries.


What is the difference between .NET Framework and .NET Core or modern .NET?
.NET Framework is a legacy, proprietary, Windows-only development platform that is now stagnant (capped at version 4.8.x) and receives only security maintenance.
NET Core (and modern .NET 5 through 10+) is a fully open-source, ultra-high-performance, cross-platform rewrite designed from the ground up for modern cloud-native architectures like Docker and Kubernetes.


What is the difference between string and StringBuilder? When would you choose one over the other?
The core difference between string and StringBuilder lies in mutability, which directly impacts memory allocation and application performance.
Choose string when:
The text is static or rarely changes: Standard variables, constants, configuration mappings, or simple logging entries.
You are combining a fixed number of strings: If you write string path = "C:\\" + folder + "\\" + file;, the C# compiler internally converts this into a single String.Concat() operation. It allocates memory once and is exceptionally fast.
Readability is key: String interpolation ($"Hello, {name}") is cleaner and easier to read than chaining sequential .Append() calls.
Choose StringBuilder when:
You are modifying text inside a loop: Doing str += text inside a large loop creates thousands of orphaned string objects on the heap, triggering frequent and expensive Garbage Collection (GC) pauses.
The number of concatenations is dynamic or unknown at compile-time: (e.g., parsing a complex CSV data stream line by line, or assembling an SQL query dynamically based on varying runtime filters).
You are building large documents: Generating vast payloads like massive XML strings, JSON responses, or dynamic HTML bodies.


How do the different GC generations work, and why do they exist?
The Generational Garbage Collector (GC) exists to optimize memory management based on the fact that most objects die young. Instead of scanning the entire heap during every collection, the GC divides memory into three generations based on object lifespans, allowing it to perform fast cleanups where it matters most. Gen 0 holds brand-new, short-lived objects (like local variables) and is collected frequently and cheaply. Objects that survive a collection are promoted to Gen 1 (a transitional buffer) and eventually to Gen 2, which holds long-lived data like application singletons. Because scanning Gen 2 requires a heavy, full-heap sweep, it is collected least frequently.


What is the difference between var, dynamic, and explicitly typed variables?
The difference between var, dynamic, and explicitly typed variables lies entirely in when the type is determined (compile-time vs. runtime) and how type safety is enforced.
var (Implicitly Typed) (var name = "Alice";)
Type Resolved: At compile-time (inferred from the value on the right).
Type Flexibility: Fixed. Once inferred, the type can never change.
Safety: High. It behaves identically to an explicitly typed variable.
IntelliSense: Fully supported with auto-complete.
Best For: Simplifying long, complex types (like LINQ or Generics).

dynamic (dynamic name = "Alice";)
Type Resolved: At runtime.
Type Flexibility: Fluid. The variable can change its data type freely at any time.
Safety: Low. Bypasses compiler checks; typos or invalid calls crash at runtime.
IntelliSense: Not supported (compiler does not know what properties exist).
Best For: COM interop, reflection, or parsing unpredictable JSON payloads.

Explicitly Typed (string name = "Alice";)
Type Resolved: At compile-time.
Type Flexibility: Fixed. The variable can never change its data type.
Safety: High. The compiler blocks invalid methods or type assignments.
IntelliSense: Fully supported with auto-complete.
Best For: Standard, explicit variable declarations.


What is the difference between ref, out, and in parameters? When would you use each?
The ref, out, and in keywords in C# allow you to pass arguments to methods by reference (sharing the original memory location) rather than by value (making a copy). The out keyword is used when a method needs to return multiple outputs; the variable passed does not need to be initialized beforehand, but the method must assign a value to it before returning. In contrast, the ref keyword is used for bidirectional communication where a variable must be fully initialized before the call, allowing the method to both read its incoming value and modify it in-place.
The in keyword acts as a read-only reference parameter, meaning the argument must be initialized before the call, but the method is strictly prohibited from modifying it. This is primarily a performance optimization tool used when passing large custom value types (structs), as it avoids the CPU and memory overhead of copying massive data structures while guaranteeing that the original data remains safe from accidental alteration. In short, choose out to send data out of a method, ref to modify existing data inside a method, and in to pass large data efficiently without allowing modifications.


What is the IDisposable interface and its Dispose() method? Does it depend on the Garbage Collector? Where would you use IDisposable?
The IDisposable interface and its Dispose() method provide a deterministic way to release unmanaged resources (like file handles, database connections, and network sockets) that live outside the control of the .NET runtime. Because the operating system controls these resources, failing to release them explicitly can cause memory leaks, file locking, or network exhaustion before the application terminates.
IDisposable does not depend on the Garbage Collector (GC) to execute; its entire purpose is to bypass the GC's unpredictable schedule. The GC runs non-deterministically whenever memory pressure dictates, whereas calling Dispose() immediately returns resources to the OS the moment you are done. The only intersection with the GC is a "Finalizer" fallback—if a developer forgets to call Dispose(), the GC will eventually call the finalizer during a collection cycle to clean up the unmanaged resource.
You should implement IDisposable whenever your class directly wraps an OS handle, or indirectly owns other disposable objects (like an internal SqlConnection or HttpClient). To safely consume these classes, developers wrap them in a using statement, which guarantees that Dispose() is automatically executed the moment the block exits, even if an unexpected runtime exception is thrown.


What is the difference between the using statement and the using directive in C#?
The difference between the two lies in whether you are importing a namespace or managing resource cleanup.
The using Directive: Used at the very top of a code file to import a namespace so you don't have to type out full paths.
The using Statement (or Declaration): Used inside methods to guarantee the automatic cleanup of an IDisposable object (like a file stream or database connection). It ensures .Dispose() is called as soon as the block exits, even if an exception occurs.



What are access modifiers in C#? How do public, private, protected, internal, protected internal, and private protected differ?
Access modifiers in C# are keywords used to define the visibility and accessibility of classes, methods, properties, and other members.
public: The type or member can be accessed by any other code in the same assembly or another assembly that references it.  
private: The type or member can be accessed only by code in the same class or struct.  
protected: The type or member can be accessed only by code in the same class, or in a class that is derived from that class.
internal: The type or member can be accessed by any code in the same assembly, but not from another assembly.
protected internal: The type or member can be accessed by any code in the assembly in which it's declared, or from within a derived class in another assembly.
private protected: The type or member can be accessed by types derived from the containing class, but only within its containing assembly.


What is the difference between method overloading and method overriding?
Method overloading occurs when multiple methods in the same class have the same name but different parameters (compile-time polymorphism). The compiler chooses the correct method at compile-time based on the arguments you pass in.
Method overriding occurs when a child class provides a custom implementation for a method inherited from a parent class (runtime polymorphism). The parent method must be marked virtual or abstract, the child method must use override, and the execution is decided at runtime based on the actual object type.

What is the difference between an array and a List<T>? When would you choose each?
The core difference between an array and a List<T> lies in size flexibility and memory management.Array (T[]) is Fixed Size,List<T> is Dynamic Size. 
Choose an array (T[]) when your data size is strictly fixed and known beforehand (e.g., coordinates or months of the year), or when you need peak performance and minimal memory overhead. Its rigid structure makes it ideal for raw data processing, multi-dimensional structures, and low-level optimizations.
Choose a List<T> when you need a dynamic, flexible collection that can shrink or grow as data changes, such as when pulling an unknown number of records from a database. It is the go-to choice for standard business logic due to its powerful built-in utility methods like .Add() and seamless LINQ integration.

*/