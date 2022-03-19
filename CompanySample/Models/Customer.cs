using CompanySample.Enums;
using System.ComponentModel.DataAnnotations;

namespace CompanySample.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public DocType DocType { get; set; }
        [StringLength(10)]
        public string DocNum { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(50)]
        public string GivenName { get; set; }
        [StringLength(50)]
        public string FamilyName { get; set; }
        public int Phone { get; set; }
        public virtual IList<Product> CustomerProducts { get; set; }
    }
}