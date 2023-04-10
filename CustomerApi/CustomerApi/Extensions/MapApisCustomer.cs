using CustomerApi.Repository;
using CustomerApi.Models;

namespace CustomerApi.Extensions
{
    public static class MapApisCustomer
    {
        public static void MapApiCustomer(this WebApplication app)
        {
            app.MapGet("/api/Customer", async (ICustomerRepository customerRepo) =>
            {
                var customers = await customerRepo.GetAll();
                return Results.Ok(customers);
            });

            app.MapPost("/api/Customer", async (ICustomerRepository customerRepo, Customer customers) =>
            {
                {
                    var result = await customerRepo.Add(customers);
                    if (result)

                        return Results.Ok("Saved");

                    return Results.Problem();
                }
            });

            app.MapPut("/api/Customer", async (ICustomerRepository customerRepo, Customer customers) =>
            {
                var result = await customerRepo.Update(customers);
                if (result)

                    return Results.Ok("Updated");

                return Results.Problem();
            });

            app.MapGet("/api/Customer/{id}", async (int id, ICustomerRepository customerRepo) =>
            {
                var customer = await customerRepo.GetById(id);
                if (customer == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(customer);
            });
            app.MapDelete("/api/Customer/{id}", async (int id, ICustomerRepository customerRepo) =>
            {
                var customer = await customerRepo.Delete(id);
                if (customer)

                    return Results.Ok("Deleted");
                return Results.Problem();
            });
        }
    }
}
