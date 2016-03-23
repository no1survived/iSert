using System.Collections.Generic;
using CertificationApp.Domain.Abstract;
using CertificationApp.Domain.Entities;

namespace CertificationApp.Domain.Concrete
{
    public class EFReportRepository : IReportRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Report> Reports
        {
            get { return context.Reports; }
        }

        public void SaveReport(Report report)
        {
            if (report.ReportId == 0)
                context.Reports.Add(report);
            else
            {
                var dbEntry = context.Reports.Find(report.ReportId);
                if (dbEntry != null)
                {
                    dbEntry.ClientName = report.ClientName;
                    dbEntry.ManagerName = report.ManagerName;
                    dbEntry.CentrName = report.CentrName;
                    dbEntry.DocumentReciever = report.DocumentReciever;
                    dbEntry.ProductHeading = report.ProductHeading;
                    dbEntry.Profit = dbEntry.Profit;
                    dbEntry.ServiceName = report.ServiceName;
                    dbEntry.Price = report.Price;
                    dbEntry.CostPrice = report.CostPrice;
                    dbEntry.ReportDate = report.ReportDate;
                }
            }
            context.SaveChanges();
        }

        public Report DeleteReport(int reportId)
        {
            var dbEntry = context.Reports.Find(reportId);
            if (dbEntry != null)
            {
                context.Reports.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
