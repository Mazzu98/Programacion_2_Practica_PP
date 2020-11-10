using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Goma : Utiles
    {
        public bool soloLapiz;

        public Goma(bool soloLapiz,string marca, double precio) 
            : base(marca, precio)
        {
            this.soloLapiz = soloLapiz;
        }

        public override bool PrciosCuidados
        {
            get { return true; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.UtilesToString());
            sb.AppendLine(this.soloLapiz.ToString());
            return sb.ToString();
        }
    }
}
