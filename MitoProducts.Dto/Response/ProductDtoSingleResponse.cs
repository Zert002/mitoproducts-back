namespace MitoProducts.Dto.Response
{
    public class ProductDtoSingleResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal ProductPrice { get; set; }
        public bool ProductEnabled { get; set; }
    }
}
