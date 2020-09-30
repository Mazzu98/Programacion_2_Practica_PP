using System.Text;

namespace Mascotas_Library
{
    public class Perro : Mascota
    {
        private int edad;
        private bool esAlfa;

        public Perro(string nombre,string raza) : base(nombre, raza)
        {
            this.edad = 0;
            this.esAlfa = false;
        }
        
        public Perro(string nombre, string raza,int edad, bool esAlfa) : this(nombre,raza)
        {
            this.edad = edad;
            this.esAlfa = esAlfa;
        }

        protected override string Ficha()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Perro - ");
            sb.Append(this.DatosCompletos());
            sb.Append(", ");
            if(this.esAlfa == true)
            {
                sb.Append("alfa de la manada");
            }
            sb.Append($"edad {this.edad}");

            return sb.ToString();
        }

        public static bool operator ==(Perro p1, Perro p2)
        {
            return ((Mascota)p1 == (Mascota)p2) && (p1.edad == p2.edad);
        }

        public static bool operator !=(Perro p1, Perro p2)
        {
            return !(p1 == p2);
        }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj is Perro)
            {
                ret = this == (Perro)obj;
            }
            return ret;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static explicit operator int(Perro p)
        {
            return p.edad;
        }

        public override string ToString()
        {
            return this.Ficha();
        }
    }
}
