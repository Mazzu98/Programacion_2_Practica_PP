using ComiqueriaLogic.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic.Comun
{
    class ComiqueriaException : Exception, IArchivoTexto
    {
        public ComiqueriaException(string mensaje,Exception innerException)
            :base(mensaje,innerException)
        {

        }

        public string Ruta => Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\log.txt";

        public string Texto
        {
            get
            {
                return DateTime.Now + this.GetAllMessages(this);
            }
        }

        private string GetAllMessages(Exception exp)
        {
            string message = string.Empty;
            Exception innerException = exp;

            do
            {
                message = message + (string.IsNullOrEmpty(innerException.Message) ? string.Empty : innerException.Message);
                innerException = innerException.InnerException;
            }
            while (innerException != null);

            return message;
        }
    }
}
