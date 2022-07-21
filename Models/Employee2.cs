using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRUDusingADO.Models
{
        [Table("Employee2")]
        public class Employee2 //POCO class (plain old C# CLR object)
        {
            [Key]
            [ScaffoldColumn(false)]
            public int EmpId { get; set; }

            [Required(ErrorMessage = "Employee name is required")]
            [DataType(DataType.Text)]
            [Display(Name = "Employee Name")]
            public string EmpName { get; set; }

            [Required(ErrorMessage = "Employee salary is required")]
            [DataType(DataType.Text)]
            [Display(Name = "Employee Salary")]
            public int EmpSalary { get; set; }
    }
    
}
