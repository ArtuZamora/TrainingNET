using BussinessLogic.Interfaces;
using BussinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrainingProject.Controllers
{
    public class ConsultLogController : Controller
    {
        private IConsultLogRepository _consultLogRepository;
        public ConsultLogController()
        {
            if (_consultLogRepository == null)
            {
                _consultLogRepository = new ConsultLogRepository();
            }
        }
        public ActionResult Index()
        {
            return View(_consultLogRepository.GetConsultlog());
        }
    }
}