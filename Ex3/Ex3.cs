using System;
using System.Collections.Generic;

class Ex3
{
    static void Main()
    {
        MyStack<int> myStack = new(); // виділення пам'яті для стеку
        string? action = ""; // для визначення команд end, push, pop

        while (action?.ToLower() != "end")
        {
            action = Console.ReadLine()?.Trim();

            if (action?.ToLower() == "end")
            {
                for (int i = 0; i < 2; i++) // перебір стека двічі
                    foreach (var item in myStack) // виведення стека
                        Console.WriteLine(item);

                break; // вихід тому що кінець вводу
            }
            else if (action?.ToLower()[0] == 'p' &&
                        action?.ToLower()[1] == 'u' &&
                        action?.ToLower()[2] == 's' &&
                        action?.ToLower()[3] == 'h')
            {
                // Видалення Push зі строки
                action = action.Contains("Push") ? action.Replace("Push", "") : action.Replace("push", "");
                action = action.Trim(); // видалення зайвих пробілів по сторонам
                string[] tempArr = action.Split(", "); // записування елементів зі строки в масив

                foreach (string item in tempArr) // записування елементів зі строки в стек
                {
                    try
                    { myStack.Push(Convert.ToInt32(item)); } // конвертування і додавання
                    catch (Exception e)
                    { Console.WriteLine(e.Message); } // виключення
                }
            }
            else if (action?.ToLower() == "pop")
            {
                try
                { myStack.Pop(); } // видалення
                catch (Exception e)
                { Console.WriteLine(e.Message); } // виключення
            }
        }


        Console.ReadKey();
    }
}