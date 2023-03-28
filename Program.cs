using webapi.Context;
using webapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configurar EF
builder.Services.AddSqlServer<TareaContext>(builder.Configuration.GetConnectionString("cnTareas"));
// Manera #1 de inyeccion de dependencia -- usando interfaz (Recomendada por SOLID)
builder.Services.AddScoped<IHello, HelloService>();
builder.Services.AddScoped<ITareaService, TareaService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

// Manera #2 de inyeccion de dependencia
// builder.Services.AddSingleton();

// Manera #3 de inyeccion de dependencia utilizando la clase
// builder.Services.AddScoped<IHello>(p => new HelloService());



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseTimeMiddleware();

app.MapControllers();

app.Run();
