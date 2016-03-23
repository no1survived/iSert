using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CertificationApp.Domain.Abstract;

namespace CertificationApp.WebApp.Controllers
{
    public class NavController : Controller
    {
        private IReportRepository repository;

        public NavController(IReportRepository reportRepository)
        {
            repository = reportRepository;
        }
        public PartialViewResult Menu(string manager = null, bool horizontalNav = false)
        {
            ViewBag.SelectedManager = manager;
            var managers = repository.Reports.Select(s => s.ManagerName).Distinct().OrderBy(o => o);
            return PartialView("FlexMenu", managers);
        }
    }
}