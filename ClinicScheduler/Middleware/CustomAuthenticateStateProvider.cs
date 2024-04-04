using System.Security.Claims;
using System.Text.Json;
using ClinicScheduler.Dto;
using ClinicScheduler.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;

namespace ClinicScheduler.Middleware;

public class CustomAuthenticateStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
    
    private readonly IJSRuntime _jsRuntime;
    

    public CustomAuthenticateStateProvider(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        try
        {

            var userValue = await _jsRuntime.InvokeAsync<string?>("localStorage.getItem", "token");
            var claims = new ClaimsIdentity();

            if (userValue is not null)
            {
                var user = JsonSerializer.Deserialize<UserDto>(userValue);
                var claimList = user.Claims.Select(x => new Claim(x.Key, x.Value));
                claims = new ClaimsIdentity(claimList, "auth");
            }

            var principal = new ClaimsPrincipal(claims);
            return new AuthenticationState(principal);
            
        }
        catch
        {
            return await Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

    public async Task UpdateAuthenticationState(UserSession userSession)
    {
        ClaimsPrincipal claimsPrincipal;
        if (userSession != null)
        {
            await _sessionStorage.SetAsync(UserSessionKey, userSession);
            claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.UserName),
                new Claim(ClaimTypes.Role, userSession.Role)
            }));
        }
        else
        {
            await _sessionStorage.DeleteAsync(UserSessionKey);
            claimsPrincipal = _anonymous;
        }
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
    }

    public void LogOutAsync()
    {
        throw new NotImplementedException();
    }
}