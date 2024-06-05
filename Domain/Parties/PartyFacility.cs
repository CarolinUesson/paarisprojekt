using Data.Parties;
using Domain.Common;
using Domain.Repos.Parties;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Parties;
public sealed class PartyFacility(PartyFacilityData? d) : Entity<PartyFacilityData>(d) 
{
    public async Task LazyLoad()
    {
        if (Party != null) return;
        Party = await GetFromRepo.Item<IPartyRepo, Party>(PartyId);
    }
    public int PartyId => data.PartyId;
    public Party? Party {  get; private set; }
    public int FacilityId => data.FacilityId;
    public Facility? Facility { get; private set; }
}

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