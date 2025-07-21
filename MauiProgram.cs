using Microsoft.Extensions.Logging;
using Transaction_Flow.Model;
using Transaction_Flow.Services;
using MudBlazor.Services;
using Microsoft.EntityFrameworkCore;

namespace Transaction_Flow
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var dbPath = Path.Combine(@"D:\Study_Material\Transaction_Flow\Database\", "app.db");
                options.UseSqlite($"Filename={dbPath}"); 
            });

            builder.Services.AddSingleton<UserService>();
            builder.Services.AddScoped<TransactionServices>();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudServices();
            //builder.Services.AddScoped<LoginViewModel>();
            //builder.Services.AddScoped<TransactionViewModel>();
            //builder.Services.AddScoped<TransactionService>();
            //builder.Services.AddScoped<DebtService>();
            //builder.Services.AddScoped<DebtViewModel>();
            //builder.Services.AddScoped<DashboardViewModel>();
            //builder.Services.AddSingleton<AuthService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            builder.Services.AddSingleton<DatabaseService>(serviceProvider =>
            {
                var dbPath = @"D:\Study_Material\Transaction_Flow\Database\app.db"; 
                return new DatabaseService(dbPath);
            });

            var app = builder.Build();

            // Ensure the database is created and available
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated(); 
            }

            return app;
        }
    }
}
