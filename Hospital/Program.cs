using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static Menu menu = new Menu();

        /// <summary>
        /// Metodo que se ejecuta cuando arranca el programa y llama al menu principal
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            menu.MenuPrincipal();
        }
    }
}
