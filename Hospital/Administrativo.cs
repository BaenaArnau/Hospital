namespace Hospital
{
    public class Administrativo : Personal
    {
        protected string mail;

        public Administrativo()
        {
        }

        public Administrativo(string mail, int salario, int añoCotizados, int fechaDelAlta, string nombre, int edad, int dni, char letraDni) : base(salario, añoCotizados, fechaDelAlta, nombre, edad, dni, letraDni)
        {
            this.mail = mail;
        }

        public Administrativo(string mail, Personal personal) : base(personal.Salario, personal.AñoCotizados, personal.FechaDelAlta, personal.Nombre, personal.Edad, personal.Dni, personal.LetraDni)
        {
            this.mail = mail;
        }

        public override string ToString()
        {
            return $"{base.ToString()}: Personal administrativo";
        }
    }
}