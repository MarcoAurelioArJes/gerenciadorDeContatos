using GerenciadorDeContatos.API.Repositorio;
using GerenciadorDeContatos.API.Repositorio.BancoDeDados;
using GerenciadorDeContatos.API.Services;
using GerenciadorDeContatos.API.Services.ValidacoesService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextoDoBancoDeDados>(opcs =>
{
    opcs.UseSqlite(builder.Configuration.GetConnectionString("Conexao"));
});

builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ContatoService>();
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<ContatoRepositorio>();
builder.Services.AddScoped<ValidarUsuarioService>(); 
builder.Services.AddScoped<ValidarContatoService>(); 

builder.Services
       .AddAuthentication(opcs =>
       {
           opcs.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           opcs.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
       })
       .AddJwtBearer(opcs =>
       {
           opcs.RequireHttpsMetadata = true;
           opcs.SaveToken = true;
           opcs.TokenValidationParameters = new TokenValidationParameters
           {
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(TokenService.PrivateKey)),
               ValidateIssuer = false,
               ValidateAudience = false
           };
       });

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

var scope = app.Services.CreateScope();
scope.ServiceProvider.GetService<ContextoDoBancoDeDados>().Database.Migrate();

app.UseAuthentication();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
