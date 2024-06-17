using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;
using OutOfOffice.DOMAIN;
using OutOfOffice.WebAPI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<EmployeeService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        b => b.MigrationsAssembly("OutOfOffice.DAL"));
});

builder.Logging.AddConsole();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    var appUserInitializer = new AppUserInitializer(context);
    appUserInitializer.InitializeAppUsers();

    var roleInitializer = new RoleInitializer(context);
    roleInitializer.InitializeRoles();

    var positionInitializer = new PositionInitializer(context);
    positionInitializer.InitializePositions();

    var subdivisionInitializer = new SubdivisionInitializer(context);
    subdivisionInitializer.InitializeSubdivisions();

    var employeeStatusInitializer = new EmployeeStatusInitializer(context);
    employeeStatusInitializer.InitializeEmployeeStatuses();

    //var projectTypeInitializer = new ProjectTypeInitializer(context);
    //projectTypeInitializer.InitializeProjectTypes();

    //var employeeInitializer = new EmployeeInitializer(context);
    //employeeInitializer.InitializeEmployees();

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
