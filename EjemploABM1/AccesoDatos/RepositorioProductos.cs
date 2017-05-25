using System.Collections.Generic;
using EjemploABM1.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace EjemploABM1.AccesoDatos
{
    class RepositorioProductos
    {
        private SqlCommand ObtenerComando()
        {
            SqlConnection conn = new SqlConnection();

            //conn.ConnectionString = @"Server=AGUSTINDELL\SQLEXPRESS;Database=EjemploABM;Trusted_Connection=true;";
            conn.ConnectionString = @"Server=AGUSTIN-PC\SQLEXPRESS;Database=EjemploABM;Trusted_Connection=true;";

            var com = new SqlCommand();

            com.Connection = conn;

            return com;
        }

        public void AgregarProd (Producto producto)
        {
            var com = this.ObtenerComando();
            com.CommandText = "GuardarProducto";
            com.Parameters.AddWithValue("Nombre", producto.NomP);
            com.Parameters.AddWithValue("Marca", producto.MarcaP);
            com.Parameters.AddWithValue("Precio", producto.PrecioP);
            com.CommandType = CommandType.StoredProcedure;
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }

        public void BorrarProducto (string nomB, string marcaB)
        {
            var com = ObtenerComando();
            com.CommandText = "BorrarProducto";
            com.Parameters.AddWithValue("Nombre", nomB);
            com.Parameters.AddWithValue("Marca", marcaB);
            com.CommandType = CommandType.StoredProcedure;
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }

        public List<string> BuscarProducto (string nom,string marca)
        {
            var encontrados = new List<string>();
            var com = ObtenerComando();
            com.CommandText = "BuscarProducto";
            com.Parameters.AddWithValue("Nombre", nom);
            com.Parameters.AddWithValue("Marca", marca);
            com.CommandType = CommandType.StoredProcedure;
            com.Connection.Open();
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var prod = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetDecimal(3);
                encontrados.Add(prod);
            }
            com.Connection.Close();
            return encontrados;
        }

        public List<string> MostrarProductos ()
        {
            var productos = new List<string>();
            var com = ObtenerComando();
            com.CommandText = "SELECT * FROM Producto";
            com.Connection.Open();
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var prod = reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetDecimal(3);
                productos.Add(prod);
            }
            com.Connection.Close();
            return productos;
        }
    }
}
