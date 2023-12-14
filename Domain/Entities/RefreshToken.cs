namespace Domain.Entities;
    public class RefreshToken : BaseEntity{
        
        public int UsuarioId { get; set; }
        public User  Usuario { get; set; }
        public string  Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public DateTime Created { get; set; }
        public DateTime ? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
        
    }
