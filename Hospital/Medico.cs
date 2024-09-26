using System.Collections.Generic;

namespace Hospital
{
    public class Medico : Personal
    {
        private List<Paciente> listaPacientes;
        protected int numeroDePlanta;

        public int NumeroDePlanta
        {
            get { return numeroDePlanta; }
            set { numeroDePlanta = value; }
        }
        public List<Paciente> ListaPacientes 
        {
            get { return listaPacientes ?? (listaPacientes = new List<Paciente>()); } // Asegurar que no sea null
            set { listaPacientes = value ?? new List<Paciente>(); }
        }

        public Medico()
        {
            listaPacientes = new List<Paciente>();
        }

        public Medico(int numeroDePlanta, int salario, int añoCotizados, int fechaDelAlta, string nombre, int edad, int dni, char letraDni) : base(salario, añoCotizados, fechaDelAlta, nombre, edad, dni, letraDni)
        {
            this.numeroDePlanta = numeroDePlanta;
            listaPacientes = new List<Paciente>();
        }

        public Medico(int numeroDePlanta, Personal personal) : base(personal.Salario, personal.AñoCotizados, personal.FechaDelAlta, personal.Nombre, personal.Edad, personal.Dni, personal.LetraDni)
        {
            this.numeroDePlanta = numeroDePlanta;
            listaPacientes = new List<Paciente>();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, trabajando el la planta {numeroDePlanta} del hospital";
        }
    }
}