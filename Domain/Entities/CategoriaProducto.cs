namespace Domain.Entities;
    public class CategoriaProducto : BaseEntity
    {

        public string  Nombre { get; set; }

        public ICollection<Producto>  Productos { get; set; }

    }
