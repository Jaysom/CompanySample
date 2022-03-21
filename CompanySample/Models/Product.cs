using System.ComponentModel.DataAnnotations;

namespace CompanySample.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(50)]
        public string ProductTypeName { get; set; }
        public virtual IList<Customer> ProductCustomers { get; set; }
    }
}
