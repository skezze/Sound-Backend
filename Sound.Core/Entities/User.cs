using Sound.Core.Interfaces.Entities;

namespace Sound.Core.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }
    public string NormalizedUserName { get; set; }
    public string PasswordHash { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreDateTime { get; set; } = DateTime.UtcNow;

    public virtual ICollection<UserRole>? UserRoles { get; set; } = null;
    public virtual ICollection<UserSound>? UserSounds { get; set; } = null;
}