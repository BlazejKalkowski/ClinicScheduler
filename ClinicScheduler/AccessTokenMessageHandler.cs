using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using ClinicScheduler.Dto;
using ClinicScheduler.Middleware;
using ClinicScheduler.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.JSInterop;

namespace ClinicScheduler;

public class AccessTokenMessageHandler : DelegatingHandler
{
    private CustomAuthenticateStateProvider _authenticateStateProvider;
    private readonly NavigationManager _navigation;
    private readonly IJSRuntime _jsRuntime;
    private readonly HttpClient _httpClient = new();

    public AccessTokenMessageHandler(CustomAuthenticateStateProvider authenticateStateProvider
        , NavigationManager navigation
        , IJSRuntime jsRuntime)
    {
        _authenticateStateProvider = authenticateStateProvider;
        _navigation = navigation;
        _jsRuntime = jsRuntime;
    }

    protected  async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var token = await GetAccessToken();
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await base.SendAsync(request, cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                var renewd = await RefreshToken();
                if (renewd)
                {
                    return await SendAsync(request, cancellationToken);
                }

                _authenticateStateProvider.LogOutAsync();
            }

            _navigation.NavigateTo("/login");
        }

        return response;
    }

    private async Task<bool> RefreshToken()
    {
        var token = await GetRefreshToken();
        if (token is null)
        {
            return false;
        }

        var reqest = new HttpRequestMessage(HttpMethod.Post, new Uri("/refresh", UriKind.Relative));
        reqest.Content =
            new StringContent(JsonSerializer.Serialize(new RefreshTokenRequest(token))
                ,Encoding.UTF8, "application/json");
        var response = await _httpClient.SendAsync(reqest);

        if (response.IsSuccessStatusCode)
        {
            var tokenResponse = await response.Content.ReadAsStringAsync();
            var newToken = JsonSerializer.Deserialize<AccessTokenDto>(tokenResponse);
            await _jsRuntime.InvokeAsync<string?>("localStorage.setItem", tokenResponse);
            return true;
        }

        return false;
    }

    private async Task<string?> GetRefreshToken()
    {
        var value = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "token");
        if (value == null)
        {
            return null;
        }

        var token = JsonSerializer.Deserialize<AccessTokenDto>(value);
        return token?.RefreshToken;
    }

    private async Task<string?> GetAccessToken()
    {
        var value = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "token");
        if (value == null)
        {
            return null;
        }

        var token = JsonSerializer.Deserialize<AccessTokenDto>(value);
        return token?.AccessToken;
    }
}