using Data;

namespace Domain;
public abstract class Entity<TData>(TData? d) where TData : EntityData, new()
{
    internal readonly TData data = d ?? new TData();
    public int Id => data.Id;
}
