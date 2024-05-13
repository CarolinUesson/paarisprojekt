namespace Domain.Common;
public interface IPagedRepo<TEntity> : 
    IOrderedRepo<TEntity> where TEntity : class, new()
{
    int PageIdx { get; set; }
    int PageSize { get; set; }
    int TotalPages { get; }
    int TotalItems { get; }
    bool HasNextPage { get; }
    bool HasPreviousPage { get; }
}
