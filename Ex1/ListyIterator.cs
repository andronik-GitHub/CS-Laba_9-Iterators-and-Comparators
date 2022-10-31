using System;
using System.Collections;

class ListyIterator<T>
{
    List<T> list; // колекція
    int position = 0; // індекс для проходження по колекції
    public int Count { get => list.Count; } // розмірність колекції

    public ListyIterator(List<T> list) => this.list = list; // конструктор

    public bool Move()
    {
        if (HasNext())
        {
            position++;     // позиція індекса переміщується в колекції
            return true;    // true якщо не знаходиться на останній позиції,
        }
        else
            return false;   // false якщо знаходиться на останній позиції
    }

    public bool HasNext() => position + 1 >= list.Count ? false : true; // true якщо не знаходиться на останній позиції,
                                                                        // false якщо знаходиться на останній позиції

    public void Print()
    {
        if (list.Count == 0) throw new Exception("Invalid Operation!"); // якщо колекція пуста то створюється нове виключення
        else Console.WriteLine(list[position]); // якщо не пуста то виводиться елемент
    }
}