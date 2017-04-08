using EjemploABM1.AccesoDatos;
using EjemploABM1.Entidades;
using System.Collections.Generic;

namespace EjemploABM1.Presentacion
{
    class GestorClientes
    {
        RepositorioClientes repo = new RepositorioClientes();
        public void AgregarCliente(Cliente c)
        {
            repo.Guardar(c);
        }

        public bool BorrarCliente(string Apellido, string Nombre)
        {
            int encontrados = repo.Buscar(Apellido, Nombre).Count;
            if (encontrados != 0)
            {
                repo.Borrar(Apellido, Nombre);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Buscar(string Apellido, string Nombre)
        {
            if (repo.Buscar(Apellido, Nombre).Count != 0) return true;
            return false;
        }

        public void ModificarCliente(string Apellido, string Nombre, Cliente nuevoCliente)
        //recibe apellido y nombre viejos y cliente nuevo
        {
            if (repo.Buscar(Apellido, Nombre).Count != 0)
                repo.Modificar(new Cliente(Apellido, Nombre), nuevoCliente);
            else return;
        }

        public List<string> MostrarClientes()
        {
            return repo.MostrarClientes();
        }

        public List<string> BuscarClientesPorNombre(string apellido, string nombre)
        {
            return repo.BuscarClientesPorNombre(apellido,nombre);
        }

        public int ObtenerMayor()
        {
            return repo.ObtenerMayor();
        }
    }
}
