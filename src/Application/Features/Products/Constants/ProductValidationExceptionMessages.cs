namespace Application.Features.Products.Constants;

public sealed class ProductValidationExceptionMessages
{
    public const string ProductNameCannotBeEmpty = "Ürün Adı Boş Olamaz.";
    public const string ProductNameMinimumLength = "Ürün Adı Minimum 2 Karakter Olmalıdır.";
    public const string ProductNameMaximumLength = "Ürün Adı Maksimum 250 Karakter Olmalıdır.";
}
