using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CbRates.RatesService;

namespace CbRates.Helpers
{
    public static class RatesMapper
    {
        public static ServiceCurrencyRate MapDbRateToServiceRate(CurrencyRates dbRate)
        {
            var rate = new ServiceCurrencyRate();
            rate.Rate = dbRate.CR_Rate;
            rate.FaceValue = dbRate.CR_FaceVAlue;
            rate.IsoCode = dbRate.CR_CurrencyIso;
            rate.StringCode = dbRate.CR_StringCode;
            rate.Name = dbRate.CR_CurrencyName;
            return rate;
        }

        public static List<ServiceCurrencyRate> MapBunchOfDbRatesToServiceRates(List<CurrencyRates> dbRates)
        {
            var rates = new List<ServiceCurrencyRate>();
            foreach (var dbRate in dbRates)
            {
                rates.Add(MapDbRateToServiceRate(dbRate));
            }
            return rates;
        }

        public static CurrencyRates MapServiceRateToDbRate(ServiceCurrencyRate rate)
        {
            var dbRate = new CurrencyRates();
            dbRate.CR_Rate = rate.Rate;
            dbRate.CR_FaceVAlue = rate.FaceValue;
            dbRate.CR_CurrencyIso = rate.IsoCode;
            dbRate.CR_StringCode = rate.StringCode;
            dbRate.CR_CurrencyName = rate.Name;
            return dbRate;
        }

        public static List<CurrencyRates> MapBunchOfServiceRatesToDbRates(List<ServiceCurrencyRate> rates)
        {
            var dbRates = new List<CurrencyRates>();
            foreach (var rate in rates)
            {
                dbRates.Add(MapServiceRateToDbRate(rate));
            }
            return dbRates;
        }

        public static CurrencyRates MapStoretProcedureRatesToDbRates(GetLatestRates_Result dbRate)
        {
            var rate = new CurrencyRates();
            rate.CR_Rate = dbRate.CR_Rate;
            rate.CR_FaceVAlue = dbRate.CR_FaceVAlue;
            rate.CR_CurrencyIso = dbRate.CR_CurrencyIso;
            rate.CR_StringCode = dbRate.CR_StringCode;
            rate.CR_CurrencyName = dbRate.CR_CurrencyName;
            rate.CR_id = dbRate.CR_id;
            rate.CR_UpdateDate = dbRate.CR_UpdateDate;
            return rate;
        }

        public static List<CurrencyRates> MapBunchStoretProcedureRatesToDbRates(List<GetLatestRates_Result> dbRates)
        {
            var rates = new List<CurrencyRates>();
            foreach (var dbRate in dbRates)
            {
                rates.Add(MapStoretProcedureRatesToDbRates(dbRate));
            }
            return rates;
        }

    }
}