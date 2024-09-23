using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        List<Personal> personal = new List<Personal>();

        static void Main(string[] args)
        {
        }

        public static void DarDeAltaPaciente()
        {

        }

        public static Medico PedirMedico()
        {
            Personal personal = new Personal();

            return new Medico(personal);
        }

        public static Personal PedirPersonal()
        {
            Persona persona = PedirPersona();
            Console.WriteLine("Introduzca el salario");
            int salario = SacarEntero();
            Console.WriteLine("Introduzca los años cotizados");
            int añoCotizados = SacarEntero();
            Console.WriteLine("Introduzca la fecha de ingreso al hospital");
            int fechaDelAlta = SacarEntero();

            return new Personal(salario, añoCotizados, fechaDelAlta, persona);
        }

        public static Paciente PedirPaciente()
        {
            Persona persona = PedirPersona();
            string enfermedad;

            Console.WriteLine("Que enfermedad tiene el paciente");
            enfermedad = Console.ReadLine();

            return new Paciente(enfermedad, persona);
        }

        public static Persona PedirPersona()
        {
            string nombre = PedirNombre();
            Console.WriteLine("Introduzca la edad");
            int edad = SacarEntero();
            Console.WriteLine("Introduzca los numero del DNI");
            int dni = SacarEntero();
            Console.WriteLine("Introduzca la letra del DNI");
            char letraDni;

            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out letraDni))
                    break;
                else
                    Console.WriteLine("Introduzca un valor valido");
            }

            return new Persona(nombre, edad, dni, letraDni);
        }

        public static string PedirNombre()
        {
            Console.WriteLine("Introduzca el nombre:");
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
    }
}
