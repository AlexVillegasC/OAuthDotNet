using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace Client.WebApp.Layout;

public partial class NavMenu
{
    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }


    private bool collapseNavMenu = true;

    private string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    public bool isAdmin = false;

    private bool isAuthenticated = false;

    protected override async Task OnInitializedAsync()
    {
        var user = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User;
        isAuthenticated = user.Identity.IsAuthenticated;
        isAdmin = isAuthenticated && user.IsInRole("Admin");
    }

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}
