using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models
{
    public class LostPassportInformation
    {
        [Key]
        [Display(Name = "رقم الجواز")]
        public int passportId { get; set; }


        [Display(Name = "اسم صاحب الجواز")]
        public string? PassportOwnerName { get; set; }

        [Display(Name = "نوع الجواز")]
        public string? PassportType { get; set; }

        [Display(Name = "رقم الادارة")]
        public int DepartmentId { get; set; }

        [Display(Name = "الجنسية")]
        public string? Nationality { get; set; }

        [Display(Name = "تاريخ الفقدان")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMMM-yyyy}")]
        public DateTime Dateofloss { get; set; }

        [Display(Name = "الأمر المستند عليه")]
        public string? Thecommandbasedonit { get; set; }


        [Display(Name = "إضافة ملاحظة على البلاغ")]
        public string? Thenote { get; set; }

        [Display(Name = "سبب حذف البلاغ")]
        public string? Thereasonofdelete { get; set; }

    }
}
