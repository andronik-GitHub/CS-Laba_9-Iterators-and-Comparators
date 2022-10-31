using System;

class Room
{
    bool empty; // статус кімнати: пуста(true)/не пуста(false)
    Pet? pet; // тварина яка знаходиться в цій кімнаті

    public Room() // конструктор
    {
        empty = true; // кімната пуста
        pet = null; // тварини немає в кімнаті
    }

    public override string ToString()
    {
        if (pet != null && !IsEmpty()) // якщо кімната не пуста
            return pet.ToString(); // "{petName} {petAge} {petKind}"
        else if (pet == null || (pet != null && IsEmpty())) // якщо кімната пуста
            return "Room empty";

        return ToString();
    }


    public bool IsEmpty() => empty; // повертає статус кімнати: пуста(true)/не пуста(false)

    public bool Add(Pet? pet) // додавання тварини в кімнату
    {
        if (pet != null)
        {
            this.pet = pet; // додавання тварини
            empty = false; // кімната вже не пуста
            return true; // додавання вдалось
        }
        return false; // додавання не вдалось
    }

    public void Release() // видалення тварини з кімнати
    {
        pet = null; // видалення тварини
        empty = true; // кімната пуста
    }
}