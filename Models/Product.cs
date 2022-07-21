using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace CRUDusingADO.Models
{
    //POCO class (plain old C# CLR object)
    //BO  - bussiness object / model class
    [Table("Product")]
    public class Product //POCO class (plain old C# CLR object)
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string Pname { get; set; }


        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Product Price")]
        [Range(minimum:1 ,  maximum:50000)]
        public int  Price { get; set; }
    }
}
