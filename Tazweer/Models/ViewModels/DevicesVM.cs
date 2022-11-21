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
        public string? NameDevice { get; set; }


        [Display(Name = "اضافة ملاحظة")]
        public string? AddNote { get; set; }

        public int EmployeeId { get; set; }

        public Employee? Employee { get; set; }
    }
}
