namespace CompanySample.Models
{
    public class CustomerProduct
    {
        public int CustomerId { get; set; }   
        public int ProductId { get; set; }
        public int TerminalNumber { get; set; }
        public DateTime SoldAt { get; set; }
        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}
