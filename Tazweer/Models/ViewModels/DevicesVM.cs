using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models.ViewModels
{
    public class DevicesVM
    {

        [Display(Name = "الرقم التسلسلي للجهاز")]
        public int DevicesId { get; set; }

        [Display(Name = "الاجهزة")]
        [Required(ErrorMessage ="الرجاء .." )]
        public string? NameDevice { get; set; }


        [Display(Name = "اضافة ملاحظة")]
        [Required]
        public string? AddNote { get; set; }

        [Display(Name = "اسم الموظف")]
        public int EmployeeId { get; set; }
        [Display(Name = "اسم الموظف")]

        public EmployeeVM? Employee { get; set; }
    }
}
