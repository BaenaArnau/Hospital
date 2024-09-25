namespace Hospital
{
    public class Administrativo : Personal
    {
        protected string mail;
        protected string contraseña;

        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Contraseña
        {
            get { return contraseña; }
            set { contraseña = value; }
        }

        public Administrativo()
        {
        }

        public Administrativo(string mail, string contraseña, int salario, int añoCotizados, int fechaDelAlta, string nombre, int edad, int dni, char letraDni) : base(salario, añoCotizados, fechaDelAlta, nombre, edad, dni, letraDni)
        {
            this.mail = mail;
            this.contraseña = contraseña;
        }

        public Administrativo(string mail, string contraseña, Personal personal) : base(personal.Salario, personal.AñoCotizados, personal.FechaDelAlta, personal.Nombre, personal.Edad, personal.Dni, personal.LetraDni)
        {
            this.mail = mail;
            this.contraseña = contraseña;
        }

        public override string ToString()
        {
            return $"{base.ToString()}: Personal administrativo con mail:{mail} y contraseña:{contraseña}";
        }
    }
}