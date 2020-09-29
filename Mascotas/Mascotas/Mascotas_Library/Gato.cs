using System.Text;

namespace Mascotas_Library
{
    public class Gato : Mascota
    {
        public Gato(string nombre,string raza): base(nombre, raza) { }

        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("gato - ");
            sb.Append(base.DatosCompletos());

            return sb.ToString();
        }

        public static bool operator ==(Gato g1, Gato g2)
        {
            return ((Mascota)g1 == (Mascota)g2);
        }

        public static bool operator !=(Gato g1, Gato g2)
        {
            return !(g1 == g2);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Gato)
            {
                ret = this == (Gato)obj;
            }
            return ret;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
