namespace Sound.Common.Models
{
    public class AudioFile
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Producer { get; set; }
        public string ImageLocation { get; set; }
        public string FileLocation { get; set; }
    }
}
