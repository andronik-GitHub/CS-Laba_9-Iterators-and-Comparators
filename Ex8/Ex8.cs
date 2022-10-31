using System;
using System.Collections;

class Ex8
{
    static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine()); // кількість команд
        List<Pet> pets = new(); // колекція тварин
        List<Clinic> clinics = new(); // колекція клінік

        for (int i = 0; i < N; i++) // виконання N команд
        {
            string[]? action = Console.ReadLine()?.Split(' ');

            if (action != null)
            {
                if (action[0].ToLower() == "create" && action.Length > 1) // якщо команда створення
                    if (action[1].ToLower() == "pet") // якщо створення тварини
                        try
                        {
                            pets.Add(new Pet(action[2], Convert.ToInt32(action[3]), action[4])); // створення тварини
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    else if (action[1].ToLower() == "clinic") // якщо створення клініки
                        try
                        {
                            clinics.Add(new Clinic(action[2], Convert.ToInt32(action[3]))); // створення клініки
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                if (action[0].ToLower() == "add") // якщо команда додавання
                {
                    try
                    {   // Додавання тварини в клініку і вивід успішності команди
                        Console.WriteLine(Add(action[1], action[2], pets, clinics));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (action[0].ToLower() == "release") // якщо команда видалення
                {
                    try
                    {   // Видалення тварини з клініки і вивід успішності команди
                        Console.WriteLine(Release(action[1], clinics));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (action[0].ToLower() == "HasEmptyRooms".ToLower()) // якщо команда перевірки клініки на пусті кімнати
                {
                    try
                    {
                        // Виведення, чи є пусті кімнати в клініці
                        Console.WriteLine(HasEmptyRooms(action[1], clinics));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                if (action[0].ToLower() == "print") // якщо команда перевірки клініки на пусті кімнати
                {
                    try
                    {
                        if (action.Length == 3)
                            Print(action[1], clinics, Convert.ToInt32(action[2]));
                        else if (action.Length == 2)
                            Print(action[1], clinics);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }


        Console.ReadKey();
    }

    static bool Add(string petName, string clinicName, List<Pet> pets, List<Clinic> clinics) // додавання тварини в клініку
    {
        bool index = false; // чи вдалось додати тварину в клініку
        Pet pet = pets[0]; // буде містити в собі тварину яку потрібно додати до клініки

        for (int i = 0; i < pets.Count; i++) // перевірка чи така тварина створена
            if (pets[i].Name.ToLower() == petName.ToLower())
            {
                index = true; // тварина є
                pet = pets[i];  // pet перезаписується 
                break; // перевірка закінчується
            }

        if (!index) return false; // якщо тварини немає то додати тварину в клініку не вдалось

        for (int i = 0; i < clinics.Count; i++) // перевірка чи така клініка створена і додавання тварини в неї
            if (clinics[i].Name.ToLower() == clinicName.ToLower()) // якщо клініка створена
                if (clinics[i].Add(pet)) // додавання тварини в клініку і перевірка на успішність додавання
                    return true; // додавання вдалось
                else // якщо додавання не вдалось
                    return false; // то перевірка закінчується


        return false; // додавання не вдалось
    }

    static bool Release(string clinicName, List<Clinic> clinics) // видалення першої знайденої тварини з клініки
    {
        for (int i = 0; i < clinics.Count; i++) // перевірка чи така клініка створена і видалення тварини в неї
            if (clinics[i].Name.ToLower() == clinicName.ToLower()) // якщо клініка створена
                if (clinics[i].Releas()) // видалення тварини з клініки і перевірка на успішність видалення
                    return true; // видалення вдалось
                else // якщо видалення не вдалось
                    return false; // то перевірка закінчується


        return false; // видалення не вдалось
    }

    static bool HasEmptyRooms(string clinicName, List<Clinic> clinics) // перевірка, чи є вільні кімнати в клініці
    {
        for (int i = 0; i < clinics.Count; i++) // перевірка чи така клініка створена і чи є вільні кімнати в ній
            if (clinics[i].Name.ToLower() == clinicName.ToLower()) // якщо клініка створена
                if (clinics[i].HasEmptyRooms()) // перевірка, чи є вільні кімнати в ній
                    return true; // вільні кімнати є
                else
                    return false; // вільних кімнат немає


        return false; // вільних кімнат немає
    }

    static void Print(string clinicName, List<Clinic> clinics, int? index = null)
    {
        for (int i = 0; i < clinics.Count; i++) // перевірка чи така клініка створена і чи є вільні кімнати в ній
            if (clinics[i].Name.ToLower() == clinicName.ToLower()) // якщо клініка створена
                if (index == null) clinics[i].Print(); // якщо не заданий індекс то виводяться всі кімнати
                else clinics[i].Print(index - 1); // якщо індекс заданий то виводиться кімната за цим індексом
    }
}