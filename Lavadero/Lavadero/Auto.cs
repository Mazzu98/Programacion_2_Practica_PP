using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaLavadero
{
    class Auto : Vehiculo
    {
        protected int cantidadAsientos;

        public Auto(int cantAssientoss,string patente, byte cantRuedas, EMarcas marca) : base(patente, cantRuedas, marca)
        {
            this.cantidadAsientos = cantAssientoss;
        }

        public string MostrarAuto()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.Mostrar());
            sb.AppendLine($"Cantidad de asientos: {this.cantidadAsientos}");

            return sb.ToString();
        }
    }
}
