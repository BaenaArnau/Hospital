using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
         static List<Personal> personal = new List<Personal>();

        static void Main(string[] args)
        {
            while (true)
            {
                switch (Menu())
                {
                    case 1:
                        DarDeAltaMedico();
                        break;
                    case 2:
                        ListarMedicos();
                        DarDeAltaPaciente();
                        break;
                    case 3:
                        DarDeAltaAdministrativo();
                        break;
                    case 4:
                        ListarMedicos();
                        break;
                    case 5:
                        ListarPacientes(ToolKit.PedirNombre("Doctor"));
                        break;
                    case 6:
                        string nombreDoctor = ToolKit.PedirNombre("Doctor");
                        ListarPacientes(nombreDoctor);
                        EliminarPaciente(nombreDoctor, ToolKit.PedirNombre("Paciente"));
                        break;
                    case 7:
                        ListaDePersonas();
                        break;
                }
            }
        }

        static int Menu()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────────────────────────────────────┐
│                      MENU  PRINCIPAL                       │
├────────────────────────────────────────────────────────────┤
│  (1)  - Dar de alta un medico                              │
│  (2)  - Dar de alta un paciente, para un médico concreto   │
│  (3)  - Dar de alta personal administrativo                │
│  (4)  - Listar los médicos                                 │
│  (5)  - Listar los pacientes de un medico                  │
│  (6)  - Eliminar a un paciente                             │
│  (7)  - Ver la lista de personas del hospital              │
│  (0)  - Salir                                              │
└────────────────────────────────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 7);

            return option;
        }

        public static void DarDeAltaMedico()
        {
            personal.Add(PedirMedico());
            Console.WriteLine("Operacion terminada con exito");
        }

        public static void DarDeAltaPaciente()
        {
            Paciente paciente = PedirPaciente();

            while (true)
            {
                string nombreDoctor = ToolKit.PedirNombre("Doctor");

                foreach (var empleado in personal)
                {
                    if (empleado is Medico medico && empleado.Nombre == nombreDoctor)
                    {
                        medico.Pacientes.Add(paciente);
                        Console.WriteLine("Paciente añadido con exito");
                        return;
                    }
                }

                Console.WriteLine("Escriba un nombre correcto de los doctores de la plantilla");
            }
        }


        public static void DarDeAltaAdministrativo()
        {
            personal.Add(PedirAdministrativo());
            Console.WriteLine("Operacion terminada con exito");
        }

        public static void ListarMedicos()
        {
            Console.WriteLine("Lista de medicos: ");
            foreach (var empleado in personal)
            {
                if (empleado.GetType() == typeof(Medico))
                    Console.WriteLine($"- {empleado.ToString()}");
            }
        }

        public static void ListarPacientes(string nombre)
        {
            foreach (var empleado in personal)
            {
                if (empleado is Medico medico && empleado.Nombre == nombre)
                {
                    Console.WriteLine($"Lista de los pacientes de {nombre}");
                    foreach (var paciente in medico.Pacientes)
                        Console.WriteLine($"- {paciente.ToString()}");
                    return;
                }
            }

            Console.WriteLine("No se a encontrado ningun doctor con ese nombre, vuelva a intentarlo");
        }

        public static void EliminarPaciente(string nombreDoctor, string nombrePaciente)
        {
            foreach (var empleado in personal.ToList())
            {
                if (empleado is Medico medico && empleado.Nombre == nombreDoctor)
                {
                    foreach (var paciente in medico.Pacientes.ToList())
                    {
                        Console.WriteLine($"- {paciente.ToString()}");
                        if (paciente.Nombre == nombrePaciente)
                        {
                            empleado.Pacientes.Remove(paciente);
                            Console.WriteLine("Paciente eliminado con exito");
                            return;
                        }
                    }
                }
            }

            Console.WriteLine("No se a encontrado alguno de los nombres, vuelva a intentarlo");
        }

        public static void ListaDePersonas()
        {
            Console.WriteLine("Lista de personas en el hospital: ");
            foreach (var empleado in personal.ToList())
            {
                Console.WriteLine($"- {empleado.ToString()}");
                if (empleado is Medico medico)
                {
                    Console.WriteLine($"Lista de los pacientes de {medico.Nombre}");
                    foreach (var paciente in medico.Pacientes)
                        Console.WriteLine($"- {paciente.ToString()}");
                }
            }
        }

        public static Administrativo PedirAdministrativo()
        {
            Personal personal = PedirPersonal();
            Console.WriteLine("Escriba el mail del administrativo");
            string mail = Console.ReadLine();

            return new Administrativo(mail, personal);
        }

        public static Medico PedirMedico()
        {
            Personal personal = PedirPersonal();

            return new Medico(personal);
        }

        public static Personal PedirPersonal()
        {
            Persona persona = PedirPersona();
            Console.WriteLine("Introduzca el salario");
            int salario = ToolKit.SacarEntero();
            Console.WriteLine("Introduzca los años cotizados");
            int añoCotizados = ToolKit.SacarEntero();
            Console.WriteLine("Introduzca la fecha de ingreso al hospital");
            int fechaDelAlta = ToolKit.SacarEntero();

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
            string nombre = ToolKit.PedirNombre();
            Console.WriteLine("Introduzca la edad");
            int edad = ToolKit.SacarEntero();
            Console.WriteLine("Introduzca los numero del DNI");
            int dni = ToolKit.SacarEntero();
            Console.WriteLine("Introduzca la letra del DNI");
            char letraDni = ToolKit.SacarChar();

            return new Persona(nombre, edad, dni, letraDni);
        }
    }
}
