namespace Lab08_WKana.Application.Dtos.Client;

public class ClientGetDto
{
    public int Clientid { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}