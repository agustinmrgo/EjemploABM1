using EjemploABM1.Entidades;

namespace EjemploABM1.Entidades
{
    class Producto
    {
        public string NomP { get; set; }
        public string MarcaP { get; set; }
        public decimal PrecioP { get; set; }

        public Producto(string nomP, string marcaP, decimal precioP)
        {
            this.NomP = nomP;
            this.MarcaP = marcaP;
            this.PrecioP = precioP;
        }

        public Producto()
        {
            this.NomP = null;
            this.MarcaP = null;
            this.PrecioP = 0;
        }
    }
}