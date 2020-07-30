using Microsoft.AspNetCore.Hosting;
using ProjectManager.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace ProjectManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}