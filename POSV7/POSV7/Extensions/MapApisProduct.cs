using POSV7.Models;
using POSV7.Repository;
using Microsoft.EntityFrameworkCore;
using POSV7.Data;

namespace POSV7.Extensions
{
    public static class MapApisProduct
    {
        public static void MapApiProduct(this WebApplication app)
        {
            app.MapGet("/api/Product", async (IProductRepository ProductRepo) =>
            {
                var products = await ProductRepo.GetAll();
                return Results.Ok(products);
            });

            app.MapGet("/api/Product/{id}/{Categoryid}", async (int CategoryId, IProductRepository ProductRepo) =>
                {
                    
                    var products = await ProductRepo.GetByCategoryId(CategoryId);
                    if (products == null)

                        return Results.NotFound("NotFound");

                    return Results.Ok(products);
                });

            app.MapPost("/api/Product", async (IProductRepository ProductRepo, CreateProductDTO products) =>
            {
                


                //products.CategoryName = category.CategoryName;
                var result = await ProductRepo.Add(products);
                if (result)

                    return Results.Ok("Saved");

                return Results.Problem();
            });

            app.MapPut("/api/Product", async (IProductRepository ProductRepo, Products products) =>
            {
                var result = await ProductRepo.Update(products);
                if (result)

                    return Results.Ok("Updated");

                return Results.Problem();
            });

            app.MapGet("/api/Product/{id}", async (int id, IProductRepository ProductRepo) =>
            {
                var products = await ProductRepo.GetById(id);
                if (products == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(products);
            });
            app.MapDelete("/api/Product/{id}", async (int id, IProductRepository ProductRepo) =>
            {
                var products = await ProductRepo.Delete(id);
                if (products)

                    return Results.Ok("Deleted");
                return Results.Problem();
            });
        }
    }
}