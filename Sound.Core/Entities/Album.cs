using Sound.Core.Interfaces.Entities;

namespace Sound.Core.Entities;

public class Album : IEntity
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; }

    public virtual User User { get; set; }
    public virtual ICollection<Sound> Sounds { get; set; }
}