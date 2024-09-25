using System;

namespace Hospital
{
    public class ToolKit
    {
        public static string PedirNombre()
        {
            Console.WriteLine("Introduzca el nombre:");
            return Console.ReadLine();
        }

        public static string PedirNombre(string persona)
        {
            Console.WriteLine($"Introduzca el nombre de {persona}:");
            return Console.ReadLine();
        }

        public static int SacarEntero()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int valor))
                    return valor;
                else
                    Console.WriteLine("Introduzca un valor valido");
            }
        }

        public static char SacarChar()
        {
            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out char caracter))
                    return caracter;
                else
                    Console.WriteLine("Introduzca un valor valido");
            }
        }
    }
}