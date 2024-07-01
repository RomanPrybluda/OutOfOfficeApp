using Microsoft.EntityFrameworkCore;
using OutOfOffice.DAL;
using OutOfOffice.DOMAIN;
using OutOfOffice.WebAPI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AppUserService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<LeaveRequestService>();
builder.Services.AddScoped<ApprovalRequestService>();
builder.Services.AddScoped<ProjectService>();


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
        policy.WithOrigins("http://localhost:5173");
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

    var projectStatusInitializer = new ProjectStatusInitializer(context);
    projectStatusInitializer.InitializeProjectStatuses();

    var requestStatusInitializer = new RequestStatusInitializer(context);
    requestStatusInitializer.InitializeRequestStatuses();

    var hrManagerInitializer = new HRManagerInitializer(context);
    hrManagerInitializer.InitializeHRManagers();

    var projectManagerInitializer = new ProjectManagerInitializer(context);
    projectManagerInitializer.InitializeProjectManagers();

    var employeeInitializer = new EmployeeInitializer(context);
    employeeInitializer.InitializeEmployees();

    var leaveRequestInitializer = new LeaveRequestInitializer(context);
    leaveRequestInitializer.InitializeLeaveRequests();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();
