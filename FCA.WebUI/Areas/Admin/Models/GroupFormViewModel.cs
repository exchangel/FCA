using FCA.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FCA.WebUI.Areas.Admin.Models
{
    public class GroupFormViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Koç")]
        [Required(ErrorMessage = "Doldurmak zorunludur.")]
        public int UserId { get; set; }
        [Display(Name = "Grup Adı")]
        [Required(ErrorMessage = "Doldurmak zorunludur.")]
        public string Name { get; set; }
        [Display(Name = "Başlama tarihi")]
        [Required(ErrorMessage = "Doldurmak zorunludur.")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        [Required(ErrorMessage = "Doldurmak zorunludur.")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Doldurmak zorunludur.")]
        public double Price { get; set; }
        [Display(Name = "Müşteri sayısı")]
        [Required(ErrorMessage = "Doldurmak zorunludur.")]
        public int CustomerCount { get; set; }
        [Display(Name = "Notlar")]
        [Required(ErrorMessage = "Doldurmak zorunludur.")]
        public string Note { get; set; }
       
    }
}
