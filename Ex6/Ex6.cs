using System;

class Ex6
{
    static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        Person[] SortedSets1 = new Person[N];
        Person[] SortedSets2 = new Person[N];

        for (int i = 0; i < N; i++)
        {
            string? Date = Console.ReadLine();
            string[]? str = Date?.Split(' ');

            if (str != null)
            {
                SortedSets1[i] = new(str[0], Convert.ToInt32(str[1]), new SortedSetsName()); // SortedSetsName - сортування за іменем
                SortedSets2[i] = new(str[0], Convert.ToInt32(str[1]), new SortedSetsAge()); // SortedSetsName - сортування за віком
            }
        }
        SortedSets1[0].Sort(SortedSets1); // сортування за іменем
        SortedSets2[0].Sort(SortedSets2); // сортування за віком


        Console.WriteLine();
        for (int i = 0; i < N; i++) // сортування за іменем
            Console.WriteLine(SortedSets1[i].Name + " " + SortedSets1[i].Age);

        for (int i = 0; i < N; i++) // сортування за віком
            Console.WriteLine(SortedSets2[i].Name + " " + SortedSets2[i].Age);


        Console.ReadKey();
    }
}