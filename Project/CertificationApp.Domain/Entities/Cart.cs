using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertificationApp.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Report report, int quantity)
        {
            var line = lineCollection.FirstOrDefault(g => g.Report.ReportId == report.ReportId);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Report = report,
                    Quantity = quantity
                });
            }
        }

        public void RemoveLine(Report report)
        {
            lineCollection.RemoveAll(l => l.Report.ReportId == report.ReportId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Report.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public Report Report { get; set; }
        public int Quantity { get; set; }
    }
}
