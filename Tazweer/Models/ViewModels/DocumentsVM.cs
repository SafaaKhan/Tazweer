using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models.ViewModels
{
    public class DocumentsVM
    {
        [Display(Name = "الوثائق")]
        public int DocumentsId { get; set; }

        [Required]
        [Display(Name = "اسم الملف")]
        public string? Filename { get; set; }

        [Required]
        [Display(Name = "نوع الملف ")]
        public string? Filetype { get; set; }
        [Required]
        [Display(Name = "محتوى الملف")]
        public int Filecon { get; set; }

        [Required]
        [Display(Name = "حجم الملف")]
        public string? Filesize { get; set; }


        public int passportId { get; set; }
        public LostPassportInformation? passportinformations { get; set; }


        public int DocumentsTypeId { get; set; }
        public DocumentsType? DocumentsType { get; set; }
    }
}
