using System.Collections.Generic;

namespace Hospital
{
    public class Historial
    {
        protected List<Cita> citas;
        protected List<string> diagnosticos;
        protected List<string> tratamiento;
        protected string notas;

        public List<Cita> Citas
        {
            get { return citas; }
            set { citas = value; }
        }

        public List<string> Diagnosticos
        {
            get { return diagnosticos; }
            set { diagnosticos = value; }
        }

        public List<string> Tratamiento
        {
            get { return tratamiento; }
            set { tratamiento = value; }
        }

        public string Notas
        {
            get { return notas; }
            set { notas = value; }
        }

        public Historial()
        {
            citas = new List<Cita>();
            diagnosticos = new List<string>();
            tratamiento = new List<string>();
            notas = "";
        }

        public Historial(List<string> diagnosticos, List<string> tratamiento, string notas) : this()
        {
            this.diagnosticos = diagnosticos;
            this.tratamiento = tratamiento;
            this.notas = notas;
        }

        public override string ToString()
        {
            string resultado = "Mostrando historial: \n";

            resultado += "Lista de citas: \n";
            foreach (var cita in Citas)
                resultado += $"-  {cita.ToString()} \n";
            resultado += "Lista de diagnosticos: \n";
            foreach (var diagnostico in Diagnosticos)
                resultado += $"-  {diagnostico} \n";
            resultado += "Lista de tratamiento: \n";
            foreach (var tratamiento in Tratamiento)
                resultado += $"-  {tratamiento} \n";
            resultado += $@"Notas: 
{notas}";

            return resultado;
        }
    }
}