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
                switch (Menu.MenuPrincipal())
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
                        string nombreDoctor = ToolKit.PedirNombre("Doctor");
                        Hospital.ListarPacientes(nombreDoctor);
                        Hospital.EliminarPaciente(nombreDoctor, ToolKit.PedirNombre("Paciente"));
                        break;
                    case 7:
                        Hospital.ListaDePersonas();
                        break;
                    case 8:
                        Hospital.ModificarPaciente();
                        break;
                    case 9:
                        Hospital.ModificarMedico();
                        break;
                    case 10:
                        Hospital.ModificarAdministrativo();
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}
