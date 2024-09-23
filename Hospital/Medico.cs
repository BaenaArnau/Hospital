using System.Collections.Generic;

namespace Hospital
{
    public class Medico : Personal
    {
        private List<Paciente> pacientes;

        public Medico()
        {
            pacientes = new List<Paciente>();
        }

        public Medico(int salario, int añoCotizados, int fechaDelAlta, string nombre, int edad, int dni, string letraDni) : base(salario, añoCotizados, fechaDelAlta, nombre, edad, dni, letraDni)
        {
            pacientes = new List<Paciente>();
        }

        public Medico(Personal personal) : base(personal.Salario, personal.AñoCotizados, personal.FechaDelAlta, personal.Nombre, personal.Edad, personal.Dni, personal.LetraDni)
        {
            pacientes = new List<Paciente>();
        }

        public override string ToString()
        {
            string resultado = $@"{base.ToString()}
Listado de los pacientes:";
            foreach (var paciente in pacientes)
                resultado += $"  -{paciente.ToString()} \n";
            return resultado;
        }
    }
}