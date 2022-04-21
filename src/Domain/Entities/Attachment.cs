namespace Domain.Entities
{
    public class Attachment
    {
        #region
        public Attachment(string name, string path, long size)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Path = path;
            Size = size;
        }
        #endregion

        public string Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }

        public ICollection<Possession> Possessions { get; set; }
    }
}