using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace PrestamosPersonales
{
    public abstract class Prestamo
    {
        protected float monto;
        protected DateTime vencimiento;

        public float Monto { get => monto;}
        public DateTime Vencimiento
        {
            get => vencimiento;
            
            set
            {
                if(value > DateTime.Now)
                {
                    vencimiento = value;
                }
                else
                {
                    vencimiento = DateTime.Now;
                }
                
            }
        }

        public Prestamo(float monto,DateTime vencimiento)
        {
            this.monto = monto;
            this.vencimiento = vencimiento;
        }

        public static int OrdenarPorFecha(Prestamo p1,Prestamo p2)
        {
            int ret = 0;
            if(p1.vencimiento < p2.vencimiento)
            {
                ret = -1;
            }
            else if (p1.vencimiento > p2.vencimiento)
            {
                ret = 1;
            }
            return ret;
        }

        public abstract void ExtenderPlazo(DateTime nuevoVencimiento);

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Monto: {this.monto}");
            sb.AppendLine($"Vencimiento: {this.vencimiento}");

            return sb.ToString();
        }
    }
}
