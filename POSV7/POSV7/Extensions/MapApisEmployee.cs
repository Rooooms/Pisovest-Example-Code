using POSV7.Models;
using POSV7.Repository;

namespace POSV7.Extensions
{
    public static class MapApisEmployee
    {
        public static void MapApiEmployee(this WebApplication app)
        {
            app.MapGet("/api/Employee", async (IEmployeeRepository employeeRepo) =>
            {
                var employee = await employeeRepo.GetAll();
                return Results.Ok(employee);
            });

            app.MapPost("/api/Employee", async (IEmployeeRepository employeeRepo, Employee employees) =>
            {

                var result = await employeeRepo.Add(employees);
                if (result)

                    return Results.Ok("Saved");

                return Results.Problem();
            });

            app.MapPut("/api/Employee", async (IEmployeeRepository employeeRepo, Employee employees) =>
            {
                var result = await employeeRepo.Update(employees);
                if (result)

                    return Results.Ok("Updated");

                return Results.Problem();
            });

            app.MapGet("/api/Employee/{id}", async (int SalariesId, IEmployeeRepository employeeRepo) =>
            {
                var employee = await employeeRepo.GetById(SalariesId);
                if (employee == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(employee);
            });

            app.MapDelete("/api/Employee/{id}", async (int id, IEmployeeRepository employeeRepo) =>
            {
                var employee = await employeeRepo.Delete(id);
                if (employee)
                    return Results.Ok("Deleted");
                return Results.Problem();
            });
        }
    }
}
