using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using signalRAh.Infrastructures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();
builder.Services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer("Server=localhost,1433;Database=Sick.Db;Uid=sa;Pwd=yourStrong(!)Password");
            });

builder.Services.AddHostedService<ScanChanges>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // using (var scope = app.Services.CreateScope())
    // {
    //     var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    //     context.Database.EnsureCreated();
    // }
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapHub<HosHub>("/chatHub");
app.MapControllers();

builder.WebHost.UseUrls("http://localhost:5002");


app.Run();
