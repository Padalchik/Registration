using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Registration;

namespace Registration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DataBaseConnectionString"));
            });

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<ApplicationDBContext>();

            var app = builder.Build();

            app.UseStaticFiles();
            app.MapRazorPages();

            app.Run();
        }
    }
}
