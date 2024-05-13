namespace Domain.Common;
public interface IOrderedRepo<TEntity> : 
    IFilteredRepo<TEntity> where TEntity : class, new() 
{
    string SortOrder { get; set; }
}
