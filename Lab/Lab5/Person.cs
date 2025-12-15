namespace Lab5;

public abstract class Person
{
public string Name { get; }

protected Person(string name)
{
    Name = name;
}

public abstract void ShowMenu(Salad salad);
}