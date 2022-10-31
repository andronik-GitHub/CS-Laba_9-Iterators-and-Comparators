using System;
using System.Collections;

class Ex5
{
    static void Main()
    {
        List<Person> people = new(); // колекція людей
        string? action = ""; // для вводу данних і визначення кінця вводу
        string[] str; // для ініціалізації конструктора Person

        while (action?.ToLower() != "end")
        {
            action = Console.ReadLine();

            if (action?.ToLower() == "end") break; // кінець вводу
            else if (action != null)
            {
                str = action.Split(' '); // зчитується ім'я, вік, місто
                people.Add(new Person(str[0], str[1], str[2])); // додається нова персона
            }
        }

        int N = Convert.ToInt32(Console.ReadLine()); // N-а людина з якою будуть відбуватись порівняня
        int Equal = 0; // кількість співпадіннь
        int NotEqual = 0; // кількість не співпадінь

        for (int i = 0; i < people.Count; i++)
            if (people[N - 1].CompareTo(people[i]) == 0 && i != (N - 1)) Equal++; // якщо хоча б одне співпадіння
            else NotEqual++; // якщо немає хоча б одного співпадіння

        if (Equal > 0) // якщо хоча б одне співпадіння
            Console.WriteLine(Equal + " " + NotEqual + " " + people.Count);
        else // якщо немає хоча б одного співпадіння
            Console.WriteLine("No matches");


        Console.ReadKey();
    }
}