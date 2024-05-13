using Data.Pd;
using Domain;
using Domain.Repos;
using Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra;
public class ProductsRepo(DbContext c, DbSet<ProductData> s) : Repo<ProductData>(c, s), IProductsRepo
{
}
