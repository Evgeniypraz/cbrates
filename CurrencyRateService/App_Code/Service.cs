using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CBRateService;
using Extensions;

public class Service : IService
{
    public ServiceCurrencyRate[] GetCurrencyRatesByDate(DateTime date)
    {
        using (var soapClient = new DailyInfoSoapClient())
        {
            var dailyRate = soapClient.GetCursOnDate(date.Date);
            return dailyRate.ToArrayOfRates();
        }
    }

    public ServiceCurrencyRate[] GetCurrencyRates()
    {
        using (var soapClient = new DailyInfoSoapClient())
        {
            var dailyRate = soapClient.GetCursOnDate(DateTime.Today);
            return dailyRate.ToArrayOfRates();
        }
    }

}
