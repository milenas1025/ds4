using System;
namespace Laboratorio2
{
    class Program
    {

        static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando las variables de instancia de Clase.
            client.FirstName = "Milena";
            client.LastName = "Simmons";
            client.Age = 21;
            client.Id = 1;
            Console.WriteLine(client.GetFullName());
        }
    }
    public class  Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
