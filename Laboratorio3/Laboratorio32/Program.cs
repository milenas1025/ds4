using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero, resultado;

        Console.WriteLine("Introducir el primer número: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introducir el segundo número: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos obj = new CalculosMatematicos();

        resultado = obj.Calcular(primerNumero, segundoNumero);

        Console.WriteLine("El resultado de la operación ({0}+{1})*({0}-{1}) es {2}",
                          primerNumero, segundoNumero, resultado);

        Console.WriteLine("\nIntroducir el radio del círculo: ");
        double radio = Convert.ToDouble(Console.ReadLine());

        double area = obj.CalculoArea(radio);

        Console.WriteLine("El área del círculo con radio {0} es {1}", radio, area);
    }
}

public class CalculosMatematicos
{
    public int Calcular(int a, int b)
    {
        return (a + b) * (a - b);
    }

    public double CalculoArea(double radio)
    {
        return Math.PI * Math.Pow(radio, 2);
    }
}
