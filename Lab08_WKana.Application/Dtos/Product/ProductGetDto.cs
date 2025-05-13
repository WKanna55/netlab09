namespace Lab08_WKana.Application.Dtos.Product;

public class ProductGetDto
{
    public int Productid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }
}