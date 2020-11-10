using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Utiles
    {
        public string marca;
        public double precio;
        private bool preciosCuidados;

        public abstract bool PrciosCuidados { get; }

        public Utiles()
        {

        }


        public Utiles(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.marca);
            sb.AppendLine(this.precio.ToString());

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString(); 
        }
    }
}
