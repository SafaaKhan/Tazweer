using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models.ViewModels
{
    public class DepartmentVM
    {
        [Display(Name = "رقم الادارة")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "اسم الادارة")]
        public string? DepartmentName { get; set; }
    }
}
