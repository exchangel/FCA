using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FCA.WebUI.Areas.Admin.Models
{
    public class CustomerFormViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Müşteri adını girmek zorunludur.")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        public string? LastName { get; set; }
        [Display(Name = "Eposta")]
        public string? Email { get; set; }
        [Display(Name = "Telefon (0 kullanmadan yazınız.")]
        [Required(ErrorMessage = "Müşteri numarasını girmek zorunludur.")]
        public string? Phone { get; set; }
        [Display(Name = "Şehir")]
        public string? City { get; set; }
        [Display(Name = "İlgi")]
        public string? Interest { get; set; }
        [Display(Name = "Nereden Buldu")]
        public string? FindHow { get; set; }
        [Display(Name = "Notlar")]
        public string? Note { get; set; }
    }
}
