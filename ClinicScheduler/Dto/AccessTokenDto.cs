using System.Text.Json.Serialization;

namespace ClinicScheduler.Dto;

public class AccessTokenDto
{
    [JsonPropertyName("accessToken")]
    public required string AccessToken { get; init; }
    [JsonPropertyName("expiresIn")]
    public required long ExpiresInSeconds { get; init; }
    [JsonPropertyName("refreshToken")]
    public required string RefreshToken { get; init; }
    [JsonPropertyName("tokenType")]
    public string TokenType { get; init; }
}