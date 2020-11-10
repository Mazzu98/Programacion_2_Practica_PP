using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoPesos : Prestamo
    {
        private float porcentaje;
        
        public float Interes{ 
            get
            {
                return CalcularIntereses();
            }
        }

        public PrestamoPesos(float monto, DateTime vencimiento, float interes) 
            :base(monto, vencimiento)
        {
            this.porcentaje = interes;
        }

        public PrestamoPesos(Prestamo prestamo,float porsentaje) 
            :this(prestamo.Monto,prestamo.Vencimiento,porsentaje)
        {        }

        private float CalcularIntereses()
        {
            return base.Monto * porcentaje / 100;
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            int diferenciaDias;
            diferenciaDias = (int)(nuevoVencimiento - this.vencimiento).TotalDays;
            this.porcentaje += (diferenciaDias * 0.25f);

            base.Vencimiento = nuevoVencimiento;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine($"Porcentaje: {this.porcentaje}%");
            sb.AppendLine($"Interes: {this.Interes}");

            return sb.ToString();
        }

    }
}
