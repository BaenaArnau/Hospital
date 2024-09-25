namespace Hospital
{
    public class Paciente : Persona
    {
        protected string enfermedad;
        protected Medico medicoDeCabecera;

        public string Enfermedad
        {
            get { return enfermedad; }
            set { enfermedad = value; }
        }

        public Medico MedicoDeCabecera
        {
            get { return medicoDeCabecera; }
            set { medicoDeCabecera = value; }
        }

        public Paciente()
        {
        }

        public Paciente(string enfermedad, string nombre, int edad, int dni, char letraDni) : base(nombre, edad, dni, letraDni)
        {
            this.enfermedad = enfermedad;
        }

        public Paciente(string enfermedad, Persona persona) : base(persona.Nombre, persona.Edad, persona.Dni, persona.LetraDni)
        {
            this.enfermedad = enfermedad;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, con {enfermedad}";
        }
    }
}