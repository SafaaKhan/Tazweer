using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models.ViewModels
{
    public class DocumentsTypeVM
    {
        [Display(Name = "رقم النوع")]
        public int DocumentsTypeId { get; set; }

        [Required]
        [Display(Name = "اسم النوع")]
        public string? TypeName { get; set; }
    }
}
