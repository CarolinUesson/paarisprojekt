namespace Domain.Common;
public interface ICrudRepo<TEntity> where TEntity : class, new()
{
    IEnumerable<TEntity> Get();
    TEntity? Get(int? id);
    Task<TEntity?> GetAsync(int? id);
    bool Update(TEntity obj);
    bool Add(TEntity obj);
    bool Delete(int id);
}
