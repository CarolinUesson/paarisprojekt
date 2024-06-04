﻿using Data.Parties;
using Domain.Parties;
using Domain.Repos.Parties;
using Facade.Parties;
using Infra.Common;

namespace Infra.Parties;
public class FacilitiesRepo(PartyDbContext c) : Repo<Facility, FacilityData>(c, c.Facility), IFacilityRepo
{
    protected internal override string selectTextField => nameof(FacilityData.Location);
    protected override IQueryable<FacilityData> addFilter(IQueryable<FacilityData> sql) =>
        string.IsNullOrEmpty(SearchString)
        ? sql
        : sql.Where(s => s.Location != null && s.Location.Contains(SearchString));

    protected override Facility toEntity(FacilityData? d) => new(d);
}