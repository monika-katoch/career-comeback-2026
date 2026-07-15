Q: Difference between record and class?

Q: What is a primary constructor?

Q: Difference between value equality and reference equality?

Q: Difference between SequenceEqual() and == ?


# Equality Concepts

## Q: What is the difference between Value Equality and Reference Equality?

### Value Equality
Objects are considered equal if their contents are equal.

Example:
```csharp
public record Employee(string Name, int Experience);

var e1 = new Employee("Monika", 12);
var e2 = new Employee("Monika", 12);

Console.WriteLine(e1 == e2); // True
Records use value equality by default.

### Reference Equality

Objects are considered equal only if they point to the same object in memory.

Example:

public class Employee(string name, int experience)
{
    public string Name => name;
    public int Experience => experience;
}

var e1 = new Employee("Monika", 12);
var e2 = new Employee("Monika", 12);

Console.WriteLine(e1 == e2); // False

Classes use reference equality by default.
