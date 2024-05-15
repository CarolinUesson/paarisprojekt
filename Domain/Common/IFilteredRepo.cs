﻿namespace Domain.Common;
public interface IFilteredRepo<TEntity> : 
    ICrudRepo<TEntity> where TEntity : class 
{
    string SearchString { get; set; }
}
