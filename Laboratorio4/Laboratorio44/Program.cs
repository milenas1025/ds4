using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la nota del estudinate");
        float score = float.Parse(Console.ReadLine());

        if (score >= 70)
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {score} ha aprobado");
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine($"Su nota es {score} ha reporbado, debe repetir");
        }
    }
}