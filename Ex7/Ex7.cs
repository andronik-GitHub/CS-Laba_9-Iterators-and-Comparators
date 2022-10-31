using System;

class Ex7
{
    static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine());

        Person[]? SortedSet = new Person[N];
        Person[]? HashSet = new Person[N];

        int IndexSortedSet = 0;
        int IndexHashSet = 0;

        for (int i = 0; i < N; i++)
        {
            string? s = Console.ReadLine();
            string[]? str = s?.Split(' ');

            if (str != null)
            {
                SortedSet[i] = (new Person(str[0], Convert.ToInt32(str[1])));
                HashSet[i] = (new Person(str[0], Convert.ToInt32(str[1])));
                IndexSortedSet++;
                IndexHashSet++;

                if (i > 0)
                {
                    for (int j = 0; j < i; j++)
                        if (SortedSet[i].Equals(SortedSet[j]) ||
                            HashSet[i].Equals(HashSet[j]))
                        {
                            IndexSortedSet--;
                            IndexHashSet--;
                            break;
                        }
                }
            }
        }

        Console.WriteLine(IndexSortedSet);
        Console.WriteLine(IndexHashSet);

        Console.ReadKey();
    }
}