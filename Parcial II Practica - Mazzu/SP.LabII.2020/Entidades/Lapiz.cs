using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Lapiz : Utiles, ISerializa,IDeserializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public Lapiz()
        {

        }

        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio)
           : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }

        public override bool PrciosCuidados
        {
            get { return true; }
        }

        public string Path
        {
            get
            {
                return Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + @"\Mazzucchelli.Juan.Lapiz.xml";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.UtilesToString());
            sb.AppendLine(this.color.ToString());
            sb.AppendLine(this.trazo.ToString());
            return sb.ToString();
        }

        public bool Xml()
        {
            bool ret = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(this.Path, Encoding.UTF8))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Lapiz));
                    xs.Serialize(writer, this);
                    ret = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Falló la serialización. Razones: " + e.Message);
            }

            return ret;
        }

        bool IDeserializa.Xml(out Lapiz l)
        {
            bool ret = false;
            l = default(Lapiz);
            try
            {
                using (XmlTextReader reader = new XmlTextReader(this.Path))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(Lapiz));
                    l = (Lapiz)xs.Deserialize(reader);
                }
                ret = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Falló la deserialización. Razones: " + e.Message);
            }

            return ret ;
        }
    }
    
        public enum ETipoTrazo
        {
            Fino,
            Grueso,
            Medio
        }
}
