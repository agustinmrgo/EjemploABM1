using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploABM1.Entidades;
using EjemploABM1.AccesoDatos;

namespace EjemploABM1.LogicaNegocio
{
    class GestorProductos
    {
        RepositorioProductos repo = new RepositorioProductos();

        public void AgregarProd(Producto producto)
        {
            repo.AgregarProd(producto);
        }

        public List<string> MostrarClientes()
        {
            return repo.MostrarProductos();
        }
    }
}
