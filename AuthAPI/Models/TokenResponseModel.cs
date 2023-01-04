using System.Text.Json.Serialization;

namespace AuthAPI.Models;

public class TokenResponseModel
{
    [JsonPropertyName("token")]
    public string Token { get; set; } = null!;

    [JsonPropertyName("expiresIn")]
    public int ExpiresIn { get; set; }

    [JsonPropertyName("creationDate")]
    public DateTime CreationDate { get; set; } = DateTime.Now; //mudar
}
