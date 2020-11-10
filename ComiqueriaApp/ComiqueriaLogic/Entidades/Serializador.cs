using ComiqueriaLogic.Comun;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ComiqueriaLogic.Entidades
{
    public static class Serializador <T> where T: class, new()
    {
        public static bool EscribirBinario(string path, T dato)
        {
            bool ret;
            try
            {
                BinaryFormatter ser = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    ser.Serialize(fs, dato);
                }
                ret = true;
            }
            catch (Exception)
            {
                ret = false;
            }
            return ret;
        }

        public static T LeerBinario(string path)
        {
            T datos = new T();
            try
            {
                BinaryFormatter ser = new BinaryFormatter();
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    datos = (T)ser.Deserialize(fs);
                }
            }
            catch (Exception)
            {

            }
            return datos;
        }

        public static bool EsctibirtXml(string ruta, T datos)
        {
            bool ret = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(ruta, Encoding.UTF8))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    xs.Serialize(writer, datos);
                    ret = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Falló la serialización. Razones: " + e.Message);
            }

            return ret;
        }

        public static T LeertXml(string ruta)
        {
            T datoRet = null;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(ruta))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
                    datoRet = (T)xs.Deserialize(reader);
                }
            }
            catch (ArgumentException ex)
            {
                ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
            }
            catch(DirectoryNotFoundException ex)
            {
                throw new ComiqueriaException("Error:Diirectorio no encontrado",ex);
            }
            catch(Exception)
            {
                throw new Exception("Mensaje divertiido, riase");
            }
            return datoRet;
        }
    }
}
