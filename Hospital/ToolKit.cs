using System;
using System.Collections.Generic;

namespace Hospital
{
    public class ToolKit
    {
        /// <summary>
        /// Herramienta generica que pide un nombre al usuario
        /// </summary>
        /// <returns>Devuelve una cadena de texto con el nombre</returns>
        public static string PedirNombre()
        {
            Console.WriteLine("Introduzca el nombre:");
            return Console.ReadLine();
        }

        /// <summary>
        /// Herramienta generica que pide un nombre al usuario de una persona especiica
        /// </summary>
        /// <param name="persona">Cadena de texto que representa el nombre de la persona</param>
        /// <returns>Devuelve una cadena de texto con el nombre</returns>
        public static string PedirNombre(string persona)
        {
            Console.WriteLine($"Introduzca el nombre de {persona}:");
            return Console.ReadLine();
        }

        /// <summary>
        /// Herrramienta generica que nos permite sacar un int de la entrada del usuario o devolver un error en pantalla si no se ha pidido comvertir
        /// </summary>
        /// <returns>Devuelve un entero</returns>
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

        /// <summary>
        /// Herrramienta generica que nos permite sacar un char de la entrada del usuario o devolver un error en pantalla si no se ha pidido comvertir
        /// </summary>
        /// <returns>Devuelve un caracter</returns>
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

        public static DateTime SacarDateTime()
        {
            Console.WriteLine("Introduzca el dia");
            int dia = SacarEntero();
            Console.WriteLine("Introduzca el mes");
            int mes = SacarEntero();
            Console.WriteLine("Introduzca el año");
            int año = SacarEntero();
            Console.WriteLine("Introduzca la hora");
            int hora = SacarEntero();
            Console.WriteLine("Introduzca los minutos");
            int minutos = SacarEntero();

            return new DateTime(año, mes, dia, hora, minutos, 0);
        }

        public static List<string> PedirListaString(string valor)
        {
            List<string> resultado = new List<string>();

            while (true)
            {
                Console.WriteLine($"Escriba un {valor} o exit si has acabado");
                string caso = Console.ReadLine();
                if (caso.ToLower() == "exit")
                    break;
                resultado.Add(caso);
            }

            return resultado;
        }

        public static string PedirString(string value)
        {
            Console.WriteLine($"Introduzca {value}");
            return Console.ReadLine();
        }
    }
}