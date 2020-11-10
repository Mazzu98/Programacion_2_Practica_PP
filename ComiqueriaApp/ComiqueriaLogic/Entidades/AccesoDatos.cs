using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComiqueriaLogic.Entidades
{
    public class AccesoDatos
    {
        public delegate void Delegado(AccionesDB a);
        public static event Delegado evento;

        private SqlConnection conexion;
        private SqlCommand comando;


        public AccesoDatos(string cadena)
        {
            this.conexion = new SqlConnection(cadena);
        }

        public List<Producto> ObtenerListado()
        {
            List<Producto> productos = new List<Producto>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "Select * from Productos";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Producto p = new Producto(lector.GetInt32(0), lector.GetString(1), lector.GetInt32(2), (float)lector.GetDouble(3));

                    productos.Add(p);
                }

                lector.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return productos;
        }

        public bool AgregarDatos(string descripcion, double precio, int stock)
        {
            bool ret = false;
            try
            {
                this.comando = new SqlCommand();

                string sql = "INSERT INTO Productos (descripcion,precio,stock) VALUES (@Descripcion,@Precio,@Stock)";
                this.comando.Parameters.AddWithValue("@Descripcion", descripcion);
                this.comando.Parameters.AddWithValue("@Precio", precio);
                this.comando.Parameters.AddWithValue("@Stock", stock);

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    ret = false;
                }
                evento(AccionesDB.Insert);
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }


            return ret;
        }

        public bool ModificarDato(float precio,int codigo)
        {
            bool ret = true;
            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@codigo", codigo);
                this.comando.Parameters.AddWithValue("@precio", precio);
                
                string query = "UPDATE Productos SET Precio = @precio, WHERE Codigo = @codigo";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = query;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int rows = this.comando.ExecuteNonQuery();

                if (rows == 0)
                {
                    ret = false;
                }
                evento(AccionesDB.Update);
            }
            catch (Exception)
            {
                ret = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return ret;
        }

        public bool EliminatDato(int codigo)
        {
            bool ret = true;
            try
            {
                this.comando = new SqlCommand();

                string query = "DELETE FROM Productos WHERE Codigo = @codigo";
                this.comando.Parameters.AddWithValue("@codigo", codigo);

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = query;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int rows = this.comando.ExecuteNonQuery();

                if (rows == 0)
                {
                    ret = false;
                }
                evento(AccionesDB.Delete);
            }
            catch (Exception e)
            {
                ret = false;
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return ret;
        }
    }
}
