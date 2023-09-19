using Application.Common.Pagination;

namespace Application.Common.Responses;

public sealed class GetListResponse<T> :BasePageableModel
{
    private IList<T> _items;

    public IList<T> Items
    {
        get => _items ??= new List<T>();
        set => _items = value;
    }
}
