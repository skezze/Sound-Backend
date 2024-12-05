using Sound.Core.Interfaces.Entities;

namespace Sound.Core.Entities;

public class Role : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<UserRole>? UserRoles { get; set; } = null;
}