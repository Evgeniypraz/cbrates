using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbRates.DAL
{
    public interface ICurrencyRateRepository : IDisposable
    {
        List<CurrencyRates> GetCurrencyRates();
        CurrencyRates GetCurrencyRateByCurrencyCode(string currencyCode);
        CurrencyRates GetCurrencyRateByCurrencyIsoCode(int isoCode);
        List<CurrencyRates> GetLastCurrencyRate();
        void LoadRates(List<CurrencyRates> rates);
    }
}
