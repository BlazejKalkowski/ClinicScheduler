using System.Security.Claims;
using System.Text.Json;
using ClinicScheduler.Dto;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;

namespace ClinicScheduler.Middleware;

public class CustomAuthenticateStateProvider : AuthenticationStateProvider
{
    private readonly IJSRuntime _jsRuntime;
    
    public CustomAuthenticateStateProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
            var userValue = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "user");
            var claims = new ClaimsIdentity();

            if (userValue is not null)
            {
                var user = JsonSerializer.Deserialize<UserDto>(userValue);
                var claimList = user.Claims.Select(x => new Claim(x.Key, x.Value)).ToList();
                claims = new ClaimsIdentity(claimList, "auth");
            }

            var principal = new ClaimsPrincipal(claims);
            return new AuthenticationState(principal);
    }

    public async Task AuthenticateAsync(UserDto? user)
    {
        var json = JsonSerializer.Serialize(user);
        await _jsRuntime.InvokeAsync<UserDto?>("localStorage.setItem", "user",json);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
    

    public async Task LogOutAsync()
    {
        await _jsRuntime.InvokeAsync<UserDto?>("localStorage.removeItem","user");
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}