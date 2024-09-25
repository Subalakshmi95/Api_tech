using System.ComponentModel.DataAnnotations;

namespace Api_tech.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="Name should contain only 10characters")]
        public string ProductName { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double Price { get; set; }
        [Required]
        public int Quantity {  get; set; }


    }
}
