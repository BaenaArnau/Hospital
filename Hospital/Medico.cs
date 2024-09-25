using System.Collections.Generic;

namespace Hospital
{
    public class Medico : Personal
    {
        public Medico()
        {
            pacientes = new List<Paciente>();
        }

        public Medico(int salario, int añoCotizados, int fechaDelAlta, string nombre, int edad, int dni, char letraDni) : base(salario, añoCotizados, fechaDelAlta, nombre, edad, dni, letraDni)
        {
            pacientes = new List<Paciente>();
        }

        public Medico(Personal personal) : base(personal.Salario, personal.AñoCotizados, personal.FechaDelAlta, personal.Nombre, personal.Edad, personal.Dni, personal.LetraDni)
        {
            pacientes = new List<Paciente>();
        }

        public List<Paciente> Pacientes
        {
            get { return pacientes; }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}