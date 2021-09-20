using BussinessLogic.Interfaces;
using BussinessLogic.Models;
using BussinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingProject.Models;

namespace TrainingProject.Controllers
{
    public class HomeController : Controller
    {
        private IQuotaRepository _quotaRepository;
        private IMonthRepository _monthsRepository;
        public HomeController()
        {
            if (_monthsRepository == null)
            {
                _monthsRepository = new MonthRepository();
            }
            if (_quotaRepository == null)
            {
                _quotaRepository = new QuotaRepository();
            }
        }
        public ActionResult Index()
        {
            return View(new RequestInfoModel { 
                Months = _monthsRepository.GetMonths()
            });
        }
        [HttpPost]
        public ActionResult Index(RequestInfoModel requestInfo)
        {
            requestInfo.UserRequest.ip = GetIPAddress();
            TempData["result"] = _quotaRepository.GetQuota(requestInfo.UserRequest);
            return RedirectToAction("Index");
        }
        protected string GetIPAddress()
        {
            HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}