using Microsoft.EntityFrameworkCore;
using MvcStartApp.Controllers.Middlewares;
using MvcStartApp.Models;
using MvcStartApp.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ����������� ��������
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

// �������� ������ ����������� �� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� DbContext (SQL Server)
builder.Services.AddDbContext<MvcAppContext>(options =>
    options.UseSqlServer(connection));

var app = builder.Build();

// ���������� ����������� � �������������� �� �������������� ����
app.UseMiddleware<LoggingMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
