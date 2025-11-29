using System.Text;
using JogoJusto.AppDta;
using JogoJusto.AppDta.Repository;
using JogoJusto.Auth;
using JogoJusto.Middleware;
using JogoJusto.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IAuthorizationHandler, RoleAuthorizationHandler>();

#region service e repositorio
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IDesenvolvimentoRepository, DesenvolvimentoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IEsgLogRepository, EsgLogRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IMetaEsgRepository, MetaEsgRepository>();
builder.Services.AddScoped<ITokenRepository, TokenRepository>();


builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();
builder.Services.AddScoped<IDesenvolvimentoService, DesenvolvimentoService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IEsgLogService, EsgLogService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IMetaEsgService, MetaEsgService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

#endregion

#region configurando autorizacao de papel

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("weliton1912024"))
    };
});
#endregion


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.Requirements.Add(new RoleRequirement("Admin")));
    options.AddPolicy("UserPolicy", policy =>
        policy.Requirements.Add(new RoleRequirement("User")));
});

#region conection to database
var connectionString = builder.Configuration.GetConnectionString("JogoJustoConnection");

builder.Services.AddDbContext<JogoJustoDbContext>(options =>
    options.UseOracle(connectionString));
#endregion

// Add services to the container.

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
app.UseMiddleware<ErrorHanddlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
