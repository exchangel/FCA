using System.ComponentModel.DataAnnotations;

namespace FCA.WebUI.Areas.Admin.Models
{
    public class SessionFormViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bir koç seçmek zorunludur.")]
        [Display(Name ="Koç")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Bir müşteri seçmek zorunludur.")]
        [Display(Name = "Müşteri")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Bir ad seçmek zorunludur.")]
        [Display(Name = "Seans Adı")]
        public string SessionName { get; set; }
        [Required(ErrorMessage = "Bir tarih seçmek zorunludur.")]
        [Display(Name = "Seans Tarihi")]
        public DateTime SessionDate { get; set; }
        [Required(ErrorMessage = "Bir not seçmek zorunludur.")]
        [Display(Name = "Notlar")]
        public string Note { get; set; }
        [Required(ErrorMessage = "Bir fiyat seçmek zorunludur.")]
        [Display(Name = "Fiyat")]
        public double Price { get; set; }
    }
}
