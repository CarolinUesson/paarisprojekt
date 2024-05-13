namespace Domain.Common;
public interface IFilteredRepo<TEntity> : 
    ICrudRepo<TEntity> where TEntity : class, new() 
{
    string SearchString { get; set; }
}
