using API_megaplay.Data;
using API_megaplay.Repository;
using API_megaplay.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API_megaplay.Constants;

var builder = WebApplication.CreateBuilder(args);

var dbConnectionString = builder.Configuration.GetConnectionString("ConexionMegaplay");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnectionString));

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFavoritesRepository, FavoritesRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Habilitar el CORS
builder.Services.AddCors(options =>
{
    // Añadir politica
    options.AddPolicy(
        PolicyNames.AllowSpecificOrigin,
        builder =>
        {
            builder
                .WithOrigins("http://localhost:4200") // Solo aplicaciones que se ejecuten desde el puerto 4200 pueden ejecutar solicitudes
                .AllowAnyMethod() // Permite cualquier método
                .AllowAnyHeader(); // Permite cualquier cabecera
        }
    );
});

// Configuración del sistema de autenticación con JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Puedes activar esto si usas un issuer
            ValidateAudience = false, // Puedes activar esto si usas un audience
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["ApiSettings:SecretKey"]!)
            )
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware del CORS
app.UseCors(PolicyNames.AllowSpecificOrigin);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();