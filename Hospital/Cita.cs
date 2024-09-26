using System;

namespace Hospital
{
    public class Cita
    {
        protected Paciente paciente;
        protected Medico medico;
        protected DateTime fecha;

        public Paciente Paciente
        {
            get { return paciente; }
            set { paciente = value; }
        }

        public Medico Medico
        {
            get { return medico; }
            set { medico = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Cita()
        {
        }

        public Cita(Paciente paciente, Medico medico, DateTime fecha)
        {
            this.paciente = paciente;
            this.medico = medico;
            this.fecha = fecha;
        }

        public override string ToString()
        {
            return $"El paciente {paciente.Nombre} tiene una cita con el doctor {medico.Nombre} a las {fecha.ToString()}";
        }
    }
}