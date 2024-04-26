using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;
public abstract class Entity<TData>(TData? d) where TData : EntityData, new()
{
    internal readonly TData data = d ?? new TData();
    public int Id => data.Id;
}
