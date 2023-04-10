using CustomerApi.Models;
using CustomerApi.Repository;

namespace CustomerApi.Extensions
{
    public static class MapApisProduct
    {
        public static void MapApiProduct(this WebApplication app)
        {
            app.MapGet("/api/Product", async (IProductRepository productRepo) =>
            {
                var products = await productRepo.GetAll();
                return Results.Ok(products);
            });

            app.MapPost("/api/Product", async (IProductRepository productRepo, Product products) =>
            {
                {
                    var result = await productRepo.Add(products);
                    if (result)

                        return Results.Ok("Saved");

                    return Results.Problem();
                }
            });

            app.MapPut("/api/Product", async (IProductRepository productRepo, Product products) =>
            {
                var result = await productRepo.Update(products);
                if (result)

                    return Results.Ok("Updated");

                return Results.Problem();
            });

            app.MapGet("/api/Product/{id}", async (int id, IProductRepository productRepo) =>
            {
                var product = await productRepo.GetById(id);
                if (product == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(product);
            });
            app.MapDelete("/api/Product/{id}", async (int id, IProductRepository productRepo) =>
            {
                var product = await productRepo.Delete(id);
                if (product)

                    return Results.Ok("Deleted");
                return Results.Problem();
            });
        }
    }
}
