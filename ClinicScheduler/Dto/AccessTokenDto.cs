using System.Text.Json.Serialization;

namespace ClinicScheduler.Dto;

public class AccessTokenDto
{
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; init; }
    [JsonPropertyName("expires_in")]
    public required long ExpiresInSeconds { get; init; }
    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; init; }
}