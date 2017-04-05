using EjemploABM1.Entidades;

namespace EjemploABM1.Entidades
{
    class Producto
    {
        private string nomP { get; set; }
        private string marcaP { get; set; };
        private decimal precioP { get; set; };

        public Producto(string nomP, string marcaP, decimal precioP)
        {
            this.nomP = nomP;
            this.marcaP = marcaP;
            this.precioP = precioP;
        }

        public Producto()
        {
            this.nomP = null;
            this.marcaP = null;
            this.precioP = 0;
        }
    }
}