using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CertificationApp.Domain.Abstract;
using CertificationApp.WebApp.Models;

namespace CertificationApp.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private IReportRepository repository;
        private int pageSize = 4;
        public ReportController(IReportRepository reportRepository)
        {
            repository = reportRepository;
        }

        public ViewResult ReportList(string manager, int page = 1)
        {
            var model = new ReportListViewModel
            {
                Reports = repository.Reports.Where(w=>manager == null || w.ManagerName == manager).OrderBy(o => o.Price).Skip((page - 1)*pageSize).Take(pageSize),
                PagingInfo =
                    new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSize,
                        TotalItems = manager == null ? repository.Reports.Count() : repository.Reports.Count(w => w.ManagerName == manager)
                    },
                    CurrentManager = manager
            };
            
            return View(model);
        }
    }
}