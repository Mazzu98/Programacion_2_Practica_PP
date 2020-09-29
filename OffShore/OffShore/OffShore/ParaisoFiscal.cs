using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffShore
{
    public class ParaisoFiscal
    {
        private List<CuentaOffShore> _listadoCuentas; 
        private eParaisosFiscales _lugar;
        public static int cantidadDeCuentas;
        public static DateTime fechaInicioActividades;

        static ParaisoFiscal()
        {
            ParaisoFiscal.cantidadDeCuentas = 0;
            ParaisoFiscal.fechaInicioActividades = DateTime.Now;
        }

        private ParaisoFiscal()
        {
            this._listadoCuentas = new List<CuentaOffShore>();
        }

        private ParaisoFiscal(eParaisosFiscales lugar) : this()
        {
            this._lugar = lugar;
        }

        public static implicit operator ParaisoFiscal(eParaisosFiscales epf)
        {
            return new ParaisoFiscal(epf);
        }

        public void MostrarParaiso()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n");
            sb.AppendLine($"Fecha de inicio: {fechaInicioActividades}");
            sb.AppendLine($"Lugar: {this._lugar}");
            sb.AppendLine($"Cantidad de cuentas: {ParaisoFiscal.cantidadDeCuentas}");
            sb.AppendLine("*********Listado de CuentasOffShore***********");
            sb.AppendLine();
            foreach (CuentaOffShore cos in this._listadoCuentas)
            {
                sb.AppendLine(Cliente.RetornarDatos(cos.Dueño));
                sb.AppendLine($"Numero de cuenta: {(int)cos}");
                sb.AppendLine($"Saldo: {cos.Saldo}");
                sb.AppendLine();
            }

            Console.WriteLine(sb.ToString());
        }

        public static bool operator ==(ParaisoFiscal pf, CuentaOffShore cos)
        {
            bool ret = false;
            if ((object)pf != null && (object)cos != null)
            {
                foreach (CuentaOffShore cosAux in pf._listadoCuentas)
                {
                    if (cosAux == cos)
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }

        public static bool operator !=(ParaisoFiscal pf, CuentaOffShore cos)
        {
            return !(pf == cos);
        }

        public static ParaisoFiscal operator -(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if (pf == cos)
            {
                pf._listadoCuentas.Remove(cos);
                ParaisoFiscal.cantidadDeCuentas--;
                Console.WriteLine("Cuenta eliminada...");
            }
            else
            {
                Console.WriteLine("La cuenta no existe...");
            }
            return pf;
        }

        public static ParaisoFiscal operator +(ParaisoFiscal pf, CuentaOffShore cos)
        {
            if (pf != cos)
            {
                pf._listadoCuentas.Add(cos);
                ParaisoFiscal.cantidadDeCuentas++;
                Console.WriteLine("Cuenta agregada...");
            }
            else
            {
                foreach (CuentaOffShore cosAux in pf._listadoCuentas)
                {
                    if (cosAux == cos)
                    {
                        cosAux.Saldo += cos.Saldo;
                        Console.WriteLine("Saldos sumados....");
                        break;
                    }
                }
            }
            return pf;
        }
    }
}