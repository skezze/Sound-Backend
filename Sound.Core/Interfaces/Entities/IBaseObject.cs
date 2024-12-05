namespace Sound.Core.Interfaces.Entities;

public interface IBaseObject: IEntity
{
    public DateTime CreatedAt { get; set; }
}