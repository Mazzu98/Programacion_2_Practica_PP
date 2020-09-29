using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffShore
{
    public class Cliente
    {
        private string _aliasParaIncognito;
        private string _nombre;
        private eTipoCliente _tipoDeCliente;

        private Cliente()
        {
            _nombre = "NN";
            _aliasParaIncognito = "Sin Alias";
            _tipoDeCliente = eTipoCliente.SinTipo;
        }
        public Cliente(eTipoCliente tipoCliente) : this()
        {
            this._tipoDeCliente = tipoCliente;
        }

        public Cliente(eTipoCliente tipoCliente, string nombre) : this(tipoCliente)
        {
            this._nombre = nombre;
        }

        private void CrearAlias()
        {
            Random rnd = new Random();

            this._aliasParaIncognito = rnd.Next(1000, 9999).ToString() + this._tipoDeCliente.ToString();
        }

        public string GetAlias()
        {
            if(this._aliasParaIncognito == "Sin Alias")
            {
                CrearAlias();
            }
            return _aliasParaIncognito;
        }

        private string RetornarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Nombre: {this._nombre}");
            sb.AppendLine($"Alias: {this.GetAlias()}");
            sb.Append($"Tipo de Cliente: {this._tipoDeCliente}");

            return sb.ToString();
        }

        public static string RetornarDatos(Cliente cliente)
        {
            return cliente.RetornarDatos();
        }

    }
}
