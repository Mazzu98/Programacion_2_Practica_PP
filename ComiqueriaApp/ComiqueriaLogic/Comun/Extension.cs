using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic.Comun
{
    public static class Extension
    {

        public static string FormatearPrecio(this double d)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("$");
            sb.Append(String.Format("{0:0.00}", d));

            return sb.ToString();
        }

    }
}
