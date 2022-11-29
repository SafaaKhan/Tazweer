using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models
{
    public class DocumentsType
    {
        [Key]
        [Display(Name = "رقم النوع")]
        public int DocumentsTypeId { get; set; }

        [Display(Name = "اسم النوع")]
        public string? TypeName { get; set; }

    }
}
