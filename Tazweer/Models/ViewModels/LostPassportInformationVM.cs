using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models.ViewModels
{
    public class LostPassportInformationVM
    {

        [Display(Name = "رقم الجواز")]
        public int passportId { get; set; }


        [Required]
        [Display(Name = "اسم صاحب الجواز")]
        public string? PassportOwnerName { get; set; }

        [Required]
        [Display(Name = "نوع الجواز")]
        public string? PassportType { get; set; }

        [Required]
        [Display(Name = "رقم الادارة")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "الجنسية")]
        public string? Nationality { get; set; }

        [Required]
        [Display(Name = "تاريخ الفقدان")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime Dateofloss { get; set; }

        [Required]
        [Display(Name = "الأمر المستند عليه")]
        public string? Thecommandbasedonit { get; set; }

        [Required]
        [Display(Name = "إضافة ملاحظة على البلاغ")]
        public string? Thenote { get; set; }

        [Required]
        [Display(Name = "سبب حذف البلاغ")]
        public string? Thereasonofdelete { get; set; }
    }
}
