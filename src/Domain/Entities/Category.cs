using Domain.Common;

namespace Domain.Entities;

public class Category : BaseEntity<Guid>
{
    public string CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = new HashSet<Product>();
    }

    public Category(Guid id, string categoryName) : this()
    {
        Id = id;
        CategoryName = categoryName;
    }
}
