﻿using Data.Pd;
using Domain.Common;
using Domain.Pd;

namespace Domain.Repos;
public interface IProductsRepo : IPagedRepo<ProductData>
{
}