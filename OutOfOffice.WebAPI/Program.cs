using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;
using OutOfOffice.DOMAIN;
using OutOfOffice.DOMAIN.Seeds;
using OutOfOffice.WebAPI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<AppUserService>();
builder.Services.AddScoped<PositionService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<SubdivisionService>();
builder.Services.AddScoped<AbsenceReasonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(AppDbContext)),
        b => b.MigrationsAssembly("OutOfOffice.DAL"));
});

builder.Logging.AddConsole();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173/");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });

});


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();

    var roleInitializer = new RoleInitializer(context);
    roleInitializer.InitializeRoles();

    var adminInitializer = new AdminInitializer(context);
    adminInitializer.InitializeAdmin();

    var appUserInitializer = new AppUserInitializer(context);
    appUserInitializer.InitializeAppUsers();

    var positionInitializer = new PositionInitializer(context);
    positionInitializer.InitializePositions();

    var subdivisionInitializer = new SubdivisionInitializer(context);
    subdivisionInitializer.InitializeSubdivisions();

    var employeeStatusInitializer = new EmployeeStatusInitializer(context);
    employeeStatusInitializer.InitializeEmployeeStatuses();

    var absenceReasonInitializer = new AbsenceReasonInitializer(context);
    absenceReasonInitializer.InitializeAbsenceReasons();

    var projectTypeInitializer = new ProjectTypeInitializer(context);
    projectTypeInitializer.InitializeProjectTypes();

    //var employeeInitializer = new EmployeeInitializer(context);
    //employeeInitializer.InitializeEmployees();

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
