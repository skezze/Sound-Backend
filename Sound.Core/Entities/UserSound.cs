using Sound.Core.Interfaces.Entities;

namespace Sound.Core.Entities;

public class UserSound : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid SoundId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    public virtual User User { get; set; }
    public virtual Sound Sound { get; set; }
}