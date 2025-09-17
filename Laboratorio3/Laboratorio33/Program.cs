using System;

internal class Program
{
    private static void Main(string[] args)
    {
        double baseRect, alturaRect, perimetro;

        Console.WriteLine("Introducir la base del rectángulo: ");
        baseRect = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Introducir la altura del rectángulo: ");
        alturaRect = Convert.ToDouble(Console.ReadLine());

        perimetro = 2 * (baseRect + alturaRect);

        Console.WriteLine("El perímetro del rectángulo es: {0}", perimetro);
    }
}
