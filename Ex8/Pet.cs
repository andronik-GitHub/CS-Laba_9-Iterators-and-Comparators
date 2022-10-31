using System;

class Pet
{
    string name = ""; // ім'я тварини
    int age = 0; // вік тварини
    string kind = ""; // тип тварини

    public string Name { get => name; set => name = value; } // властивість імені тварини
    public int Age { get => age; set => age = value; } // властивість віку тварини
    public string Kind { get => kind; set => kind = value; } // властивість типу тварини


    public Pet(string name, int age, string kind) // конструктор
    {
        Name = name;
        Age = age;
        Kind = kind;
    }

    public override string ToString() => Name + " " + Age + " " + Kind; // "{petName} {petAge} {petKind}"
}