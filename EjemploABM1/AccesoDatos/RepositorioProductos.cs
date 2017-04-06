using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploABM1.Entidades;
using System.Data.SqlClient;

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

        public void AgregarProd(Producto producto)
        {
            var com = this.ObtenerComando();
            com.CommandText = "INSERT INTO Producto (Nombre,Marca,Precio) VALUES (@Nombre, @Marca,@Precio)";
            com.Parameters.AddWithValue("@Nombre", producto.NomP);
            com.Parameters.AddWithValue("@Marca", producto.MarcaP);
            com.Parameters.AddWithValue("@Precio", producto.PrecioP);
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }

        public List<string> MostrarProductos()
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
