using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CbRates.DAL
{
    public class CurrencyRateRepository : ICurrencyRateRepository
    {
        private readonly CbRatesDatabaseEntities _context;
        private bool _disposed = false;

        public CurrencyRateRepository(CbRatesDatabaseEntities context)
        {
            _context = context;
        }

        public List<CurrencyRates> GetCurrencyRates()
        {
            return _context.CurrencyRates.Select(x => x).Distinct().ToList();
        }

        public CurrencyRates GetCurrencyRateByCurrencyCode(string currencyCode)
        {
            return _context.CurrencyRates.FirstOrDefault(x => x.CR_StringCode == currencyCode);
        }

        public CurrencyRates GetCurrencyRateByCurrencyIsoCode(int isoCode)
        {
            return _context.CurrencyRates.FirstOrDefault(x => x.CR_CurrencyIso == isoCode);
        }

        public List<CurrencyRates> GetLastCurrencyRate()
        {
            var  result = _context.GetLatestRates().ToList();
            return Helpers.RatesMapper.MapBunchStoretProcedureRatesToDbRates(result);
        }

        public void LoadRates(List<CurrencyRates> rates)
        {
            foreach (var rate in rates)
            {
                  rate.CR_UpdateDate = DateTime.Now;
                  _context.CurrencyRates.Add(rate);
            }
             _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}