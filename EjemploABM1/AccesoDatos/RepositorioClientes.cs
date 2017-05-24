using EjemploABM1.Entidades;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace EjemploABM1.AccesoDatos
{
    class RepositorioClientes
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

        public void Guardar(Cliente c)
        {
            var com = ObtenerComando();
            com.CommandText = "GuardarCliente";
            com.Parameters.AddWithValue("Apellido", c.apellido);
            com.Parameters.AddWithValue("Nombre", c.nombre);
            com.Parameters.AddWithValue("Edad", c.edad);
            com.CommandType = CommandType.StoredProcedure;
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }

        public void Borrar(string apellido, string nombre)
        {
            var com = ObtenerComando();
            com.CommandText = "BorrarCliente";
            com.Parameters.AddWithValue("Apellido", apellido);
            com.Parameters.AddWithValue("Nombre", nombre);
            com.CommandType = CommandType.StoredProcedure;
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }

        public List<string> Buscar(string Apellido, string Nombre)
        {
            var encontrados = new List<string>();
            var com = ObtenerComando();
            com.CommandText = "BuscarCliente";
            com.Parameters.AddWithValue("Apellido", Apellido);
            com.Parameters.AddWithValue("Nombre", Nombre);

            com.CommandType = CommandType.StoredProcedure;

            com.Connection.Open();

            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var cliente = reader.GetString(1) +" "+ reader.GetString(2) + " " + reader.GetInt32(3);
                encontrados.Add(cliente);
            }
            com.Connection.Close();
            return encontrados;
        }

        public void Modificar(Cliente viejo, Cliente nuevo)
        {
            var com = ObtenerComando();
            com.CommandText = "ModificarCliente";
            com.Parameters.AddWithValue("ApellidoN", nuevo.apellido);
            com.Parameters.AddWithValue("NombreN", nuevo.nombre);
            com.Parameters.AddWithValue("EdadN", nuevo.edad);
            com.Parameters.AddWithValue("NombreV", viejo.nombre);
            com.Parameters.AddWithValue("ApellidoV", viejo.apellido);
            com.CommandType = CommandType.StoredProcedure;
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }

        public List<string> MostrarClientes()
        {
            var clientes = new List<string>();
            var com = ObtenerComando();
            com.CommandText = "SELECT * FROM Cliente";
            com.Connection.Open();
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var cliente = reader.GetString(1) + " " + reader.GetString(2)+ " " +reader.GetInt32(3);
                clientes.Add(cliente);
            }
            com.Connection.Close();
            return clientes;
        }

        public List<string> BuscarClientesPorNombre (string apellido,string nombre)
        {
            var com = ObtenerComando();
            var clientes = new List<string>();
            com.CommandText = "BuscarClientesPorNom";
            com.Parameters.AddWithValue("Apellido", apellido);
            com.Parameters.AddWithValue("Nombre", nombre);
            com.CommandType = CommandType.StoredProcedure; //puedo hacer use de System.Data
            com.Connection.Open();
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                clientes.Add(reader.GetString(1)+" "+reader.GetString(2)+" "+reader.GetInt32(3));
                //getint32 si tengo atributo edad
            }
            com.Connection.Close();
            return clientes;
        }

        public int ObtenerMayor()
        {
            var com = ObtenerComando();
            com.CommandText = "SELECT dbo.ObtenerMayor()";
            com.Connection.Open();
            int resultado = (int) com.ExecuteScalar(); //devuelve un scalar!
            com.Connection.Close();
            return resultado;
        }
            
    }
}