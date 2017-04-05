using EjemploABM1.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploABM1
{
    class Program
    {
        static void Main(string[] args)
            {
            AdministracionProductos menuP = new AdministracionProductos();
            AdministracionClientes menuC = new AdministracionClientes();
            menuC.menuCliente();
            menuP.menuProducto();
        }
    }
}
/* 
 * BD con tabla 'Cliente' - atributos: Id (unico autoincremental), Apellido y Nombre 
 */