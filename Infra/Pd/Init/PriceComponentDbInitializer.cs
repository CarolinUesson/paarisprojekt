using Aids.Methods;
using Data.Pd;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Runtime.InteropServices;

namespace Infra.Pd.Init;
public sealed class PriceComponentDbInitializer(DbContext c, DbSet<PriceComponentData> s): DbInitializer<PriceComponentData>(c, s) {

    protected override void setValues(int idx) {

        if (item == null) return;
        item.FromDate = GetRnd.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
        item.FromDate = GetRnd.DateTime(DateTime.Now.AddYears(-20), DateTime.Now.AddYears(-5));
        item.Price = GenerateRndPrice();
        item.Type = GenerateRndType();
    }


    private decimal GenerateRndPrice() {

        double minValue = 0.0;
        double maxValue = 100.0;

        double randomDouble = GetRnd.Double(minValue, maxValue);

        return Convert.ToDecimal(randomDouble);
    }

    private string GenerateRndType() {
        string[] types = { "One time charge", "Recurring charge", "Utilization charge" };


        double randomIndex = GetRnd.Double(0, types.Length);


        int index = (int)Math.Floor(randomIndex);

        return types[index];
    }
}