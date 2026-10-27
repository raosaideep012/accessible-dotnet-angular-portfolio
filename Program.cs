using AccessibleEnterprisePortal.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("client", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseCors("client");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var employees = new List<Employee>
{
    new()
    {
        Id = 1,
        Name = "Avery Johnson",
        Email = "avery.johnson@example.com",
        Department = "Engineering",
        Status = "Active"
    },
    new()
    {
        Id = 2,
        Name = "Jordan Lee",
        Email = "jordan.lee@example.com",
        Department = "Finance",
        Status = "Active"
    },
    new()
    {
        Id = 3,
        Name = "Morgan Patel",
        Email = "morgan.patel@example.com",
        Department = "Operations",
        Status = "Inactive"
    }
};

app.MapGet("/api/employees", () =>
{
    return Results.Ok(employees.OrderBy(x => x.Name));
});

app.MapPost("/api/employees", (Employee employee) =>
{
    var nextId = employees.Count == 0 ? 1 : employees.Max(x => x.Id) + 1;

    var created = new Employee
    {
        Id = nextId,
        Name = employee.Name.Trim(),
        Email = employee.Email.Trim(),
        Department = employee.Department.Trim(),
        Status = employee.Status
    };

    employees.Add(created);

    return Results.Created($"/api/employees/{created.Id}", created);
});

app.MapPut("/api/employees/{id:int}", (int id, Employee employee) =>
{
    var existing = employees.FirstOrDefault(x => x.Id == id);
    if (existing is null)
    {
        return Results.NotFound();
    }

    existing.Name = employee.Name.Trim();
    existing.Email = employee.Email.Trim();
    existing.Department = employee.Department.Trim();
    existing.Status = employee.Status;

    return Results.Ok(existing);
});

app.Run();
