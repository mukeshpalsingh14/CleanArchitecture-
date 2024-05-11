namespace Order.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean IsActive { get; set; }
    }
}