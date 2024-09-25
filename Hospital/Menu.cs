using System;

namespace Hospital
{
    public class Menu
    {
        public static int MenuPrincipal()
        {
            int option;

            do
            {
                Console.WriteLine(@"
┌────────────────────────────────────────────────────────────┐
│                      MENU  PRINCIPAL                       │
├────────────────────────────────────────────────────────────┤
│  (1)   - Dar de alta un medico                             │
│  (2)   - Dar de alta un paciente, para un médico concreto  │
│  (3)   - Dar de alta personal administrativo               │
│  (4)   - Listar los médicos                                │
│  (5)   - Listar los pacientes de un medico                 │
│  (6)   - Eliminar a un paciente                            │
│  (7)   - Ver la lista de personas del hospital             │
│  (8)   - Modificar paciente                                │
│  (9)   - Modificar medico                                  │
│  (10)  - Modificar administrativo                          │
│  (0)   - Salir                                             │
└────────────────────────────────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 10);

            return option;
        }

        public static int MenuOpcionesMedico()
        {
            int option;

            do
            {
                Console.WriteLine($@"
┌────────────────────────────────────────────────────────────┐
│                MENU  OPCIONES MEDICO                       │
├────────────────────────────────────────────────────────────┤
{OpcionesPersona()}
{OpcionesPersonal()}
│  (8) - Modificar el numero de planta donde opera           │
└────────────────────────────────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 8);

            return option;
        }

        public static int MenuOpcionesAdministrativo()
        {
            int option;

            do
            {
                Console.WriteLine($@"
┌────────────────────────────────────────────────────────────┐
│                MENU  OPCIONES ADMINISTRATIVO               │
├────────────────────────────────────────────────────────────┤
{OpcionesPersona()}
{OpcionesPersonal()}
│  (8) - Modificar mail                                      │
│  (9) - Modificar contraseña                                │
└────────────────────────────────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 9);

            return option;
        }

        public static int MenuOpcionesPaciente()
        {
            int option;

            do
            {
                Console.WriteLine($@"
┌────────────────────────────────────────────────────────────┐
│                MENU  OPCIONES PACIENTE                     │
├────────────────────────────────────────────────────────────┤
{OpcionesPersona()}
│  (5) - Modificar enfermedad                                │
└────────────────────────────────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 5);

            return option;
        }

        public static string OpcionesPersona()
        {
            return @"│  (1) - Modificar nombre                                    │
│  (2) - Modificar edad                                      │
│  (3) - Modificar DNI                                       │
│  (4) - Modificar letra del DNI                             │";
        }

        public static string OpcionesPersonal()
        {
            return @"│  (5) - Modificar salario                                   │
│  (6) - Modificar los años cotizados                        │
│  (7) - Modificar año de entrada al hospital                │";
        }
    }
}