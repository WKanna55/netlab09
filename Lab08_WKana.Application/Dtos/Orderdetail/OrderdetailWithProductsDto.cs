using Lab08_WKana.Application.Dtos.Product;

namespace Lab08_WKana.Application.Dtos.Orderdetail;

public class OrderdetailWithProductsDto
{
    public int Orderdetailid { get; set; }

    public int Orderid { get; set; }

    public int Productid { get; set; }

    public int Quantity { get; set; }

    public virtual ProductGetDto Product { get; set; } = null!;
}