using POSV7.Models;
using POSV7.Repository;

namespace POSV7.Extensions
{
    public static class MapApisCategory
    {
        public static void MapApiCategory(this WebApplication app)
        {
            app.MapGet("/api/Category", async (ICategoryRepository categoryRepo) =>
            {
                var category = await categoryRepo.GetAll();
                return Results.Ok(category);
            });
            
            app.MapPost("/api/Category", async (ICategoryRepository categoryRepo, Category categories) =>
            {               
                {
                    var result = await categoryRepo.Add(categories);
                    if (result)

                        return Results.Ok("Saved");

                    return Results.Problem();
                }
            });

            app.MapPut("/api/Category", async (ICategoryRepository categoryRepo, Category categories) =>
            {
                var result = await categoryRepo.Update(categories);
                if (result)

                    return Results.Ok("Updated");

                return Results.Problem();
            });

            app.MapGet("/api/Category/{id}", async (int id, ICategoryRepository categoryRepo) =>
            {
                var category = await categoryRepo.GetById(id);
                if (category == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(category);
            });
            app.MapDelete("/api/Category/{id}", async (int id, ICategoryRepository categoryRepo) =>
            {
                var category = await categoryRepo.Delete(id);
                if (category)

                    return Results.Ok("Deleted");
                return Results.Problem();
            });
        }
    }
}
