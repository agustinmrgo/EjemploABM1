using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploABM1.Entidades
{
    class Cliente
    {
        public String nombre { get; set; }
        public String apellido { get; set; }
        public int edad { get; set; }

        public Cliente(String apellido, String nombre,int edad)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
        }

        public Cliente(String apellido, String nombre)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = 0;
        }

        public Cliente()
        {
            this.nombre = null;
            this.apellido = null;
            this.edad = 0;
        }
    }
}
