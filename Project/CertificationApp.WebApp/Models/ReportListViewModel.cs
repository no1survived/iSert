using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CertificationApp.Domain.Entities;

namespace CertificationApp.WebApp.Models
{
    public class ReportListViewModel
    {
        public IEnumerable<Report> Reports { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentManager { get; set; }
    }
}