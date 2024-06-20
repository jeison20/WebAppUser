using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebAppUser.Models.DataContext;
using WebAppUser.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

//Realiza la busqueda de la cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("DbConection");

// Se Registra el contexto con el Entity Framework
builder.Services.AddDbContext<WebAppContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

///Se agrega secmento para el manejo de swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for manage of Users",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Jeison Vargas",
            Url = new Uri("https://www.linkedin.com/in/jeison-vargas-b66a78b4")
        },
        License = new OpenApiLicense
        {
            Name = "License MIT",
            Url = new Uri("https://example.com/license")
        }
    });
    ///Se usa para que utilize los comentarios Xml generados en los endpoints
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllersWithViews();

var app = builder.Build();
var logger = app.Services.GetRequiredService<ILogger<Program>>();

// aplica las migraciones
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<WebAppContext>();
    try
    {
        dbContext.Database.Migrate();
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while migrating the database.");
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Esta validacion es para que el swagger solo se visible en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAppUser V1");
        c.RoutePrefix = "api-docs"; // Establece el prefijo de la URL para iniciar el Swagger
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
