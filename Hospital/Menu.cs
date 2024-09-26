using System;

namespace Hospital
{
    public class Menu
    {
        /// <summary>
        /// Metodo que gestiona las opciones del menu principal y lo muestra por pantalla
        /// </summary>
        /// <returns>Devuelve un entero con el valor elegido por el usuario</returns>
        public int VisualizacionMenuPrincipal()
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

        /// <summary>
        /// Metodo que gestiona las opciones del menu de opciones del medico y lo muestra por pantalla
        /// </summary>
        /// <returns>Devuelve un entero con el valor elegido por el usuario</returns>
        public int MenuOpcionesMedico()
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

        /// <summary>
        /// Metodo que gestiona las opciones del menu de opciones del administrativo y lo muestra por pantalla
        /// </summary>
        /// <returns>Devuelve un entero con el valor elegido por el usuario</returns>
        public int MenuOpcionesAdministrativo()
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

        /// <summary>
        /// Metodo que gestiona las opciones del menu de opcines del paciente y lo muestra por pantalla
        /// </summary>
        /// <returns>Devuelve un entero con el valor elegido por el usuario</returns>
        public int MenuOpcionesPaciente()
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
│  (6) - Modificar medico de cabecera                        │
│  (7) - Gestionar citas                                     │
└────────────────────────────────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 7);

            return option;
        }

        /// <summary>
        /// Metodo que nos devuelve las opciones genericas de persona
        /// </summary>
        /// <returns>Devuelve una cadena de tecto formateada para seguir la estructura de los menus</returns>
        public string OpcionesPersona()
        {
            return @"│  (1) - Modificar nombre                                    │
│  (2) - Modificar edad                                      │
│  (3) - Modificar DNI                                       │
│  (4) - Modificar letra del DNI                             │";
        }

        /// <summary>
        /// Metodo que nos devuelve las opciones genericas de personal
        /// </summary>
        /// <returns>Devuelve una cadena de tecto formateada para seguir la estructura de los menus</returns>
        public string OpcionesPersonal()
        {
            return @"│  (5) - Modificar salario                                   │
│  (6) - Modificar los años cotizados                        │
│  (7) - Modificar año de entrada al hospital                │";
        }

        public static int MenuOpcionesCita()
        {
            int option;

            do
            {
                Console.WriteLine($@"
┌────────────────────────────────────────────────────────────┐
│                MENU  OPCIONES PACIENTE                     │
├────────────────────────────────────────────────────────────┤
│  (1) - Pedir cita con el medico de cabecera                │
│  (2) - Modificar cita                                      │
│  (3) - Eliminar cita                                       │
└────────────────────────────────────────────────────────────┘
                ");

                if (!int.TryParse(Console.ReadLine(), out option))
                    Console.WriteLine("Opcion invalida");

            } while (option < 0 || option > 3);

            return option;
        }

        /// <summary>
        /// Metodo que controla las opciones del submenu de paciente
        /// </summary>
        public void ModificarPaciente()
        {
            switch (MenuOpcionesPaciente())
            {
                case 1:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 1);
                    break;
                case 2:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 2);
                    break;
                case 3:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 3);
                    break;
                case 4:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("paciente"), 4);
                    break;
                case 5:
                    Hospital.ModificarAtributosPaciente(ToolKit.PedirNombre("paciente"), 1);
                    break;
                case 6:
                    Hospital.ModificarAtributosPaciente(ToolKit.PedirNombre("paciente"), 2);
                    break;
                case 7:
                    Hospital.ModificarAtributosPaciente(ToolKit.PedirNombre("paciente"), 3);
                    break;
            }
        }

        /// <summary>
        /// Metodo que controla las opciones del submenu de medico
        /// </summary>
        public void ModificarMedico()
        {
            switch (MenuOpcionesMedico())
            {
                case 1:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 1);
                    break;
                case 2:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 2);
                    break;
                case 3:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 3);
                    break;
                case 4:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("medico"), 4);
                    break;
                case 5:
                    Hospital.ModificarAtributosPersonal("medico", 1);
                    break;
                case 6:
                    Hospital.ModificarAtributosPersonal("medico", 1);
                    break;
                case 7:
                    Hospital.ModificarAtributosPersonal("medico", 1);
                    break;
                case 8:
                    Hospital.ModificarNumeroDePlanta("medico");
                    break;
            }
        }

        /// <summary>
        /// Metodo que controla las opciones del submenu de administrativo
        /// </summary>
        public void ModificarAdministrativo()
        {
            switch (MenuOpcionesAdministrativo())
            {
                case 1:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 1);
                    break;
                case 2:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 2);
                    break;
                case 3:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 3);
                    break;
                case 4:
                    Hospital.ModificarAtributosPersona(ToolKit.PedirNombre("administrativo"), 4);
                    break;
                case 5:
                    Hospital.ModificarAtributosPersonal("administrativo", 1);
                    break;
                case 6:
                    Hospital.ModificarAtributosPersonal("administrativo", 2);
                    break;
                case 7:
                    Hospital.ModificarAtributosPersonal("administrativo", 3);
                    break;
                case 8:
                    Hospital.ModificarAtributosAdministrativo("administrativo", 1);
                    break;
                case 9:
                    Hospital.ModificarAtributosAdministrativo("administrativo", 2);
                    break;
            }
        }

        public void MenuPrincipal()
        {
            while (true)
            {
                switch (VisualizacionMenuPrincipal())
                {
                    case 1:
                        Hospital.DarDeAltaMedico();
                        break;
                    case 2:
                        Hospital.ListarMedicos();
                        Hospital.DarDeAltaPaciente();
                        break;
                    case 3:
                        Hospital.DarDeAltaAdministrativo();
                        break;
                    case 4:
                        Hospital.ListarMedicos();
                        break;
                    case 5:
                        Hospital.ListarPacientes(ToolKit.PedirNombre("Doctor"));
                        break;
                    case 6:
                        Hospital.ListarPacientes(ToolKit.PedirNombre("Doctor"));
                        Hospital.EliminarPaciente(ToolKit.PedirNombre("Paciente"));
                        break;
                    case 7:
                        Hospital.ListaDePersonas();
                        break;
                    case 8:
                        ModificarPaciente();
                        break;
                    case 9:
                        ModificarMedico();
                        break;
                    case 10:
                        ModificarAdministrativo();
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}