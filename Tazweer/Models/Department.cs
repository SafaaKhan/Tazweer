using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models
{
    public class Department
    {
        [Display(Name = "رقم الادارة")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "اسم الادارة")]
        public string? DepartmentName { get; set; }

    }
}
