using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CbRates;
using CbRates.DAL;
using CbRates.Helpers;
using CbRates.RatesService;


namespace CentralBankRates.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceClient _serviceClient = new ServiceClient();
        private ICurrencyRateRepository _currencyRateRepository;
        public HomeController()
        {
            _currencyRateRepository = new CurrencyRateRepository(new CbRatesDatabaseEntities());
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Описание сайта";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контактная информация";
            return View();
        }

        public JsonResult GetCurrencyRate()
        {
            var rates = _currencyRateRepository.GetLastCurrencyRate();
            return new JsonResult { Data = rates, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult LoadCurrencyRates()
        {
            var rates = _serviceClient.GetCurrencyRates();
             _currencyRateRepository.LoadRates(RatesMapper.MapBunchOfServiceRatesToDbRates(rates.ToList()));
             return new JsonResult { Data = rates, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}