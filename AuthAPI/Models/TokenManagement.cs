namespace AuthAPI.Models;

public class TokenManagement
{
    public string Secret { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int AccessExpiration { get; set; } 


}
