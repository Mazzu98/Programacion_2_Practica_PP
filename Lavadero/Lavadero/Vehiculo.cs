using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaLavadero
{
    public class Vehiculo
    {
        protected string patente;
        protected Byte cantRuedas;
        protected EMarcas marca;

        public string Patente { get => patente;}
        public EMarcas Marca { get => marca;}

        public Vehiculo(string patente,Byte cantRuedas,EMarcas marca)
        {
            this.patente = patente;
            this.cantRuedas = cantRuedas;
            this.marca = marca;
        }

        protected string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Patente: {this.patente}");
            sb.AppendLine($"Cantidad de ruedas: {this.cantRuedas}");
            sb.AppendLine($"Marca: {this.marca}");

            return sb.ToString();
        }

        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            bool ret = false;
            if((object)v1 != null && (object)v2 != null )
            {
                if(v1.marca == v2.marca && v1.patente == v2.patente)
                {
                    ret = true;
                }
            }
            return ret;
        }

        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1 == v2);
        }
    }
}
