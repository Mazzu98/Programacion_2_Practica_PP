using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PrestamosPersonales;

namespace EntidadFinanciera
{
    public class Financiera
    {
        private List<Prestamo> listaDePrestamos;
        private string razonSocial;

        public List<Prestamo> ListaDePrestamos { get => listaDePrestamos;}
        public string RazonSocial { get => razonSocial;}

        public float InteresesEnDolares 
        {
            get
            {
                float interes = 0;
                foreach(Prestamo prestamo in listaDePrestamos)
                {
                    if(prestamo is PrestamoDolar)
                    {
                        interes += ((PrestamoDolar)prestamo).Interes;
                    }
                }
                return interes;
            }
        }

        public float InteresesEnPesos
        {
            get
            {
                float interes = 0;
                foreach (Prestamo prestamo in listaDePrestamos)
                {
                    if (prestamo is PrestamoPesos)
                    {
                        interes += ((PrestamoPesos)prestamo).Interes;
                    }
                }
                return interes;
            }
        }

        public float InteresesTotales
        {
            get
            {
                return this.InteresesEnDolares + InteresesEnDolares;
            }
        }

        private Financiera()
        {
            listaDePrestamos = new List<Prestamo>();
        }

        public Financiera(string razonSocial) : this()
        {
            this.razonSocial = razonSocial;
        }

        public static explicit operator string(Financiera f)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Razon Social: {f.razonSocial}");
            sb.AppendLine($"Intereses Totales: {f.InteresesTotales}");
            sb.AppendLine($"Intereses En Pesos: {f.InteresesEnPesos}");
            sb.AppendLine($"Intereses En Dolares: {f.InteresesEnDolares}");
            sb.AppendLine();
            foreach(Prestamo prestamo in f.listaDePrestamos)
            {
                sb.AppendLine(prestamo.Mostrar());
            }
            return sb.ToString();
        }

        public static string Mostrar(Financiera f)
        {
            return (string)f;
        }

        public void OrdenarPrestamos()
        {
            this.listaDePrestamos.Sort(Prestamo.OrdenarPorFecha);
        }

        private float calcularInteresGanado(TipoDePrestamo TipoPrestamo)
        {
            float ret = 0;
            switch(TipoPrestamo)
            {
                case TipoDePrestamo.Pesos: ret = this.InteresesEnPesos; 
                    break;
                case TipoDePrestamo.Dolares: ret = this.InteresesEnDolares; 
                    break;
                case TipoDePrestamo.Todos: ret = this.InteresesTotales; 
                    break;
            }
            return ret;
        }

        public static bool operator ==(Financiera f, Prestamo p)
        {
            bool ret =  false;
            if((object)f != null && (object)p != null)
            {
                foreach(Prestamo prestmo in f.listaDePrestamos)
                { 
                    if(prestmo == p)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }

        public static bool operator !=(Financiera f, Prestamo p)
        {
            return !(f == p);
        }

        public static Financiera operator +(Financiera f, Prestamo p)
        {
            if(f != p)
            {
                f.listaDePrestamos.Add(p);
            }
            return f;
        }

    }
}
