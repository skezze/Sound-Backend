namespace Sound.Common.Models
{
    public class AudioCollection
    {
        public Guid Id { get; set; }
        public string CollectionName { get; set; }
        public bool IsPrivate { get; set; }
        public AudioFile[] Collection { get; set; }
    }
}