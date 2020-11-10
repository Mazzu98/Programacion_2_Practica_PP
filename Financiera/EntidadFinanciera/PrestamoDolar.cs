using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrestamosPersonales
{
    public class PrestamoDolar : Prestamo
    {
        private PeriodicidadDePagos periodicidad;

        public float Interes
        {
            get
            {
                return CalcularInteres();
            }
        }

        public PrestamoDolar(float monto, DateTime vencimiento, PeriodicidadDePagos periodicidad) : base(monto, vencimiento)
        {
            this.periodicidad = periodicidad;
        }

        public PrestamoDolar(Prestamo prestamo, PeriodicidadDePagos periodicidad) : this(prestamo.Monto, prestamo.Vencimiento, periodicidad)
        {
        }

        public override void ExtenderPlazo(DateTime nuevoVencimiento)
        {
            int diferenciaDias;
            diferenciaDias = (int)(nuevoVencimiento - this.vencimiento).TotalDays;
            base.monto += (diferenciaDias * 2.5f);

            base.Vencimiento = nuevoVencimiento;
        }

        private float CalcularInteres()
        {
            return base.Monto * (float) this.periodicidad / 100;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Mostrar());
            sb.AppendLine($"Periodicidad: {this.periodicidad}");
            sb.AppendLine($"Interes: {this.Interes}");

            return sb.ToString();
        }
    }
}
