using System.Text;

namespace Mascotas_Library
{
    public abstract class Mascota
    {
        private string nombre;
        private string raza;

        public string Nombre { get => nombre; }
        public string Raza { get => raza;  }

        public Mascota(string nombre, string raza)
        {
            this.nombre = nombre;
            this.raza = raza;
        }

        protected abstract string Ficha();

        protected virtual string DatosCompletos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.nombre);
            sb.Append(" - ");
            sb.Append(this.raza);

            return sb.ToString();
        }


        public static bool operator ==(Mascota m1, Mascota m2)
        {
            bool ret = false;
            if((object)m1 != null && (object)m2 != null)
            {
                if(m1.nombre == m2.nombre && m1.raza == m2.raza)
                {
                    ret = true;
                }
            }
            return ret;
        }
        public static bool operator !=(Mascota m1, Mascota m2)
        {
            return !(m1 == m2);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if(obj is Mascota)
            {
                ret = this == (Mascota)obj;
            }
            return ret;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
