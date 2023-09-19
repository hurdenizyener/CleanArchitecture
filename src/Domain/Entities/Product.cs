using Domain.Common;

namespace Domain.Entities;

public class Product : BaseEntity<Guid>
{
    public Guid CategoryId { get; set; }
    public string ProductName { get; set; }
    public short UnitsInStock { get; set; }
    public Decimal UnitPrice { get; set; }


    public virtual Category Category { get; set; }

    public Product()
    {

    }

    public Product(Guid id, Guid categoryId, string productName, short unitsInStock, decimal unitPrice)
    {
        Id = id;
        CategoryId = categoryId;
        ProductName = productName;
        UnitsInStock = unitsInStock;
        UnitPrice = unitPrice;

    }
}
