using POS.Application.Extensions;
using POS.Infrastructure.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

var Myallow = "_Myconfig";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        Myallow,
        builder =>
        {
            builder
                .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                .AllowAnyHeader()
                .AllowAnyMethod();
        }
    );
});

// Add services to the container.

var Configuration = builder.Configuration;
builder.Services.AddControllers();

builder.Services.AddInjectionInfrastructure(Configuration);
builder.Services.AddInjectionApplication(Configuration);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors(Myallow);
app.Run();
