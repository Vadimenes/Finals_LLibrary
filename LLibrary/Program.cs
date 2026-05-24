using LLibrary.Components;
using Microsoft.EntityFrameworkCore;
using LLibrary.Data;
using FluentValidation;
using LLibrary.Validators;



var builder = WebApplication.CreateBuilder(args);

// 1. Добавляем сервисы Blazor Server
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// 2. Регистрируем DbContextFactory (это ключевой момент для Blazor)
builder.Services.AddDbContextFactory<LibraryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddValidatorsFromAssemblyContaining<BookValidator>();

var app = builder.Build();

// Конфигурация HTTP пайплайна
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Маппинг компонентов Blazor
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Получаем фабрику контекста
        var contextFactory = services.GetRequiredService<IDbContextFactory<LibraryContext>>();
        using var context = contextFactory.CreateDbContext();

        // Применяем все ожидающие миграции
        await context.Database.MigrateAsync();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ошибка при применении миграций базы данных.");
    }
}

app.Run();