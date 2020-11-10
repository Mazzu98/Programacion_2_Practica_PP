using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sacapunta : Utiles
    {
        public bool deMetal;
        public Sacapunta(bool deMetal, double precio,string marca) 
            : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override bool PrciosCuidados
        {
            get { return false; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.UtilesToString());
            sb.AppendLine(this.deMetal.ToString());
            return sb.ToString();
        }

    }
}
