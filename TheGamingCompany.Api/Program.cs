using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TheGamingCompany.Core;
using TheGamingCompany.Core.CategoryManager;
using TheGamingCompany.Core.LoanManager;
using TheGamingCompany.Core.VideoGameManager;
using TheGamingCompany.Infrastructure.Database;
using TheGamingCompany.Infrastructure.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);
var allowAllOriginsPolicy = "_allowAllOriginsPolicy";

// Add services to the container.
builder.Services.AddDbContext<TheGamingCompanyContext>(options => options.UseSqlite("DataSource=TheGamingCompany.db"));
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IVideoGameService, VideoGameService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAllOriginsPolicy,
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(allowAllOriginsPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

