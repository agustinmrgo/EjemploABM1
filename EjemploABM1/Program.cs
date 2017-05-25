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

            string opcion;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("\n##############\nElija un menu:\n##############\n");
                Console.WriteLine("1. Administrar clientes");

                Console.WriteLine("2. Administrar productos");

                Console.WriteLine("3. Salir");

                Console.Write("Ingrese la opción: ");
                opcion = Console.ReadLine();
                Console.WriteLine("");
                Console.ResetColor();

                switch (opcion)
                {
                    case "1":
                        AdministracionClientes menuC = new AdministracionClientes();
                        menuC.menuCliente();
                        break;
                    case "2":
                        AdministracionProductos menuP = new AdministracionProductos();
                        menuP.menuProducto();
                        break;
                    default:
                        break;
                }

            } while (opcion!="3");
        }
    }
}
/* 
 * BD con tabla 'Cliente' - atributos: Id (unico autoincremental), Apellido y Nombre 
 */