Q: Difference between record and class?

Q: What is a primary constructor?

Q: Difference between value equality and reference equality?

Q: Difference between SequenceEqual() and == ?


## Equality Concepts

### Q: What is the difference between Value Equality and Reference Equality?

#### Value Equality

Objects are considered equal if their contents are equal.

```csharp
public record Employee(string Name, int Experience);

var e1 = new Employee("Monika", 12);
var e2 = new Employee("Monika", 12);

Console.WriteLine(e1 == e2); // True
```

Records use value equality by default.

---

#### Reference Equality

Objects are considered equal only if they point to the same object in memory.

```csharp
public class Employee(string name, int experience)
{
    public string Name => name;
    public int Experience => experience;
}

var e1 = new Employee("Monika", 12);
var e2 = new Employee("Monika", 12);

Console.WriteLine(e1 == e2); // False
```

Classes use reference equality by default.

---

### Q: Difference between `==` and `SequenceEqual()`?

#### `==`

- For reference types, compares object references.
- Checks whether both variables point to the same object.

#### `SequenceEqual()`

- Compares collection contents element by element.
- Order matters.

```csharp
var list1 = new List<int> {1,2,3};
var list2 = new List<int> {1,2,3};

Console.WriteLine(list1 == list2);              // False
Console.WriteLine(list1.SequenceEqual(list2)); // True
```

---

### Q: Difference between Record and Class equality?

| Feature | Record | Class |
|---------|--------|-------|
| Equality Type | Value Equality | Reference Equality |
| Generated `Equals()` | Yes | No |
| Generated `GetHashCode()` | Yes | No |
| Supports `with` expression | Yes | No |
Example:
```csharp
public class Employee(string name, int experience)
{
    public string Name => name;
    public int Experience => experience;
}

var e1 = new Employee("Monika", 12);
var e2 = new Employee("Monika", 12);

Console.WriteLine(e1 == e2); // False

Classes use reference equality by default.
