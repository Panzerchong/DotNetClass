
/*
1.	What are the six combinations of access modifier keywords and what do they do?
Public: the class can be accessed anywhere
Private: the class can be accessed within the same class
Protected: the class and its child class even not in the same project can access the class
Internal: the class can be accessed in the project scope
Protected internal: the class can be accessed in the project scope and its child class
Private protected: the class can be accessed by itself and derived class only they are in the same project.

2.	What is the difference between the static, const, and readonly keywords when applied to a type member?
static: belongs to the type itself, not to any specific instance of the type.
const: it needs to initialized when declaration, can only be used for primitive types, enums, or strings.
readonly: it needs to initialized. Set value at runtime. Cannot be reassigned after construction, but different instances can have different value.

3.	What does a constructor do?
It runs automatically when creating the object of the class and initialized object.

4.	Why is the partial keyword useful?
It can split large code into different files, helpful for auto- generated code and team collaboration.

5.	What is a tuple?
Tuple is data structure that holds different values in one object.

6.	What does the C# record keyword do?
A record in C# is a class or struct that provides special syntax and behavior for working with data models. 
The record modifier instructs the compiler to synthesize members that are useful for types whose primary role is storing data.	

7.	What does overloading and overriding mean?
Overloading: different methods have same name but with different parameters.
Overriding: new implementation for a method defined in the base class virtual method.

8.	What is the difference between a field and a property?
Field is variables that a class or struct have
Property is a collection of field with get and set method

9.	How do you make a method parameter optional?
Create default parameter values so the method will use default value when no value is passed to the method.

10.	What is an interface and how is it different from an abstract class?
Interface is a contract specifying a set of members. It will contain only the declaration of the members. 
The implementation of its members must be done by the class who implements the interface.
Abstract class is a class that cannot be instantiated directly. It's the base of derived class.
It can contain both abstract method or concrete method.

11.	What accessibility level are members of an interface by default?
By default, all members of interface are public

12.	True/False: Polymorphism allows derived classes to provide different implementations of the same method.
True

13.	True/False: The override keyword is used to indicate that a method in a derived class is providing its own implementation.
True

14.	True/False: The new keyword is used to indicate that a method in a derived class is providing its own implementation.
False

15.	True/False: Abstract methods can be used in a normal (non-abstract) class.
False

16.	True/False: Normal (non-abstract) methods can be used in an abstract class.
True

17.	True/False: Derived classes can override methods that were virtual in the base class.
True

18.	True/False: Derived classes can override methods that were abstract in the base class.
True

19.	True/False: Derived classes must override the abstract methods from the base class.
True

20.	True/False: In a derived class, you can override a method that was neither virtual nor abstract in the base class.
False

21.	True/False: A class that implements an interface does not have to provide an implementation for all of the members of the interface.
False

22.	True/False: A class that implements an interface is allowed to have other members in addition to the interface members.
True

23.	True/False: A class can inherit from more than one base class.
False

24.	True/False: A class can implement more than one interface.
True
*/


/*
Create 3 classes in Program.cs:
a. Person class
●	Create an abstract class Person with the following members:

○	An Id property (int).

○	A private field salary with a public property Salary that only accepts positive values; throw an exception if a negative value is assigned.

○	A DateOfBirth property (DateTime).

○	An Address property (List of strings).

________________________________________
b. Instructor class
●	Create a class Instructor that inherits from Person.

○	Add a DepartmentId property (int).


________________________________________
c. Student class
●	Create a class Student that inherits from Person.

○	Add a property SelectedCourses, which is a list of Course objects.
*/

public abstract class Person
{
    public int ID { get; set; }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Salary should be positive!");
            }
            salary = value;
        }
    }

    public DateTime DateOfBirth { get; set; }
    public List<string> Address { get; set; } = new List<string>();

}

public class Instructor : Person
{
    public int DepartmentId { get; set; }
}

public class Course
{
    public int CourseId { get; set; }
    public required string Name { get; set; }
}

public class Student : Person
{
    public List<Course> SelectedCourses { get; set; } = new List<Course>();
}


/*
Interview Questions 
*Please make sure you fully understand both the interview question and your answer 
What are the four OOP principles in C#? Can you give examples of how you have applied them in a real project?
Encapsulation is the practice of hiding an object's internal state and forcing all interaction to occur through a well-defined public interface. This protects the data from accidental corruption.
Inheritance allows a new class (child) to acquire the properties and behaviors of an existing class (parent), promoting code reusability and establishing an "is-a" relationship.
Polymorphism ("many forms") allows objects of different classes to be treated as objects of a common superclass. It comes in two flavors: overriding (runtime) and overloading (compile-time).
Abstraction is the process of hiding complex implementation details and showing only the essential features of an object. In C#, this is primarily achieved using abstract classes and interfaces.
I applied these principles when architecting a custom budget tracking application featuring an inline-editable, Excel-like data grid built with an ASP.NET Web API backend.



What are virtual, abstract, and override methods? How do they work together?
A virtual method is a complete, working method defined in a base (parent) class that provides a default implementation but explicitly gives permission for child classes to change it. It serves as a baseline behavior—derived classes can use it exactly as-is, or they can choose to replace it if they need more specialized logic.
An abstract method is an empty method declaration with no code block, defined strictly within an abstract class. It represents a mandatory requirement rather than an option: it forces any non-abstract child class to provide its own concrete implementation from scratch because the parent class doesn't know how to define a default behavior.
An override method is the keyword used in a child class to actually implement an abstract method or replace a virtual method. It acts as the connector that intercepts calls to the base class method at runtime, ensuring that the runtime executes the child's specialized version instead of the parent's default behavior.
They work together to enable runtime polymorphism by defining a contractual relationship between parent and child classes. The parent class establishes the blueprint by declaring either optional entry points (virtual) or mandatory entry points (abstract), and the child class uses override to map its custom behaviors onto that blueprint. This allows you to write clean code that treats a collection of mixed child objects uniformly as the base type while ensuring each object executes its own correct, custom overridden logic at runtime.


*/
//What is polymorphism? Can you explain compile-time polymorphism and runtime polymorphism with examples?
//Polymorphism allows objects of different classes to be treated as instances of a common parent class. It enables a single interface or method name to handle different underlying data types or behaviors, making your code significantly more flexible and extensible.
//1. Compile-Time Polymorphism (Static)
//In compile-time polymorphism, the relationship between the method call and the method body is determined by the compiler when the application builds. This is primarily achieved through Method Overloading.
public class PaymentProcessor
{
    // Version 1: Handles credit card processing
    public void ProcessPayment(string cardNumber, decimal amount)
    {
        Console.WriteLine($"Processing card payment of ${amount}");
    }

    // Version 2: Overloaded to handle digital wallets
    public void ProcessPayment(string payPalEmail, string securityToken, decimal amount)
    {
        Console.WriteLine($"Processing digital wallet payment of ${amount}");
    }
}

//2.Runtime Polymorphism(Dynamic)
//In runtime polymorphism, the decision of which method to execute is deferred until the application is actively running. This is achieved using Inheritance combined with Virtual/Abstract and Override methods.
// Base Class
public class Notification
{
    public virtual void Send()
    {
        Console.WriteLine("Sending a standard system notification.");
    }
}

// Derived Class 1
public class EmailNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending an email with SMTP headers.");
    }
}

// Derived Class 2
public class SmsNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending an SMS via telecom gateway.");
    }
}

List<Notification> notifications = new List<Notification>
{
    new EmailNotification(),
    new SmsNotification(),
    new Notification()
};

foreach (var notification in notifications)
{
    // The runtime decides which specific implementation to run based on the object type
    notification.Send();
}

// Output:
// "Sending an email with SMTP headers."
// "Sending an SMS via telecom gateway."
// "Sending a standard system notification."


/*
What is encapsulation, and how does it help make code easier to maintain?
Encapsulation is the practice of bundling data (fields) and the methods that operate on that data into a single unit (a class) while restricting direct access to the internal inner workings. By hiding an object's internal state behind private access modifiers and exposing it only through controlled public properties or methods, you establish a protective barrier around your data.
This drastically improves code maintainability because it enforces a single point of validation and prevents external code from accidentally corrupting an object's state. If your business logic or data structures need to change in the future, you only have to modify the code inside that specific class; any external code interacting with it remains completely untouched and unbroken because the public interface stayed exactly the same.
When behaviors span across different hierarchies: C# does not support multiple inheritance. If you have a Car class and a Boat class, and you want to build a Seaplane, inheritance breaks down. Composition solves this by letting the Seaplane hold instances of an Engine, an Anchor, and a Wing component simultaneously.

What is inheritance? When would you avoid inheritance and use composition instead?
Inheritance is an object-oriented programming principle that allows a new class (the child or derived class) to automatically absorb the properties, fields, and behaviors of an existing class (the parent or base class). It establishes a strict "is-a" relationship (e.g., a SavingsAccount is a BankAccount), allowing developers to reuse code and build hierarchical relationships without re-writing identical logic across multiple classes.
While inheritance is powerful, it creates a tight coupling between the parent and child class. You should avoid inheritance and choose composition (establishing a "has-a" relationship) in the following scenarios:
When you only need a portion of the functionality: If a child class inherits from a parent, it is forced to expose all public methods of that parent, even if they don't make sense for the child. Composition allows you to inject only the specific tool you need as a private field
When you need runtime flexibility: Inheritance is locked in at compile-time—a class cannot change its parent type while the app is running. With composition, you can easily swap out the internal behavior at runtime (e.g., swapping a SqlDatabaseLogger for a FileLogger via an interface).



What is the difference between fields, properties, and auto-properties?
The difference between fields, properties, and auto-properties lies in how they store data, protect state, and implement encapsulation.
A field is a variable of any type that is declared directly inside a class or struct. It represents raw data storage.
A property is a flexible wrapper around a private field (called a backing field) that controls how data is read or written using get and set accessors. It allows you to execute custom logic, such as data validation or logging, whenever external code interacts with that data.
An auto-property is a shorthand syntax introduced to simplify properties when no additional validation or custom logic is required in the get or set accessors.


What is the difference between static, sealed, and abstract? When would you use each keyword?
The core difference lies in how these keywords control inheritance and instantiation.
abstract: Used when a class is incomplete and designed only to be inherited. You cannot create an instance of an abstract class using new. You use it to build a shared blueprint for a family of related classes.
sealed: The exact opposite of abstract. It prevents any inheritance. You use it to lock a class down so no other class can derive from it, often for security, performance optimization, or to ensure a strict behavior.
static: Used when a class belongs to the type itself rather than any object instance. A static class cannot be instantiated and cannot be inherited. It can only contain static members and serves as a global container for utility functions or shared constants.


What C# coding practices do you follow to write clean, maintainable, and testable code?
To write clean, maintainable, and testable C# code, my approach is grounded in the SOLID principles, implemented through idiomatic .NET practices:
Single Responsibility & Interfaces (S & D): I keep classes tightly focused on a single task and depend entirely on abstractions rather than concrete implementations. By injecting interfaces (like IUserRepository) via Constructor Dependency Injection, I decouple the business logic from infrastructure, making the service fully unit-testable using mock frameworks.
Open/Closed Principle (O): I design systems to be open for extension but closed for modification. For example, instead of using massive, deeply nested if-else or switch blocks to handle new business rules, I leverage C# Pattern Matching and Switch Expressions, or abstract behaviors into distinct strategies that can be added without modifying existing code.
Interface Segregation (I): I avoid "fat" interfaces. I break them down into small, highly specific roles (e.g., separating IReadOnlyRepository from IWriteRepository). This ensures that consuming classes aren't forced to implement or depend on methods they don't use.
Defensive Coding & Immutability: I use C# Guard Clauses (ArgumentNullException.ThrowIfNull) at the top of methods to fail fast and keep code unnested. To eliminate side effects across threads, I use record types with init-only properties for Data Transfer Objects (DTOs) to enforce immutability.
Asynchronous Execution & Efficiency: For all I/O-bound operations (database, network, file access), I utilize async/await all the way down to prevent thread-pool starvation. When querying data via EF Core, I explicitly append .AsNoTracking() on read-only operations to bypass the memory overhead of the change tracker.


What is the difference between class, a struct, and a record? When would you use each?
class (Reference Type): Stored on the heap. Multiple variables can point to the same object in memory. Equality is based on reference (two objects are equal only if they point to the exact same memory address).
struct (Value Type): Stored on the stack (or inline inside a heap object). Variables hold the actual data value directly, and copying a struct copies all its data. Equality is based on value (comparing the actual data fields).
record (Reference or Value Type): Introduced in C# 9, a record is not a completely separate type but a specialized flavor of a class (or struct) designed for immutability and data-centric modeling. It automatically generates compiler features like value-based equality syntax (even if it's a reference type behind the scenes) and the with expression for non-destructive mutation.
Use a class for core business logic services (like controllers or repositories) that require complex identity, state mutations, and inheritance structures. Choose a struct for tiny, short-lived, immutable value types (like coordinates, vectors, or RGB colors) where avoiding heap allocation maximizes performance. Opt for a record when defining data-centric structures like DTOs, API payloads, or event messages where immutability and automatic value-based equality are highly preferred.
*/
