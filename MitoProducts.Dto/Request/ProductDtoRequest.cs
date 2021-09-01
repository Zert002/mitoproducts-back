namespace MitoProducts.Dto.Request
{
    public class ProductDtoRequest
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductEnabled { get; set; }
    }
}
