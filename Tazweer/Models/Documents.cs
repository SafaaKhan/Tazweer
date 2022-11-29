using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models
{
    public class Documents
    {
        [Key]
        [Display(Name = "الوثائق")]
        public int DocumentsId { get; set; }

        [Display(Name = "اسم الملف")]
        public string? Filename { get; set; }

        [Display(Name = "نوع الملف ")]
        public string? Filetype { get; set; }
        [Display(Name = "محتوى الملف")]
        public int Filecon { get; set; }

        [Display(Name = "حجم الملف")]
        public string? Filesize { get; set; }

        [Display(Name = "معلومات الجواز")]

        public int passportId { get; set; }
        [Display(Name = "معلومات الجواز")]
        [ForeignKey("passportId")]
        public LostPassportInformation? passportinformations { get; set; }


        [Display(Name = "نوع الملف")]

        public int DocumentsTypeId { get; set; }
        [Display(Name = "نوع الملف")]
        [ForeignKey("DocumentsTypeId")]
        public DocumentsType? DocumentsType { get; set; }

    }
}
