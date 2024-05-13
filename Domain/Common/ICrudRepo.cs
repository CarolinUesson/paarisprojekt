namespace Domain.Common;
public interface ICrudRepo<TEntity> where TEntity : class, new()
{
    Task<IEnumerable<TEntity>> GetAsync();
    Task<TEntity?> GetAsync(int? id);
    Task<bool> UpdateAsync(TEntity obj);
    Task<bool> AddAsync(TEntity obj);
    Task<bool> DeleteAsync(int id);
}
