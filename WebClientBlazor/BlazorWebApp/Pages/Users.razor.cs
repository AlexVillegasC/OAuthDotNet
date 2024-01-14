using Microsoft.AspNetCore.Authorization;

namespace Client.WebApp.Pages
{
    [Authorize(Roles = "Admin")]
    public partial class Users
    {
        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
        }
    }
}
