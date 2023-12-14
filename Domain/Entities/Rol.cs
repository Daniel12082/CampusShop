namespace Domain.Entities;
    public class Rol : BaseEntity{
        
        public string  Nombre { get; set; }
        public ICollection<User>  Usuarios { get; set; } = new HashSet<User>();
        public ICollection<UserRol>  UsuarioRoles { get; set; }
        
}
