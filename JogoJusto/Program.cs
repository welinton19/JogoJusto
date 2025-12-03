using System.Text;
using FluentValidation;
using JogoJusto.AppDta;
using JogoJusto.AppDta.Repository;
using JogoJusto.Auth;
using JogoJusto.Middleware;
using JogoJusto.Service;
using JogoJusto.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddValidatorsFromAssemblyContaining<UsuarioCreateViewModelValidator>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidateAudience = true,
            ValidAudience = jwtSettings.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings.SecretKey)
            ),
            ValidateLifetime = true
        };
    });

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();

builder.Services.AddScoped<IDiversidadeService, DiversidadeService>();

builder.Services.AddScoped<IEsgLogRepository, EsgLogRepository>();
builder.Services.AddScoped<IEsgLogService, EsgLogService>();

builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();

builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();      
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();

builder.Services.AddScoped<IDesenvolvimentoRepository, DesenvolvimentoRepository>();
builder.Services.AddScoped<IDesenvolvimentoService, DesenvolvimentoService>();

builder.Services.AddScoped<IMetaEsgRepository, MetaEsgRepository>();
builder.Services.AddScoped<IMetaEsgService, MetaEsgService>();


builder.Services.AddDbContext<JogoJustoDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("JogoJustoConnection")));

var app = builder.Build();

app.UseMiddleware<ErrorHanddlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();