using System;

class SortedSetsName : IComparer<Person> // об'єкт типу IComparer<Person>
{
    public int Compare(Person? x, Person? y)
    {
        if (x?.Name.Length > y?.Name.Length)
            return 1;
        else if (x?.Name.Length == y?.Name.Length)
            if (x?.Name.ToLower()[0] > y?.Name.ToLower()[0])
                return 1;

        return -1;
    }
}