using Microsoft.JSInterop;

namespace Client.WebApp.Helper;

public static class SessionHelper
{
    public static async ValueTask<string> GetAccessToken(this IJSRuntime jSRuntime)
    {
        return await jSRuntime.InvokeAsync<string>("getAccessToken");
    }
}
