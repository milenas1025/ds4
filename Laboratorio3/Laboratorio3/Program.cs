internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero, suma;

        Console.WriteLine("Introducir el primer umer: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Introducir el segundo numero: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        suma = primerNumero + segundoNumero;

        Console.WriteLine("La suma {0} y {1} es {2} ", primerNumero, segundoNumero, suma);
    }
}