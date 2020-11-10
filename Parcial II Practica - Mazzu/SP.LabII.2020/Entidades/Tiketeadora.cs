using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Tiketeadora<T> where T : Utiles
    {
        public static bool ImprimirTiket(Cartuchera<T> c)
        {
            string path = Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\tikets.log";
            bool ret = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(c.PrecioTotal.ToString());


            try
            {
                using (StreamWriter sw = new StreamWriter(path,true))
                {
                    sw.WriteLine(sb.ToString());
                }
                ret = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ret;

        }
    }
}
