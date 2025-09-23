using System;
class program
{
    static void Main(string[] args)
    {
        try
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine(myNumbers[10]);
        }
        catch (Exception e)
        {
            Console.WriteLine("Alg salio mal, valide el indice del grado");
        }
        finally
        {
            Console.WriteLine("Continuacion de la aplicacion, luego del bloue try/catch");
        }
    }
}