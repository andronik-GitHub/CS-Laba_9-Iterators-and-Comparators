using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }


    public override bool Equals(object? obj)
    {
        if (obj?.GetHashCode() == (Name.GetHashCode() + Age.GetHashCode())) return true;
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode() + Age.GetHashCode();
    }
}