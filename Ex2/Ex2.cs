using System;
using System.Collections;

class Ex2
{
    static void Main()
    {
        string? str = Console.ReadLine(); // зчитується create

        if (str != null && str.ToLower().Contains("Create".ToLower()))
            str = str.Remove(0, str.IndexOf("Create".ToLower()) + ("Create".Length + 1)); // видаляється Create якщо воно є в строці

        string[]? arrStr = str?.Split(' ', StringSplitOptions.RemoveEmptyEntries); // створюється масив з елементами



        bool strBool = false; // для перевірки чи всі елементи є числа
        if (arrStr != null)
        {
            for (int i = 1; i < arrStr.Length; i++) // перевірка елемента чи він є числом
                if (int.TryParse(arrStr[i], out _)) strBool = true;
                else { strBool = false; break; } // якщо знайдена строка то перевірка закінчена

            if (strBool) // якщо вхідні данні тільки числа
            {
                int[] arr = new int[arrStr.Length]; // масив в який запишуться всі числа

                for (int i = 0; i < arr.Length; i++)
                    arr[i] = Convert.ToInt32(arrStr[i]); // символи конвертуються і записуються як числа

                Func<int>(arr); // виклик метода який створить ListyIterator<int>
            }
            else
                Func<string>(arrStr.Length <= 1 ? null : arrStr); // виклик метода який створить ListyIterator<string>
                                                                  // якщо str пуста то передається null, іначе arrStr
        }



        Console.ReadKey();
    }

    static void Func<T>(T[]? arr)
    {
        ListyIterator<T> list; // створення об'єкта типу ListyIterator
        if (arr != null) list = new(new List<T>(arr)); // якщо arr не пустий то він записується в list
        else list = new(new List<T>()); // якщо arr пустий то list створюється пустим


        string? action = "";

        while (action?.ToLower() != "end")
        {
            action = Console.ReadLine();

            try
            {
                if (action?.ToLower() == "end") break;
                else if (action?.ToLower() == "move") Console.WriteLine(list.Move());
                else if (action?.ToLower() == "move") Console.WriteLine(list.Move());
                else if (action?.ToLower() == "hasnext") Console.WriteLine(list.HasNext());
                else if (action?.ToLower() == "print") list.Print();
                else if (action?.ToLower() == "printall") list.PrintAll();
                // Create Stefcho Goshky Peshu
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                break;
            }
        }
    }
}