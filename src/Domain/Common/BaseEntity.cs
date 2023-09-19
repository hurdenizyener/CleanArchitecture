namespace Domain.Common;

public abstract class BaseEntity<TId>
{
    public TId Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }

    public BaseEntity()
    {
        Id = default;
    }

    public BaseEntity(TId id)
    {
        Id = id;
    }

}
