using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models.ViewModels
{
    public class EmployeeVM
    {
        [Display(Name = "رقم الموظف")]
        public int EmployeeId { get; set; }

        [Required]
        [Display(Name = "إيميل ")]

        public string? Email { get; set; }

        [Required]
        [Display(Name = " اسم الموظف")]

        public string? Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "رقم الهوية")]

        public string? Idnationality { get; set; }

        [Required]
        [Display(Name = "الرتبة ")]
        public string? Rank { get; set; }

        [Display(Name = "اسم الادارة")]

        public int DepartmentId { get; set; }
        [Display(Name = "اسم الادارة")]

        public Department? Department { get; set; }
    }
}
