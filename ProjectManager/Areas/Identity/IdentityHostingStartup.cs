using Microsoft.AspNetCore.Hosting;
using ProjectManager.PL.Areas.Identity;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace ProjectManager.PL.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}