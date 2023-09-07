namespace Api.Application.Common;

public class PagedList<T>
{
    public List<T> Content { get; set; } = new();
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int FullLength { get; set; }

    public PagedList(List<T> content, int pageNumber, int pageSize, int fullLength)
    {
        Content = content;
        PageNumber = pageNumber;
        PageSize = pageSize;
        FullLength = fullLength;
    }
}
