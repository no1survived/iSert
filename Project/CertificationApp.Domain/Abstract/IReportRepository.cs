using System.Collections.Generic;
using CertificationApp.Domain.Entities;

namespace CertificationApp.Domain.Abstract
{
    public interface IReportRepository
    {
        IEnumerable<Report> Reports { get; }
        void SaveReport(Report report);
        Report DeleteReport(int reportId);
    }
}
