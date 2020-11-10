using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Archivos
    {
        public static bool LeerArchivo(string ruta, out string texto)
        {
            bool ret = false;
            try
            {
                using (StreamReader sr = new StreamReader(ruta))
                {
                    texto = sr.ReadToEnd();
                }
                ret = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                texto = null;
            }
            return ret;
        }
    }
}
