using AutoMapper;
using DrivingSchoolCRM.Prototype.MVC.Data;
using DrivingSchoolCRM.Prototype.MVC.Mapping;
using DrivingSchoolCRM.Prototype.MVC.Services.User.IUser;
using DrivingSchoolCRM.Prototype.MVC.Services.User;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolCRM.Prototype.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Add sql server and DbContext
            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            IMapper mapper = MappingProfile.RegisterMaps().CreateMapper();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddSingleton(mapper);
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Authentification}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
