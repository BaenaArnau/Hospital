namespace Hospital
{
    public class Personal : Persona
    {
        protected int salario;
        protected int añoCotizados;
        protected int fechaDelAlta;

        public Personal()
        {
        }

        public Personal(int salario, int añoCotizados, int fechaDelAlta, string nombre, int edad, int dni, char letraDni) : base(nombre, edad, dni, letraDni)
        {
            this.salario = salario;
            this.añoCotizados = añoCotizados;
            this.fechaDelAlta = fechaDelAlta;
        }

        public Personal(int salario, int añoCotizados, int fechaDelAlta, Persona persona) : base(persona.Nombre, persona.Edad, persona.Dni, persona.LetraDni)
        {
            this.salario = salario;
            this.añoCotizados = añoCotizados;
            this.fechaDelAlta = fechaDelAlta;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, con salario:{salario} lleva trabajando{añoCotizados} y empezo a trabajar aqui el {fechaDelAlta}";
        }

        public int Salario { get { return salario; } }
        public int AñoCotizados { get { return añoCotizados; } }
        public int FechaDelAlta { get { return fechaDelAlta; } }
    }
}