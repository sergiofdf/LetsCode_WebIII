using LetsCode_WebIII.Core.Interfaces;
using LetsCode_WebIII.Core.Services;
using LetsCode_WebIII.Filters;
using LetsCode_WebIII.Infra.Data.Repository;
using LetsCode_WebIII.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("PolicyCors",
        policy =>
        {
            policy.WithOrigins("https://localhost:7179")
                   .WithOrigins("http://127.0.0.1:5173")
                   .WithOrigins("https://eventos-botucatu-sergio.netlify.app")
                  .WithMethods("GET", "POST", "PUT", "DELETE");
            policy.AllowAnyHeader();
        });
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(ClienteMapper));

builder.Services.AddMvc(options =>
{
    options.Filters.Add<GeneralExceptionFilter>();
}
);

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<GaranteCpfNaoFoiCadastradoActionFilter>();
builder.Services.AddScoped<ValidaUpdateActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("PolicyCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
