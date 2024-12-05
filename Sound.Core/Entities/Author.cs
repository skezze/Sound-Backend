using Sound.Core.Interfaces.Entities;

namespace Sound.Core.Entities;

public class Author : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Album>? Albums { get; set; } = null;
    public virtual ICollection<Sound>? Sounds { get; set; } = null;
}