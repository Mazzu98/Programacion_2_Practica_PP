using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaLavadero
{
    class Lavadero
    {
        private List<Vehiculo> vehiculos;
        private float precioAuto;
        private float precioCamion;
        private float precioMoto;

        private Lavadero()
        {
            this.vehiculos = new List<Vehiculo>();
        }
        public Lavadero(float precioAuto,float precioCamion,float precioMoto) :this()
        {
            this.precioAuto = precioAuto;
            this.precioCamion = precioCamion;
            this.precioMoto = precioMoto;
        }

        public string getVehiculos
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                foreach (Vehiculo vehiculo in vehiculos)
                {
                    if (vehiculo is Auto)
                    {
                        sb.AppendLine(((Auto)vehiculo).MostrarAuto());
                    }
                    else if (vehiculo is Camion)
                    {
                        sb.AppendLine(((Camion)vehiculo).MostrarCamion());
                    }
                    else if (vehiculo is Moto)
                    {
                        sb.AppendLine(((Moto)vehiculo).MostrarMoto());
                    }
                    sb.AppendLine();
                }
                return sb.ToString();
            }
            
        }

        public string getLavadero
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Precio auto: {this.precioAuto}");
                sb.AppendLine($"Precio moto: {this.precioMoto}");
                sb.AppendLine($"Precio camion: {this.precioCamion}");
                sb.AppendLine();
                sb.AppendLine(this.getVehiculos);

                return sb.ToString();
            }
            
        }

        public Double MostrarTotalFacturado()
        {
            Double suma = 0;
            foreach(Vehiculo vehiculo in vehiculos)
            {
                if(vehiculo is Auto)
                {
                    suma += this.precioAuto;
                }
                else if (vehiculo is Moto)
                {
                    suma += this.precioMoto;
                }
                else if (vehiculo is Camion)
                {
                    suma += this.precioCamion;
                }
            }
            return suma;
        }

        public Double MostrarTotalFacturado(EVehiculos eVehiculos)
        {
            Double suma = 0;
            Double precio = 0;

            if(eVehiculos == EVehiculos.Auto)
            {
                precio = this.precioAuto;
            }
            else if (eVehiculos == EVehiculos.Camion)
            {
                precio = this.precioCamion;
            }
            else if (eVehiculos == EVehiculos.Moto)
            {
                precio = this.precioMoto;
            }

            foreach (Vehiculo vehiculo in vehiculos)
            {
                if(vehiculo.GetType().ToString() == eVehiculos.ToString())
                {
                    suma += precio;
                }
            }
            return suma;
        }

        public static bool operator ==(Lavadero l, Vehiculo v)
        {
            bool ret = false;
            foreach(Vehiculo vehiculo in l.vehiculos)
            {
                if(vehiculo == v)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        public static bool operator !=(Lavadero l, Vehiculo v)
        {
            return !(l == v);
        }

        public static Lavadero operator +(Lavadero l, Vehiculo v)
        {
            if(l != v)
            {
                l.vehiculos.Add(v);
            }
            return l;
        }

        public static Lavadero operator -(Lavadero l, Vehiculo v)
        {
            if (l == v)
            {
                l.vehiculos.Remove(v);
            }
            return l;
        }

        public static int OrdenarVehiculosPorPatente(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Patente.ToString(),v2.Patente.ToString());
        }

        public static int OrdenarVehiculosPorMMarca(Vehiculo v1, Vehiculo v2)
        {
            return String.Compare(v1.Marca.ToString(), v2.Marca.ToString());
        }


    }
}
