using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    public class Hospital
    {
        public static List<Persona> personas = new List<Persona>();

        /// <summary>
        /// Metodo que permite dar de alta un medico
        /// </summary>
        public static void DarDeAltaMedico()
        {
            personas.Add(PedirMedico());
            Console.WriteLine("Operacion terminada con exito");
        }

        /// <summary>
        /// Metodo que permite dar de alta un paciente
        /// </summary>
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
                    paciente.MedicoDeCabecera = medico;
                    personas.Add(paciente);
                    Console.WriteLine($"Paciente {paciente.Nombre} dado de alta con el doctor {medico.Nombre}.");
                    return;
                }
                else
                    Console.WriteLine("Escriba un nombre correcto de los doctores de la plantilla.");
            }
        }

        /// <summary>
        /// Metodo que permite dar de alta un administrativo
        /// </summary>
        public static void DarDeAltaAdministrativo()
        {
            personas.Add(PedirAdministrativo());
            Console.WriteLine("Operacion terminada con exito");
        }

        /// <summary>
        /// Metodo que nos muestra en forma de lista los atributos de los medicos
        /// </summary>
        public static void ListarMedicos()
        {
            Console.WriteLine("Lista de medicos: ");
            foreach (var empleado in personas.OfType<Medico>())
            {
                Console.WriteLine($"- {empleado.ToString()}");
            }
        }

        /// <summary>
        /// Metodo que nos lista una de pacientes de un medico especifico
        /// </summary>
        /// <param name="nombre">Variable que nos dira el nombre del medico</param>
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

        /// <summary>
        /// Metodo que nos permite eliminar a un paciente de un doctor especifico
        /// </summary>
        /// <param name="nombrePaciente">Nombre del paciente a eliminar</param>
        public static void EliminarPaciente(string nombrePaciente)
        {
            Paciente paciente = personas.OfType<Paciente>().FirstOrDefault(p => p.Nombre == nombrePaciente);

            if (paciente != null)
            {
                paciente.MedicoDeCabecera = null;
                personas.Remove(paciente);
                return;
            }

            Console.WriteLine("No se a encontrado alguno de los nombres, vuelva a intentarlo");
        }

        /// <summary>
        /// Metodo que lista todas las personas que hay en el hospital
        /// </summary>
        public static void ListaDePersonas()
        {
            Console.WriteLine("Lista de personas en el hospital: ");
            foreach (var persona in personas)
                persona.ToString();
        }

        /// <summary>
        /// Metodo que crea un administrativo con sus atributos
        /// </summary>
        /// <returns>Devuelve un administrativo</returns>
        public static Administrativo PedirAdministrativo()
        {
            Personal personal = PedirPersonal();
            Console.WriteLine("Escriba el mail del administrativo");
            string mail = Console.ReadLine();
            Console.WriteLine("Escriba la contraseña del mail del administrativo");
            string contraseña = Console.ReadLine();

            return new Administrativo(mail, contraseña, personal);
        }

        /// <summary>
        /// Metodo que crea un medico con sus atributos
        /// </summary>
        /// <returns>Devuelve un medico</returns>
        public static Medico PedirMedico()
        {
            Personal personal = PedirPersonal();
            Console.WriteLine("Introduzca el numero de planta donde opera el medico");
            int numeroDePlanta = ToolKit.SacarEntero();

            return new Medico(numeroDePlanta, personal);
        }

        /// <summary>
        /// Metodo que crea una persona del personal con sus atributos
        /// </summary>
        /// <returns>Devuelve una persona del personal</returns>
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

        /// <summary>
        /// Metodo que crea un paciente con sus atributos
        /// </summary>
        /// <returns>Devuelve un peciente</returns>
        public static Paciente PedirPaciente()
        {
            Persona persona = PedirPersona();
            Console.WriteLine("Escriba el historial del paciente");
            return new Paciente(persona, PedirHistorial());
        }

        /// <summary>
        /// Metodo que crea una persona con sus atributos
        /// </summary>
        /// <returns>Devuelve una persona</returns>
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

        /// <summary>
        /// Metodo que nos permite modificar los atributos de una persona, para esto nos hace falta un nombre y la opcion que quiere modificar
        /// </summary>
        /// <param name="nombre">Variable que representa el nombre</param>
        /// <param name="opcion">Variable que nos permite gestionar que opcion hay que ejecutar</param>
        public static void ModificarAtributosPersona(string nombre, int opcion)
        {
            Persona persona = personas.FirstOrDefault(p => p.Nombre == nombre);

            if (persona != null)
            {
                switch (opcion)
                {
                    case 1:
                        persona.Nombre = ToolKit.PedirNombre();
                        Console.WriteLine("Modificado con exito");
                        break;
                    case 2:
                        Console.WriteLine("Introduzca el nuevo valor de edad");
                        persona.Edad = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    case 3:
                        Console.WriteLine("Introduzca el nuevo valor del dni");
                        persona.Dni = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    case 4:
                        Console.WriteLine("Introduzca el nuevo valor de letra del dni");
                        persona.LetraDni = ToolKit.SacarChar();
                        Console.WriteLine("Modificado con exito");
                        break;
                }
            }
            else
                Console.WriteLine("El noombre que has pasado no se ha encontrado");
        }

        /// <summary>
        /// Metodo que nos permite modificar los atributos de una persona del persona, para esto nos hace falta un nombre y la opcion que quiere modificar
        /// </summary>
        /// <param name="nombre">Variable que representa el nombre</param>
        /// <param name="opcion">Variable que nos permite gestionar que opcion hay que ejecutar</param>
        public static void ModificarAtributosPersonal(string nombre, int opcion)
        {
            Personal personal = personas.OfType<Personal>().FirstOrDefault(p => p.Nombre == nombre);

            if (personal != null)
            {
                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Introduzca el nuevo valor del salario");
                        personal.Salario = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    case 2:
                        Console.WriteLine("Introduzca el nuevo valor de los años cotizados");
                        personal.AñoCotizados = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                    case 3:
                        Console.WriteLine("Introduzca el nuevo valo de año en el que entro al hospital");
                        personal.FechaDelAlta = ToolKit.SacarEntero();
                        Console.WriteLine("Modificado con exito");
                        break;
                }
            }
            else
                Console.WriteLine("El noombre que has pasado no se ha encontrado");
        }

        /// <summary>
        /// Metodo que nos permite modificar los atributos de un paciente, para esto nos hace falta un nombre y la opcion que quiere modificar
        /// </summary>
        /// <param name="nombre">Variable que representa el nombre</param>
        /// <param name="opciones">Variable que nos permite gestionar que opcion hay que ejecutar</param>
        public static void ModificarAtributosPaciente(string nombre, int opciones)
        {
            Paciente paciente = personas.OfType<Paciente>().FirstOrDefault(p => p.Nombre == nombre);
            if (paciente != null)
            {
                switch (opciones)
                {
                    case 1:
                        Console.WriteLine("Escriba la nueva enfermedad");
                        paciente.HistorialMedioco.Diagnosticos.Add(Console.ReadLine());
                        Console.WriteLine("Modificado con exito");
                        break;
                    case 2:
                        Console.WriteLine("Escriba el nombre del nuevo medico de cabecera");
                        string nombreMedico = Console.ReadLine();
                        Medico nuevoMedico = personas.OfType<Medico>()
                            .FirstOrDefault(m => m.Nombre == nombreMedico);
                        if (nuevoMedico != null)
                        {
                            paciente.MedicoDeCabecera = nuevoMedico;
                            Console.WriteLine("Modificado con exito");
                            break;
                        }

                        Console.WriteLine("No se ha encontrado el nuevo medico");
                        break;
                    case 3:
                        ModificarAtributosHistorial(paciente);
                        break;
                }
            }
            else
                Console.WriteLine("El noombre que has pasado no se ha encontrado");
        }

        /// <summary>
        /// Metodo que nos permite modificar el numero de planta donde trabaja un medico, para esto nos hace falta un nombre
        /// </summary>
        /// <param name="nombre">Variable que representa el nombre</param>
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

        /// <summary>
        /// Metodo que nos permite modificar los atributos de un administrativo, para esto nos hace falta un nombre y la opcion que quiere modificar
        /// </summary>
        /// <param name="nombre">Variable que representa el nombre</param>
        /// <param name="opciones">Variable que nos permite gestionar que opcion hay que ejecutar</param>
        public static void ModificarAtributosAdministrativo(string nombre, int opciones)
        {
            Administrativo administrativo = personas.OfType<Administrativo>().FirstOrDefault(p => p.Nombre == nombre);
            if (administrativo != null)
            {
                switch (opciones)
                {
                    case 1:
                        Console.WriteLine("Escriba el nuevo correo");
                        administrativo.Mail = Console.ReadLine();
                        Console.WriteLine("Modificado con exito");
                        break;
                    case 2:
                        Console.WriteLine("Escriba la nueva contraseña");
                        administrativo.Contraseña = Console.ReadLine();
                        Console.WriteLine("Modificado con exito");
                        break;
                }
            }
            else
                Console.WriteLine("El noombre que has pasado no se ha encontrado");
        }

        public static void ListarCitas(Paciente paciente)
        {
            Console.WriteLine($"Lista de las citas del paciente {paciente.Nombre}:");

            foreach (var cita in paciente.HistorialMedioco.Citas)
           
                Console.WriteLine($"-  {cita.ToString()}");
        }

        public static Historial PedirHistorial()
        {
            return new Historial(ToolKit.PedirListaString("diagnostico"), ToolKit.PedirListaString("tratamiento"), ToolKit.PedirString("notas"));
        }

        public static void ModificarAtributosHistorial(Paciente paciente)
        {
            switch (Menu.MenuOpcionesCita())
            {
                case 1:
                    ListarCitas(paciente);
                    DateTime fecha1 = ToolKit.SacarDateTime();
                    Cita cita1 = paciente.HistorialMedioco.Citas.FirstOrDefault(c => c.Medico == paciente.MedicoDeCabecera && c.Fecha == fecha1);
                    if (cita1 == null)
                    {
                        paciente.HistorialMedioco.Citas.Add(new Cita(paciente, paciente.MedicoDeCabecera, fecha1));
                        Console.WriteLine("Se ha añadido con exito la cita al calendario");
                        break;
                    }

                    Console.WriteLine($"El doctor {paciente.MedicoDeCabecera.Nombre} ya tiene una cita para esa fecha");
                    break;
                case 2:
                    ListarCitas(paciente);
                    Console.WriteLine("Introduzca la fecha de la cita que quieres modificar");
                    DateTime fechaActual = ToolKit.SacarDateTime();
                    Cita cita2 = paciente.HistorialMedioco.Citas.FirstOrDefault(c => c.Paciente == paciente && c.Fecha == fechaActual);

                    if (cita2 != null)
                    {
                        Console.WriteLine("Introduzca la nueva fecha para la cita");
                        DateTime nuevaFecha = ToolKit.SacarDateTime();

                        cita2.Fecha = nuevaFecha;
                        Console.WriteLine("Fecha cambiada con exito");
                        break;
                    }

                    Console.WriteLine("No hay planificada niguna cita con esa fecha");
                    break;
                case 3:
                    ListarCitas(paciente);
                    Console.WriteLine("Introduzca la fecha de la cita que quieres eliminar");
                    DateTime fecha = ToolKit.SacarDateTime();
                    Cita citaEliminar = paciente.HistorialMedioco.Citas.FirstOrDefault(c => c.Paciente == paciente && c.Fecha == fecha);

                    if (citaEliminar != null)
                    {
                        paciente.HistorialMedioco.Citas.Remove(citaEliminar);
                        Console.WriteLine("Cita eliminada con exit");
                        break;
                    }

                    Console.WriteLine("No hay planificada niguna cita con esa fecha");
                    break;
                case 4:
                    ListarCitas(paciente);
                    Console.WriteLine("Introduzca un nuevo diagnostico");
                    paciente.HistorialMedioco.Diagnosticos.Add(ToolKit.PedirString("diagnostico"));
                    Console.WriteLine("Diagnostico añadido con exito");
                    break;
            }
        }
    }
}