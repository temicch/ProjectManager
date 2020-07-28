using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(ProjectManager.Areas.Identity.IdentityHostingStartup))]

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