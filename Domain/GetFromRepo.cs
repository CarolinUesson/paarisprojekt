using Domain.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class GetFromRepo
{
    private static IServiceCollection? services;
    public static void SetServices(IServiceCollection s) => services = s;
    private static TRepo? repo<TRepo, TEntity>() where TRepo : IRepo<TEntity>
        where TEntity : class
    {
        var p = services?.BuildServiceProvider();
        return p is null ? default : p.GetRequiredService<TRepo>();
    }
    public static async Task<TEntity?> Item<TRepo, TEntity>(int id)
        where TRepo : IRepo<TEntity>
        where TEntity : class
    {
        var repo = repo<TRepo, TEntity>();
        return repo is null ? null : await repo.GetAsync(id);
    }
}