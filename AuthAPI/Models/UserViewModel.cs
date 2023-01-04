using System.Text.Json.Serialization;

namespace AuthAPI.Models;

public class UserViewModel
{
    [JsonPropertyName("userName")]
    public string UserName { get; set; } = null!;

    [JsonPropertyName("password")]
    public string Password { get; set; } = null!;
}
