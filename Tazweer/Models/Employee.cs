﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Tazweer.Models
{
    public class Employee
    {
        [Key]
        [Display(Name = "رقم الموظف")]
        public int EmployeeId { get; set; }

        [Display(Name = "إيميل ")]

        public string? Email { get; set; }

        [Display(Name = " اسم الموظف")]

        public string? Name { get; set; } = string.Empty;

        [Display(Name = "رقم الهوية")]

        public string? Idnationality { get; set; }

        [Display(Name = "الرتبة ")]
        public string? Rank { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        
        public Department? Department { get; set; }

    }
}
