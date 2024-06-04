namespace Domain.Common;
public interface IRepo<TEntity> :
    IPagedRepo<TEntity> where TEntity : class
{
    Task<IEnumerable<dynamic>> SelectItems(string researchString, int id);
}
