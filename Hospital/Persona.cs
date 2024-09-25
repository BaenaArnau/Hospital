namespace Hospital
{
    public class Persona
    {
        protected string nombre;
        protected int edad;
        protected int dni;
        protected char letraDni;

        public string Nombre { 
            get { return nombre; }
            set { nombre = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public char LetraDni
        {
            get { return letraDni; }
            set { letraDni = value; }
        }

        public Persona()
        {
        }

        public Persona(string nombre, int edad, int dni, char letraDni)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.dni = dni;
            this.letraDni = letraDni;
        }

        public override string ToString()
        {
            return $"{nombre} con DNI:{dni}{letraDni} con {edad} años";
        }
    }
}