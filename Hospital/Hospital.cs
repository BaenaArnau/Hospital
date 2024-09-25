using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Hospital
    {
        public static List<Persona> personas = new List<Persona>();

        public static void DarDeAltaMedico()
        {
            personas.Add(PedirMedico());
            Console.WriteLine("Operacion terminada con exito");
        }

        public static void DarDeAltaPaciente()
        {
            Paciente paciente = PedirPaciente();

            while (true)
            {
                string nombreDoctor = ToolKit.PedirNombre("Doctor");

                Medico medico = personas.OfType<Medico>()
                    .FirstOrDefault(m => m.Nombre == nombreDoctor);

                if (medico != null)
                {
                    medico.ListaPacientes.Add(paciente);
                    personas.Add(paciente);
                    Console.WriteLine($"Paciente {paciente.Nombre} dado de alta con el doctor {medico.Nombre}.");
                    return;
                }
                else
                    Console.WriteLine("Escriba un nombre correcto de los doctores de la plantilla.");
            }
        }

        public static void DarDeAltaAdministrativo()
        {
            personas.Add(PedirAdministrativo());
            Console.WriteLine("Operacion terminada con exito");
        }

        public static void ListarMedicos()
        {
            Console.WriteLine("Lista de medicos: ");
            foreach (var empleado in personas.OfType<Medico>())
            {
                Console.WriteLine($"- {empleado.ToString()}");
            }
        }

        public static void ListarPacientes(string nombre)
        {
            Medico medico = personas.OfType<Medico>()
                .FirstOrDefault(m => m.Nombre == nombre);
            if (medico != null)
            {
                Console.WriteLine($"Lista de pacientes del medico {nombre}: ");
                foreach (var paciente in medico.ListaPacientes)
                    Console.WriteLine($"- {paciente.ToString()}");
                return;
            }
            
            Console.WriteLine("No se ha encontrado al doctor");
        }

        public static void EliminarPaciente(string nombreDoctor, string nombrePaciente)
        {
            Medico medico = personas.OfType<Medico>()
                .FirstOrDefault(m => m.Nombre == nombreDoctor);
            if (medico != null)
            {
                Paciente paciente = medico.ListaPacientes.FirstOrDefault(p => p.Nombre == nombrePaciente);
                if (paciente != null)
                {
                    medico.ListaPacientes.Remove(paciente);
                    personas.Remove(paciente);
                    return;
                }
            }

            Console.WriteLine("No se a encontrado alguno de los nombres, vuelva a intentarlo");
        }

        public static void ListaDePersonas()
        {
            Console.WriteLine("Lista de personas en el hospital: ");
            foreach (var persona in personas)
                persona.ToString();
        }

        public static Administrativo PedirAdministrativo()
        {
            Personal personal = PedirPersonal();
            Console.WriteLine("Escriba el mail del administrativo");
            string mail = Console.ReadLine();
            Console.WriteLine("Escriba la contraseña del mail del administrativo");
            string contraseña = Console.ReadLine();

            return new Administrativo(mail,contraseña, personal);
        }

        public static Medico PedirMedico()
        {
            Personal personal = PedirPersonal();
            Console.WriteLine("Introduzca el numero de planta donde opera el medico");
            int numeroDePlanta = ToolKit.SacarEntero();

            return new Medico(numeroDePlanta, personal);
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

        public static void ModificarPaciente()
        {
            switch (Menu.MenuOpcionesPaciente())
            {
                case 1:
                    ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 1);
                    break;
                case 2:
                    ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 2);
                    break;
                case 3:
                    ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 3);
                    break;
                case 4:
                    ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 4);
                    break;
                case 5:
                    ModificarEnfermedad("paciente");
                    Console.ReadKey();
                    break;
            }
        }

        public static void ModificarMedico()
        {
            switch (Menu.MenuOpcionesMedico())
            {
                case 1:
                    ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 1);
                    break;
                case 2:
                    ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 2);
                    break;
                case 3:
                    ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 3);
                    break;
                case 4:
                    ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 4);
                    break;
                case 5:
                    ModificarAtributosPersonal("medico", 1);
                    break;
                case 6:
                    ModificarAtributosPersonal("medico", 1);
                    break;
                case 7:
                    ModificarAtributosPersonal("medico", 1);
                    break;
                case 8:
                    ModificarNumeroDePlanta("medico");
                    break;
            }
        }

        public static void ModificarAdministrativo()
        {
            switch (Menu.MenuOpcionesAdministrativo())
            {
                case 1:
                    ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 1);
                    break;
                case 2:
                    ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 2);
                    break;
                case 3:
                    ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 3);
                    break;
                case 4:
                    ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 4);
                    break;
                case 5:
                    ModificarAtributosPersonal("administrativo", 1);
                    break;
                case 6:
                    ModificarAtributosPersonal("administrativo", 2);
                    break;
                case 7:
                    ModificarAtributosPersonal("administrativo", 3);
                    break;
                case 8:
                    ModificarAtributosAdministrativo("administrativo" , 1);
                    break;
                case 9:
                    ModificarAtributosAdministrativo("administrativo", 2);
                    break;
            }
        }

        public static void ModificarAtributosPersona(string nombre, int opcion)
        {
            Persona persona = personas.FirstOrDefault(p => p.Nombre == nombre);
            switch (opcion)
            {
                case 1:
                    if (persona != null)
                    {
                        persona.Nombre = ToolKit.PedirNombre();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
                case 2:
                    if (persona != null)
                    {
                        Console.WriteLine("Introduzca el nuevo valor de edad");
                        persona.Edad = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
                case 3:
                    if (persona != null)
                    {
                        Console.WriteLine("Introduzca el nuevo valor del dni");
                        persona.Dni = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
                case 4:
                    if (persona != null)
                    {
                        Console.WriteLine("Introduzca el nuevo valor de letra del dni");
                        persona.LetraDni = ToolKit.SacarChar();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
            }
        }

        public static void ModificarAtributosPersonal(string nombre, int opcion)
        {
            Personal personal = personas.OfType<Personal>().FirstOrDefault(p => p.Nombre == nombre);
            switch (opcion)
            {
                case 1:
                    
                    if (personal != null)
                    {
                        Console.WriteLine("Introduzca el nuevo valor del salario");
                        personal.Salario = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
                case 2:
                    if (personal != null)
                    {
                        Console.WriteLine("Introduzca el nuevo valor de los años cotizados");
                        personal.AñoCotizados = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
                case 3:
                    if (personal != null)
                    {
                        Console.WriteLine("Introduzca el nuevo valo de año en el que entro al hospital");
                        personal.FechaDelAlta = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
            }
        }

        public static void ModificarEnfermedad(string nombre)
        {
            Paciente paciente = personas.OfType<Paciente>().FirstOrDefault(p => p.Nombre == nombre);
            if (paciente != null)
            {
                Console.WriteLine("Escriba la nueva enfermedad");
                paciente.Enfermedad = Console.ReadLine();
                Console.WriteLine("Modificado con exito");
            }

            Console.WriteLine("El noombre que has pasado no se ha encontrado");
        }

        public static void ModificarNumeroDePlanta(string nombre)
        {
            Medico medico = personas.OfType<Medico>().FirstOrDefault(p => p.Nombre == nombre);
            if (medico != null)
            {
                Console.WriteLine("Escriba la nueva enfermedad");
                medico.NumeroDePlanta = ToolKit.SacarEntero();
                Console.WriteLine("Modificado con exito");
            }

            Console.WriteLine("El noombre que has pasado no se ha encontrado");
        }

        public static void ModificarAtributosAdministrativo(string nombre, int opciones)
        {
            Administrativo administrativo = personas.OfType<Administrativo>().FirstOrDefault(p => p.Nombre == nombre);
            switch (opciones)
            {
                case 1:
                    if (administrativo != null)
                    {
                        Console.WriteLine("Escriba el nuevo correo");
                        administrativo.Mail = Console.ReadLine();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
                case 2:
                    if (administrativo != null)
                    {
                        Console.WriteLine("Escriba la nueva contraseña");
                        administrativo.Contraseña = Console.ReadLine();
                        Console.WriteLine("Modificado con exito");
                        break;
                    }

                    Console.WriteLine("El noombre que has pasado no se ha encontrado");
                    break;
            }
        }
    }
}