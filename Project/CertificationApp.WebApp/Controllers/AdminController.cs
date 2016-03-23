using System.Linq;
using System.Web.Mvc;
using CertificationApp.Domain.Abstract;
using CertificationApp.Domain.Entities;

namespace CertificationApp.WebApp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IReportRepository _repository;

        public AdminController(IReportRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index()
        {
            return View(_repository.Reports);
        }

        public ViewResult Create()
        {
            return View("Edit", new Report());
        }

        public ViewResult Edit(int reportId)
        {
            var report = _repository.Reports.FirstOrDefault(g => g.ReportId == reportId);
            return View(report);
        }

        [HttpPost]
        public ActionResult Edit(Report report)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveReport(report);
                TempData["message"] = string.Format("Изменения в отчете \"{0}\" были сохранены", report.ManagerName);
                return RedirectToAction("Index");
            }
            else
            {
                // Что-то не так со значениями данных
                return View(report);
            }
        }

        [HttpPost]
        public ActionResult Delete(int reportId)
        {
            var deletedReport = _repository.DeleteReport(reportId);
            if (deletedReport != null)
            {
                TempData["message"] = string.Format("\"{0}\" была удалена",
                    deletedReport.ManagerName);
            }
            return RedirectToAction("Index");
        }
    }
}