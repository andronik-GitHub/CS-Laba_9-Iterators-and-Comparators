using System;
using System.Collections;

class MyStack<T> : IEnumerable<T>
{
    List<T> myStack; // колекцiя

    public MyStack() => myStack = new(); // конструктор

    public IEnumerator<T> GetEnumerator() // реалізація IEnumerable<T>
    {
        for (int i = myStack.Count - 1; i >= 0; i--)
            yield return myStack[i];
    }
    IEnumerator IEnumerable.GetEnumerator() // реалізація IEnumerable
    {
        for (int i = myStack.Count - 1; i >= 0; i--)
            yield return myStack[i];
    }



    public void Push(T element) => myStack.Add(element); // додавання

    public void Pop() // видалення
    {
        if (myStack.Count > 0) myStack.RemoveAt(myStack.Count - 1); // видалення елемента в кінці колекції
        else throw new Exception("No elements"); // створення виключення
    }
}