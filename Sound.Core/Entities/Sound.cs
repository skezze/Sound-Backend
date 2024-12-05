using Sound.Core.Interfaces.Entities;

namespace Sound.Core.Entities;

public class Sound : IBaseObject
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public virtual Author Author { get; set; }
    public virtual ICollection<UserSound>? UserSounds { get; set; } = null;
}