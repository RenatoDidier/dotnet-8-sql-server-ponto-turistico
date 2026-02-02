namespace Tourism.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public string Title { get; protected set; } = default!;
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }
    
    protected BaseEntity() { }
    protected BaseEntity(Guid id, string title)
    {
        Id = id;
        Title = title;
        CreatedAt = DateTime.UtcNow;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
        UpdatedAt = DateTime.UtcNow;
    }
}
