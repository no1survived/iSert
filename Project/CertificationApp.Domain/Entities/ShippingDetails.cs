using System.ComponentModel.DataAnnotations;

namespace CertificationApp.Domain.Entities
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Вкажіть ПІБ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Адрес")]
        [Display(Name = "Перший адрес")]
        public string Line1 { get; set; }
        [Display(Name = "Другий адрес")]
        public string Line2 { get; set; }
        [Display(Name = "Третій адрес")]
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Місто")]
        [Display(Name = "Місто")]
        public string City { get; set; }

        [Required(ErrorMessage = "Країна")]
        [Display(Name = "Країна")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
    }
}
