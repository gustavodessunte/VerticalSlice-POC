namespace VerticalSlice.Domain
{
    public class Product(string name, decimal price)
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = name;
        public decimal Price { get; set; } = price;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public void Update(string name, decimal price)
        {
            Name = name;
            Price = price;
            UpdatedAt = DateTime.Now;
        }

        public void Delete()
        {
            DeletedAt = DateTime.Now;
        }
    }
}
