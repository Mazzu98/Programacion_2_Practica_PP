using OffShore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_CuentasOffShore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Apellido y Nombre";//Cambiar por SU apellido y SU nombre
            Cliente mauri = new Cliente(eTipoCliente.PoliticoCorrupto,
            "Mauri");
            Cliente fariña = new Cliente(eTipoCliente.Financista, "Fariña");
            Cliente mesias = new Cliente(eTipoCliente.JugadorDeFutbol,
            "Lio");
            CuentaOffShore messiOff = new CuentaOffShore(mesias, 123, 15000);
            CuentaOffShore mauriOff = new CuentaOffShore(mauri, 678, 25000);
            CuentaOffShore lazaroOff = new CuentaOffShore("Lázaro",
            eTipoCliente.EmpresarioCorructo, 456, 56000);
            CuentaOffShore otraDeMauri = new CuentaOffShore(mauri, 678,
            50000);
            CuentaOffShore fariOff = new CuentaOffShore(fariña, 666, 3500);
            ParaisoFiscal panamaPappers = eParaisosFiscales.Panamá;
            panamaPappers += messiOff;
            panamaPappers += mauriOff;
            panamaPappers += lazaroOff;
            panamaPappers.MostrarParaiso();
            panamaPappers += otraDeMauri;
            panamaPappers -= messiOff;
            panamaPappers -= fariOff;
            panamaPappers.MostrarParaiso();
            Console.ReadKey();
        }
    }
}
