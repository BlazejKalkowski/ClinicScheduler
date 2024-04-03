using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using ClinicScheduler.Dto;
using ClinicScheduler.Middleware;
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
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
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

            
        }
    }

    private async Task<bool> RefreshToken()
    {
        throw new NotImplementedException();
    }

    private async Task<object> GetAccessToken()
    {
        var value = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "access_token");
        if (value == null)
        {
            return null;
        }

        var token = JsonSerializer.Deserialize<AccessTokenDto>(value);
        return token?.AccessToken;
    }
}