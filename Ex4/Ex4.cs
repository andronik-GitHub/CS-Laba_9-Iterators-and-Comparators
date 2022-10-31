using System;

class Ex4
{
    static void Main()
    {
        string?[]? tempStr = Console.ReadLine()?.Split(", ");
        int[] tempInt = new int[tempStr != null ? tempStr.Length : 0];

        for (int i = 0; i < tempStr?.Length; i++)
            tempInt[i] = Convert.ToInt32(tempStr[i]);


        Lake lake = new(tempInt);
        Console.WriteLine(string.Join(", ", lake));


        Console.ReadKey();
    }
}