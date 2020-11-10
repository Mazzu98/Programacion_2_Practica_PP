using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cartuchera<T> where T: Utiles
    {

        public delegate void Delegado(object sender,EventArgs e);
        public event Delegado EventoPrecio;

        protected int capacidad;
        private List<T> elementos;

        public List<T> Elementos { get => elementos; }
        public double PrecioTotal
        {
            get { return SumaPrecios(); }
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad)
            :this()
        {
            this.capacidad = capacidad;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(typeof(T).Name);
            sb.AppendLine(this.capacidad.ToString());
            sb.AppendLine(this.elementos.Count.ToString());
            sb.AppendLine(this.PrecioTotal.ToString());
            foreach(T u in this.elementos)
            {
                if(u != null)
                {
                    sb.AppendLine(u.ToString());
                    sb.AppendLine("-------------------------------------------");
                }
                
            }
            return sb.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> c, T t)
        {
            if((object)c != null )
            {
                if(c.elementos.Count < c.capacidad)
                {
                    c.elementos.Add(t);
                }
                else
                {
                     throw new CartucheraLlenaException();
                }
                if (c.PrecioTotal> 85 && c.EventoPrecio != null)
                {
                    c.EventoPrecio(c,EventArgs.Empty);
                }
            }
            return c;
        }


        private double SumaPrecios()
        {
            double suma = 0;
            foreach(T u in this.elementos)
            {
                if(u != null)
                {
                    suma += u.precio;
                }
                
            }
            return suma;
        }
        
    }
}
