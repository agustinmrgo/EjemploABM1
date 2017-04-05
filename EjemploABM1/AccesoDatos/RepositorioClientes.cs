using EjemploABM1.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploABM1.AccesoDatos
{
    class RepositorioClientes
    {
        private SqlCommand ObtenerComando()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Server=AGUSTINDELL\SQLEXPRESS;Database=EjemploABM;Trusted_Connection=true;";
            //conn.ConnectionString = @"Server=AGUSTIN-PC\SQLEXPRESS;Database=EjemploABM;Trusted_Connection=true;";
            var com = new SqlCommand();
            com.Connection = conn;

            return com;
        }

        public void Guardar(Cliente c)
        {
            var com = ObtenerComando();
            com.CommandText = "INSERT INTO Cliente (Apellido, Nombre,Edad) VALUES (@Apellido, @Nombre,@Edad)";
            com.Parameters.AddWithValue("@Apellido", c.apellido);
            com.Parameters.AddWithValue("@Nombre", c.nombre);
            com.Parameters.AddWithValue("@Edad", c.edad);
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
            /* Usar SqlCommand().Parameters.AddWithValue("@Parametro", Valor) para agregar 
             * sin que suceda una inyeccion de codigo SQL */
        }

        //public void Borrar(string nombre, string apellido)
        //{
        //    var com = ObtenerComando();
        //    com.CommandText = "DELETE FROM Cliente WHERE apellido=@Apellido AND Nombre=@Nombre";
        //    com.Parameters.AddWithValue("Apellido", apellido);
        //    com.Parameters.AddWithValue("Nombre", nombre);
        //    com.Connection.Open();
        //    com.ExecuteNonQuery();
        //    com.Connection.Close();

        //}

        public void Borrar(string nombre, string apellido)
        {
            var com = ObtenerComando();
            com.CommandText = "Eliminar @Apellido, @Nombre";
            com.Parameters.AddWithValue("@Apellido", apellido);
            com.Parameters.AddWithValue("@Nombre", nombre);
            com.Connection.Open();
            com.ExecuteNonQuery();
            com.Connection.Close();
        }


        public List<string> Buscar(string Apellido, string Nombre)
        {
            var listaClientes = new List<string>();
            var com = ObtenerComando();
            com.CommandText = "SELECT * FROM Cliente WHERE Apellido = @Apellido AND Nombre = @Nombre";
            com.Parameters.AddWithValue("@Apellido", Apellido);
            com.Parameters.AddWithValue("@Nombre", Nombre);
            com.Connection.Open();
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var cliente = reader.GetInt32(0)+" "+reader.GetString(1) +" "+ reader.GetString(2) + " " + reader.GetInt32(3);
                listaClientes.Add(cliente);
            }
            com.Connection.Close();
            return listaClientes;
        }

        public void Modificar(Cliente viejo,Cliente nuevo)
        {
            var com = ObtenerComando();
            com.CommandText = "UPDATE Cliente SET Apellido=@ApellidoN, Nombre=@NombreN WHERE Nombre=@NombreV AND Apellido=@ApellidoV";
            com.Parameters.AddWithValue("@ApellidoN", nuevo.apellido);
            com.Parameters.AddWithValue("@NombreN", nuevo.nombre);
            com.Parameters.AddWithValue("@NombreV", viejo.nombre);
            com.Parameters.AddWithValue("@ApellidoV", viejo.apellido);
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

        public List<string> MostrarClientes(string apellido,string nombre)
        {
            var com = ObtenerComando();
            var clientes = new List<string>();
            com.CommandText = "ConsultaClientes 0";
            com.Parameters.AddWithValue("@Apellido", apellido);
            com.Parameters.AddWithValue("@Nombre", nombre);
            com.CommandType = System.Data.CommandType.StoredProcedure; //puedo hacer use de System.Data
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