using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class ServiceCurrencyRate
{
    public string Name { get; set; }
    public decimal? FaceValue { get; set; }
    public decimal? Rate { get; set; }
    public int? IsoCode { get; set; }
    public string StringCode { get; set; }
}