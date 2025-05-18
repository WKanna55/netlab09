using Lab08_WKana.Application.Dtos.Product;

namespace Lab08_WKana.Application.Dtos.Orderdetail;

public class OrderDetailsDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public List<ProductDto> Products { get; set; }
}