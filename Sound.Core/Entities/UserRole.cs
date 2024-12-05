using Sound.Core.Interfaces.Entities;

namespace Sound.Core.Entities;

public class UserRole : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }
    
    public virtual User User { get; set; }
    public virtual Role Role { get; set; }
}