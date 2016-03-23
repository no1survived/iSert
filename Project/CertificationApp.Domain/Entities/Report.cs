using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CertificationApp.Domain.Entities
{
    public class Report
    {
        [HiddenInput(DisplayValue = false)]
        public int ReportId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название")]
        public string ManagerName { get; set; }
        public string ClientName { get; set; }
        public string ServiceName { get; set; }

        [DataType(DataType.MultilineText)]
        public string ProductHeading { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public int Price { get; set; }
        public int CostPrice { get; set; }
        public int Profit { get; set; }
        public string CentrName { get; set; }
        public string DocumentReciever { get; set; }
        public DateTime ReportDate { get; set; }

    }
}
