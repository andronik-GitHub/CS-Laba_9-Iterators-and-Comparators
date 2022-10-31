using System;
class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public IComparer<Person> Comparer { get; set; } // об'єкт типу IComparer<Person>

    public Person(string Name, int Age, IComparer<Person> Comparer)
    {
        this.Name = Name;
        this.Age = Age;
        this.Comparer = Comparer;
    }

    public void Sort(Person[] people)
    {
        for (int i = 1; i < people.Length; i++)
            for (int j = 0; j < people.Length - i; j++)
                if (Comparer.Compare(people[j], people[j + 1]) > 0) // порівняння методом Comparer з об'єкта типу IComparer<Person>
                    (people[j], people[j + 1]) = (people[j + 1], people[j]);
    }
}