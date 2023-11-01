using CmsConfeitaria.Business;
using CmsConfeitaria.Business.AutoMapperProfile;
using CmsConfeitaria.Core.Entity;
using CmsConfeitaria.Integration;
using CmsConfeitaria.WebApi;
using CmsConfeitaria.WebApi.Handlers;
using CmsConfeitaria.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<ReceitaIngredienteProfile>();
    cfg.AddProfile<ReceitaProfile>();
    cfg.AddProfile<IngredienteProfile>();
    cfg.AddProfile<UnidadeMedidaProfile>();
    cfg.AddProfile<ComrpaProfile>();
    cfg.AddProfile<UsuarioProfile>();
    cfg.AddProfile<RotinaProfile>();
    cfg.AddProfile<TempalteEmailProfile>();
});


builder.Services.AddControllers();


builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyOrigin",
        builder =>
        {
            builder.SetIsOriginAllowed((url) =>
            {
                return true;
            })
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


builder.Services.AddDbContext<DBContextCm>(options =>
                options.UseSqlServer(
                    (builder.Configuration.GetConnectionString("cms")),
                    x => x.MigrationsAssembly("CmsConfeitaria.Integration")
                ), ServiceLifetime.Scoped);


builder.Services.Configurar();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowMyOrigin");

//app.UseMiddleware<AutenticatioHandler>();
app.UseMiddleware<ErroMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
