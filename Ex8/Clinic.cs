using System;

class Clinic
{
    string name = ""; // назва клініки
    int numRooms = 0; // кількість кімнат в клініці
    Room[] rooms; // кімнати
    
    public string Name { get => name; set => name = value; } // властивість назви клініки
    public int NumRooms // властивість кількості кімнат в клініці
    {
        get => numRooms;
        set
        {
            if (value % 2 == 0) // якщо кількість кімнат парна
                throw new Exception("Invalid Operation!"); // створюється виключення
            else
                numRooms = value;
        }
    }

    public Clinic(string name, int numRooms) // конструктор
    {
        Name = name; // встановлюється назва клініки
        NumRooms = numRooms; // встановлюється кількість кімнат
        rooms = new Room[NumRooms]; // виділяється пам'ять під NumRooms кімнат

        for (int i = 0; i < NumRooms; i++)
            rooms[i] = new(); // виділяється пам'ять під кожну кімнату
    }

    public bool Add(Pet pet) // додавання тварини в клініку
    {
        for (int i = 0; i < (NumRooms > 1 ? NumRooms / 2 : NumRooms); i++)
        {
            if (rooms[(NumRooms / 2) - i].IsEmpty()) // якщо пуста ліва кімната
            {
                rooms[(NumRooms / 2) - i].Add(pet); // тварина додається в кімнату
                return true; // додавання вдалось успішно
            }
            else if (rooms[(NumRooms / 2) + i].IsEmpty()) // якщо пуста права кімната
            {
                rooms[(NumRooms / 2) + i].Add(pet); // тварина додається в кімнату
                return true; // додавання вдалось успішно
            }
        }

        return false; // додавання не вдалось успішно
    }

    public bool Release() // видалення першої знайденої тварини з кімнати
    {
        if (!rooms[NumRooms > 1 ? NumRooms / 2 : NumRooms - 1].IsEmpty()) // якщо центральна кімната не пуста
        {
            rooms[NumRooms > 1 ? NumRooms / 2 : NumRooms - 1].Release(); // тварина видалається
            return true; // видалення вдалось успішно
        }

        for (int i = NumRooms / 2; i < NumRooms; i++) // він центральної до правої
            if (!rooms[i].IsEmpty()) // якщо кімната пуста
            {
                rooms[i].Release(); // тварина видалається
                return true; // видалення вдалось успішно
            }
        for (int i = 0; i < NumRooms / 2; i++) // він лівої до центральної
            if (!rooms[i].IsEmpty()) // якщо кімната пуста
            {
                rooms[i].Release(); // тварина видалається
                return true; // видалення вдалось успішно
            }

        return false; // видалення не вдалось успішно
    }

    public bool HasEmptyRooms() // перевірка, чи є пусті кімнати в клініці
    {
        for (int i = 0; i < (NumRooms > 1 ? NumRooms / 2 : NumRooms); i++)
            if (rooms[(NumRooms / 2) - i].IsEmpty()) return true; // якщо пуста ліва
            else if (rooms[(NumRooms / 2) + i].IsEmpty()) return true; // якщо пуста права

        return false; // пустих кімнат немає
    }

    public void Print(int? index = null) // друк кімнат
    {
        if (index == null) // якщо не заданий індекс то виводяться всі кімнати
            foreach (Room room in rooms)
                Console.WriteLine(room);
        else // якщо індекс заданий то виводиться кімната за цим індексом
            Console.WriteLine(rooms[(int)index]);
    }
}