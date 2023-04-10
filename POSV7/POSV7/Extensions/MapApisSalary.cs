using POSV7.Models;
using POSV7.Repository;

namespace POSV7.Extensions
{
    public static class MapApisSalary
    {
        public static void MapApiSalary(this WebApplication app)
        {
            app.MapGet("/api/Salary", async (ISalaryRepository SalaryRepo) =>
            {
                var salary = await SalaryRepo.GetAll();
                return Results.Ok(salary);
            });

            app.MapGet("/api/Salary/{id}/{Employeeid}", async (int EmployeeId, ISalaryRepository SalaryRepo) =>
            {

                var salary = await SalaryRepo.GetByEmployeeId(EmployeeId);
                if (salary == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(salary);
            });

            app.MapPost("/api/Salary", async (ISalaryRepository SalaryRepo, CreateSalaryDTO salaries) =>
            {

           
                var result = await SalaryRepo.Add(salaries);
                if (result)

                    return Results.Ok("Saved");

                return Results.Problem();
            });

            app.MapPut("/api/Salary", async (ISalaryRepository SalaryRepo, Salary salaries) =>
            {
                var result = await SalaryRepo.Update(salaries);
                if (result)

                    return Results.Ok("Updated");

                return Results.Problem();
            });

            app.MapGet("/api/Salary/{id}", async (int id, ISalaryRepository SalaryRepo) =>
            {
                var salary = await SalaryRepo.GetById(id);
                if (salary == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(salary);
            });

            app.MapDelete("/api/Salary/{id}", async (int id, ISalaryRepository SalaryRepo) =>
            {
                var salary = await SalaryRepo.Delete(id);
                if (salary)

                    return Results.Ok("Deleted");
                return Results.Problem();
            });
        }
    }
}
