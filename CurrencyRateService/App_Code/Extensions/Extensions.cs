using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Extensions
{
    public static class Extensions
    {
        public static ServiceCurrencyRate[] ToArrayOfRates(this DataSet ds)
        {
            return ds.Tables[0].AsEnumerable()
                .Select(dataRow => new ServiceCurrencyRate
                {
                    Name = dataRow.Field<string>("Vname").TrimEnd(),
                    FaceValue = dataRow.Field<decimal>("Vnom"),
                    Rate = dataRow.Field<decimal>("Vcurs"),
                    IsoCode = dataRow.Field<int>("Vcode"),
                    StringCode = dataRow.Field<string>("VchCode"),
                }).ToArray();
        }
    }

}
