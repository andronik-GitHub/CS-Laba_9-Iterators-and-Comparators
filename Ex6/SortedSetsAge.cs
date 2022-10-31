using System;

class SortedSetsAge : IComparer<Person> // об'єкт типу IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x?.Age > y?.Age)
            return 1;

        return -1;
    }
}