namespace Application.Common.Pagination;

public sealed class Paginate<T>
{
    public Paginate()
    {
        Items = Array.Empty<T>();
    }

    public int Index { get; set; }

    public int Size { get; set; }

    public long Count { get; set; }

    public int Pages { get; set; }

    public IList<T> Items { get; set; }

    public bool HasPrevious => Index > 0;

    public bool HasNext => Index + 1 < Pages;
}
