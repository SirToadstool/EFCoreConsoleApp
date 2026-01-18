using Fiddle.Models;
using Fiddle.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Fiddle;

public class Program
{
    public static async Task Main()
    {
        ServiceCollection services = new();

        services.AddLogging(builder =>
        {
            builder.AddConsole();
            builder.SetMinimumLevel(LogLevel.Information);
        });

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("Data Source=app.db"));

        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        ServiceProvider serviceProvider = services.BuildServiceProvider();

        using IServiceScope scope = serviceProvider.CreateScope();
        ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.EnsureCreatedAsync();

        UserManager<ApplicationUser> userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        Console.WriteLine("\nFinding user...");
        ApplicationUser? foundUser = await userManager.FindByEmailAsync("test.testerson@test.com");
        if (foundUser != null)
        {
            Console.WriteLine($"✓ Found user: {foundUser.Email}");
        }
        else
        {
            Console.WriteLine("Creating user...");
            foundUser = new()
            {
                FirstName = "Test",
                LastName = "Testerson",
                Age = 99,
                DateOfBirth = new DateTime(1, 1, 1),
                UserName = "test.testerson@test.com",
                Email = "test.testerson@test.com"
            };

            IdentityResult result = await userManager.CreateAsync(foundUser, "Password123!");

            if (result.Succeeded)
            {
                Console.WriteLine("User created successfully!");
            }
            else
            {
                Console.WriteLine("User creation failed");
                foreach (IdentityError error in result.Errors)
                {
                    Console.WriteLine($"   - {error.Description}");
                }
            }
        }

        Console.WriteLine("\nVerifying password...");
        bool isPasswordValid = await userManager.CheckPasswordAsync(foundUser ?? new ApplicationUser(), "Password123!");
        Console.WriteLine(isPasswordValid ? "✓ Password is valid" : "✗ Password is invalid");
        
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}