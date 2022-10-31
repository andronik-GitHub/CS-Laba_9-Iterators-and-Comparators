using System;

class Person : IComparable<Person>
{
    public string Name { get; set; } // ім'я
    public int Age { get; set; } // вік
    public string City { get; set; } // місто

    public Person(string Name, string Age, string City) // конструктор
    {
        this.Name = Name;
        this.Age = Convert.ToInt32(Age);
        this.City = City;
    }

    public int CompareTo(Person? other)
    {
        int[] Equal = new int[3] // для визначення співпадінь
        {
            0,      // [0] - Name
            0,      // [1] - Age
            0       // [2] - City
        };

        if (Name == other?.Name) Equal[0]++;
        if (Age == other?.Age) Equal[1]++;
        if (City == other?.City) Equal[2]++;


        if (Equal[0] != 0 || Equal[1] != 0 || Equal[2] != 0) return 0; // якщо є хоч одне співпадіння 
        return -1; // якщо не має співпадіннь
    }
}