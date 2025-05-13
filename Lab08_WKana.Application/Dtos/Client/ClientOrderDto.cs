using Lab08_WKana.Application.Dtos.Order;

namespace Lab08_WKana.Application.Dtos.Client;

public class ClientOrderDto
{
    public string ClientName { get; set; }
    public List<OrderDto> Orders { get; set; }
}