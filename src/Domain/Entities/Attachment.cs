using Domain.Enums;

namespace Domain.Entities;

public class Attachment
{
    #region
    public Attachment(string name, string path, long size, AttachmentType type = AttachmentType.Image)
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
    public AttachmentType Type { get; set; }

    public ICollection<PossessionAttachment> Possessions { get; set; }
}