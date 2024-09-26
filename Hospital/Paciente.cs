namespace Hospital
{
    public class Paciente : Persona
    {
        protected Medico medicoDeCabecera;
        protected Historial historialMedico;

        public Historial HistorialMedioco
        {
            get { return historialMedico; }
            set { historialMedico = value; }
        }

        public Medico MedicoDeCabecera
        {
            get { return medicoDeCabecera; }
            set
            {
                if (medicoDeCabecera != null)
                    medicoDeCabecera.ListaPacientes.Remove(this);

                medicoDeCabecera = value;

                if (medicoDeCabecera != null)
                    medicoDeCabecera.ListaPacientes.Add(this);
            }
        }

        public Paciente()
        {
            historialMedico = new Historial();
        }

        public Paciente(string nombre, int edad, int dni, char letraDni, Historial historialMedico) : base(nombre, edad, dni, letraDni)
        {
            this.historialMedico = historialMedico;
        }

        public Paciente(Persona persona,Historial historialMedico) : base(persona.Nombre, persona.Edad, persona.Dni, persona.LetraDni)
        {
            this.historialMedico = historialMedico;
        }

        public override string ToString()
        {
            return $@"{base.ToString()}: 
{HistorialMedioco.ToString()}";
        }
    }
}