using EjemploABM1.Entidades;
using System;
using System.Linq;

namespace EjemploABM1.Presentacion
{
    class AdministracionClientes
    {
        GestorClientes gestorClientes = new GestorClientes();
        public void menuCliente()
        {
            string opcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===================================");
                Console.WriteLine("             MENU CLIENTES");
                Console.WriteLine("===================================");
                Console.WriteLine("");
                Console.WriteLine("1 - Agregar clientes");
                Console.WriteLine("2 - Borrar un cliente");
                Console.WriteLine("3 - Modificar un cliente");
                Console.WriteLine("4 - Mostrar los clientes guardados");
                Console.WriteLine("5 - Buscar");
                Console.WriteLine("6 - ObtenerMayor");
                Console.WriteLine("7 - Salir");

                Console.Write("Ingrese la opción: ");
                opcion = Console.ReadLine();
                Console.ResetColor();
                switch (opcion)
                {
                    case "1":
                        String ape;
                        String nom;
                        String precioP;
                        Console.WriteLine("");
                        Console.Write("Ingrese el Apellido: ");
                        ape = Console.ReadLine();
                        Console.Write("Ingrese el Nombre: ");
                        nom = Console.ReadLine();
                        Console.Write("Ingrese edad: ");
                        precioP = Console.ReadLine();
                        int edad = int.Parse(precioP);
                        gestorClientes.AgregarCliente(new Cliente(ape, nom, edad));
                        Console.WriteLine("Cliente agregado correctamente");
                        Console.WriteLine("");
                        break;
                    case "2":
                        String apeB;
                        String nomB;
                        Console.WriteLine("");
                        Console.Write("Ingrese el Apellido del Cliente que quiere borrar: ");
                        apeB = Console.ReadLine();
                        Console.Write("Ingrese el Nombre del Cliente que quiere borrar: ");
                        nomB = Console.ReadLine();
                        if (gestorClientes.BorrarCliente(apeB, nomB))
                            Console.Write("Cliente borrado correctamente");
                        else
                            Console.Write("No se ha podido borrar el Cliente");
                        Console.WriteLine("");
                        break;

                    case "3":
                        String apeV;
                        String nomV;
                        String apeN;
                        String nomN;
                        int edadN;
                        Console.WriteLine("");
                        Console.Write("Ingrese el Apellido del Cliente que quiere modificar: ");
                        apeV = Console.ReadLine();
                        Console.Write("Ingrese el Nombre del Cliente que quiere modificar: ");
                        nomV = Console.ReadLine();
                        if (gestorClientes.Buscar(apeV, nomV))
                        {
                            Console.Write("Ingrese el nuevo Apellido: ");
                            apeN = Console.ReadLine();
                            Console.Write("Ingrese el nuevo Nombre: ");
                            nomN = Console.ReadLine();
                            Console.Write("Ingrese nueva edad: ");
                            edadN = int.Parse(Console.ReadLine());
                            gestorClientes.ModificarCliente(apeV, nomV, new Cliente(apeN, nomN,edadN));
                            Console.WriteLine("Cliente modificado correctamente");
                        }
                        else
                        {
                            Console.WriteLine("No se ha encontrado el cliente");
                        }
                        Console.WriteLine("");
                        break;                    
                    case "4":
                        var clientes = gestorClientes.MostrarClientes();
                        Console.WriteLine("");
                        Console.WriteLine("********************************");
                        for (int i = 0; i < clientes.Count; i++)
                        {
                            var linea = clientes[i].Split(' ');
                            Console.WriteLine("----------");
                            Console.Write("Apellido: ");
                            Console.WriteLine(linea[0]);
                            Console.Write("Nombre: ");
                            Console.WriteLine(linea[1]);
                            Console.Write("Edad: ");
                            Console.WriteLine(linea[2]);
                            Console.WriteLine("----------");
                        }
                        Console.WriteLine("********************************");
                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.Write("Ingrese el Apellido: ");
                        string apeBuscar = Console.ReadLine();
                        Console.Write("Ingrese el Nombre: ");
                        string nomBuscar = Console.ReadLine();
                        var clientesB = gestorClientes.MostrarClientes(apeBuscar,nomBuscar);
                        Console.WriteLine("");
                        Console.WriteLine("********************************");
                        for (int i = 0; i < clientesB.Count; i++)
                        {
                            var linea = clientesB[i].Split(' ');
                            Console.WriteLine("----------");
                            Console.Write("Apellido: ");
                            Console.WriteLine(linea[0]);
                            Console.Write("Nombre: ");
                            Console.WriteLine(linea[1]);
                            Console.WriteLine("----------");
                        }
                        Console.WriteLine("********************************");
                        Console.WriteLine("");
                        break;
                    case "6":
                        int mayor = gestorClientes.ObtenerMayor();
                        Console.WriteLine("El mayor en edad tiene: "+mayor+" años");
                        break;
                }
            } while (opcion != "7");

        }
    }
}
