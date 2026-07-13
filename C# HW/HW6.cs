/*
Questions
1.	Describe the problem generics address.
Different variable types cannot use the same method with particular data type declaration. 
Generics can combine them into one generics method while keep type safety and performance.

2.	How would you create a list of strings, using the generic List class?
List<string> str = new List<string>();

3.	How many generic type parameters does the Dictionary class have?
The Dictionary class has two generic type parameters: TKey and TValue.

4.	True/False. When a generic class has multiple type parameters, they must all match.
False

5.	What method is used to add items to a List object?
Add()
Insert(index, item)

6.	Name two methods that cause items to be removed from a List.
Remove(item)
RemoveAt(index)
RemoveRange(index, count)
RemoveAll(Predicate<T> match)

7.	How do you indicate that a class has a generic type parameter?
Use <T>

8.	True/False. Generic classes can only have one generic type parameter.
False

9.	True/False. Generic type constraints limit what can be used for the generic type.
True

10.	True/False. Constraints let you use the methods of the thing you are constraining to.
True
*/


/*
Task 1:
Define a generic class called MyStack<T> with the following requirements:
1.	Use Stack<T> internally to store the data.
2.	Implement a Count() method that returns the number of elements in the stack.
3.	Implement a Pop() method that returns and removes the top element of the stack.
4.	Implement a Push(T obj) method that adds an element to the stack.
Finally, create an instance of MyStack<int>, push two integers into it, and print out the current number of elements in the stack.
*/

public class MyStack<T>
{
    private Stack<T> stack = new Stack<T>();
    public int Count()
    {
        return stack.Count;
    }

    public T Pop()
    {
        return stack.Pop();
    }

    public void Push(T obj)
    {
        stack.Push(obj);
    }

    public void PrintAll()
    {
        Console.WriteLine("Elements in stack:");
        foreach (T item in stack)
        {
            Console.WriteLine(item);
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        MyStack<int> numbers = new MyStack<int>();

        numbers.Push(5);
        numbers.Push(3);
        Console.WriteLine("Count: " + numbers.Count());
        numbers.PrintAll();
    }
}


/*
Task 2:
 Create a generic repository pattern in C# with the following requirements:
1.	Define a generic interface IGenericRepository<T> where T : class.

○	The interface should declare the following methods:

■	Add(T item)

■	Remove(T item)

■	Save()

■	IEnumerable<T> GetAll()

■	T GetById(int id)

2.	Implement a class GenericRepository<T> that inherits from IGenericRepository<T>.

○	Use a private List<T> field to store the data.
○	In the constructor, initialize the list as a new empty List<T>.
○	Provide method implementations for Add, Remove, GetAll, GetById. No actual implementation is needed for Save.
*/

public interface IGenericRepository<T> where T : class
{
    int Add(T item);
    int Remove(T item);
    int Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private List<T> newList;
    public GenericRepository()
    {
        newList = new List<T>();
    }

    public int Add(T item)
    {
        newList.Add(item);
        return 1;
    }

    public int Remove(T item)
    {
        if (newList != null)
        {
            newList.Remove(item);
            return 1;
        }
        return 0;
    }

    public int Save()
    {
        //No implement needed
        return 1;
    }

    public IEnumerable<T> GetAll()
    {
        return newList;
    }

    public T GetById(int id)
    {
        for (int i = 0; i < newList.Count; i++)
        {
            if (newList[i].ID == id)
            {
                return newList[i];
            }
        }
        return null;
    }
}


/*
What are generics in C#? Why are they preferred over using object?
Generics are placeholders (like <T>) that allow you to define classes, interfaces, or methods without specifying the exact data type they work with until they are actually instantiated. They decouple your logic from specific types, allowing you to write a single piece of code that can safely handle integers, strings, or custom objects.
Type Safety: Generics catch data type mismatches at compile-time. Using object requires dangerous runtime casting, which frequently leads to hidden InvalidCastException crashes.
Performance (No Boxing/Unboxing): When using object with value types (like int or float), the system must continuously convert data between the stack and the heap (boxing and unboxing). Generics completely eliminate this memory overhead, significantly increasing execution speed.
Code Cleanliness: Generics eliminate the need to clutter your code with messy explicit casting wrappers, making your code cleaner and much easier to read.


What are generics? Can you give examples of how you have used generics in your projects? What do generic constraints do?
In my custom budget tracking application, I used generics to build a centralized ApiResponse<T> wrapper to unify all backend API responses and used a generic data repository (Repository<T>) to handle standard CRUD operations uniformly for classes like Transaction and BudgetCategory.
Generic constraints (using the where keyword) act as strict guardrails that restrict the types that can be substituted into your generic placeholder. Instead of allowing any data type, constraints let you enforce that a type must be a class, a struct, have a parameterless constructor, or implement a specific interface, which enables the compiler to safely allow you to use methods and properties belonging to that constraint inside your generic code.


What is the difference between generic and non-generic collections? What are the different collection classes available in C#?
The core difference between generic and non-generic collections lies in type safety and performance:
Generic Collections (System.Collections.Generic): Are strongly typed using a placeholder (like List<T>). They catch type mismatches at compile-time and eliminate the performance overhead of boxing and unboxing when storing value types.
Non-Generic Collections (System.Collections): Store everything as the root object type. They require manual runtime casting, which risks throwing an InvalidCastException, and are slower because they force value types to be boxed onto the heap.
Collection classes in C#:
List<T> (Dynamic Array): This is the most widely used collection in C#. It acts as a dynamically resizing array that grows automatically as you add items. It is highly optimized for sequential data access and lookups by index, making it ideal for standard groups of items where elements can be duplicated and order matters.
Dictionary<TKey, TValue> (Hash Map): This collection stores data as distinct key-value pairs. It uses an internal hashing algorithm to map keys to their corresponding values, allowing for ultra-fast, near-instantaneous lookups, insertions, and deletions regardless of the collection's size. It is the go-to choice when you need to retrieve records using a unique identifier, like a database ID.
HashSet<T> (Unique Set): A HashSet<T> is an unordered collection that contains only unique elements. Like a dictionary, it leverages hashing behind the scenes, making it incredibly fast at checking whether a specific item already exists in the set. It is ideal for deduplicating data or performing mathematical set operations like unions, intersections, and differences.
Queue<T> (First-In, First-Out): A Queue<T> models a standard line or waiting list based on a FIFO (First-In, First-Out) architecture. Elements are added to the back of the queue using Enqueue and removed from the front using Dequeue. This structure is heavily utilized in background job processors, messaging systems, or print buffers where items must be handled in the exact order they arrived.
Stack<T> (Last-In, First-Out): A Stack<T> behaves like a physical stack of plates based on a LIFO (Last-In, First-Out) architecture. Elements are pushed onto the top of the stack and popped off the top when retrieved. Stacks are perfectly suited for tracking state history, parsing expressions, or managing "Undo/Redo" actions in applications.
LinkedList<T> (Doubly Linked List): Unlike a standard list, a LinkedList<T> consists of separate nodes where each node holds a data value and points directly to the next and previous nodes in memory. While it is slower for random access because you have to traverse the chain to find a specific index, it provides exceptionally fast, constant-time insertions and deletions at any point in the list.


What is the difference between value types and reference types in C#? Can you explain how boxing and unboxing work?
Value Types: Store the actual data directly. Typically live on the Stack. Assignment copies the data (changes to the copy do not affect the original). Examples: int, bool, struct.
Reference Types: Store a memory address (pointer). The actual data lives on the Heap. Assignment copies the pointer (both variables point to the same data). Examples: class, string, array.
Boxing is the implicit conversion of a value type (like an int) to a reference type (object), where the CLR allocates memory on the managed heap and copies the value from the stack into it. Unboxing is the reverse process—an explicit cast that verifies the object's type and copies the value back from the heap onto the stack.



Why would you use an abstract class instead of an interface? Can you give examples of where you have used abstract classes and interfaces in your projects?
You would use an abstract class instead of an interface when your derived classes share a close identity and common behavior, rather than just a common capability.
The primary technical reasons to choose an abstract class include:
Code Reuse (State and Logic): Abstract classes can contain fields, properties, constructors, and fully implemented methods. Interfaces (historically) only define a contract; even with modern C# Default Interface Methods (DIM), interfaces cannot maintain individual instance state (private instance fields).
Establishing an "Is-A" Relationship: Abstract classes model a strict conceptual hierarchy. A SavingsAccount is a BankAccount. Interfaces model an "Is-Capable-Of" relationship. A SavingsAccount is capable of ILoggable or ISerializable.
Access Modifiers: Abstract classes allow you to define protected, internal, or private members to encapsulate internal class logic. Interfaces are inherently designed to expose a public API contract.
Where I Used an Abstract Class: BaseTransaction
I designed an abstract class named BaseTransaction to serve as the structural blueprint for specific types of money movements, such as IncomeTransaction and ExpenseTransaction.
Why: Every transaction in the budget app shares identical core state—an Id, a Timestamp, an Amount, and a CategoryId—along with a fully implemented helper method to format currency. Because they share instance fields and identical base code, a class hierarchy was the natural fit.
Example:
 */
public abstract class BaseTransaction
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public decimal Amount { get; init; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    // Shared business logic method inherited by all transactions
    public string GetFormattedAmount() => $"${Amount:F2}";

    // Forced contract: Each transaction type calculates its own impact on a budget
    public abstract decimal CalculateBudgetImpact(); 
}



/*
What are extension methods? When are they useful, and when should you avoid them?
Extension methods allow you to "add" new methods to existing types (such as string, int, or even custom classes and interfaces) without creating a new derived type, recompiling the original code, or modifying the type itself.
They are defined as static methods inside a static class, but they are called as if they were standard instance methods on the extended type, thanks to the usage of the this modifier on the first parameter.
When Are Extension Methods Useful?
Extending Third-Party or Built-in Types: You cannot modify .NET's native string or DateTime classes because they are sealed. Extension methods let you add custom logic to them (e.g., creating a string.IsValidEmail() helper).
Improving Code Readability (Fluent APIs): They allow you to chain method calls together, reading naturally from left to right instead of nesting method arguments inside static wrappers.

When Should You Avoid Them?
When You Own and Can Modify the Source Code: If a method logically belongs inside a class you wrote, place it inside that class. Relying on extension methods for your own domain objects breaks encapsulation and scatters your class logic across separate files.
When Breaking Domain Boundaries: Avoid writing extension methods that bridge unrelated architectural layers (e.g., adding a .ToDbModel() extension method directly onto a Web API controller request object).
If it introduces Name Clashes: If an extension method shares the exact same signature as an actual instance method inside the class, the compiler will silently prioritize the instance method, rendering your extension method completely unreachable and dead.
Overuse / Global Pollution: If you put too many extension methods in a globally accessed namespace, you pollute IntelliSense for everyone on the team, making it hard to discern what the type's native responsibilities actually are.


What are extension methods? Can you give examples of built-in extension methods? Have you created any extension methods in your projects? If so, how?
The most famous and heavily used built-in extension methods in .NET belong to LINQ (Language Integrated Query). They reside in the System.Linq namespace and extend the IEnumerable<T> interface, allowing you to query collections fluidly.
Examples of Built-in Extension Methods:
.Where(): Filters a collection based on a predicate function.
.Select(): Projects/transforms each element of a collection into a new form.
.OrderBy(): Sorts elements in ascending order.
 
I wrote an extension on the string class to easily check if a user's input string can safely be parsed into a budget decimal.
 Example:
 */
public static class StringExtensions
{
    // The 'this' keyword before the first parameter designates it as an extension method
    public static bool IsValidCurrency(this string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        return decimal.TryParse(input, out _);
    }
}

// How it's used in the project:
string userInput = "120.50";
if (userInput.IsValidCurrency()) { /* Process amount */ }