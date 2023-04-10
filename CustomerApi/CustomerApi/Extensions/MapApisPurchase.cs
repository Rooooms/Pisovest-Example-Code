using CustomerApi.Models;
using CustomerApi.Repository;

namespace CustomerApi.Extensions
{
    public static class MapApisPurchase
    {
        public static void MapApiPurchase(this WebApplication app)
        {
            app.MapGet("/api/Purchase", async (IPurchaseRepository purchaseRepo) =>
            {
                var purchase = await purchaseRepo.GetAll();
                return Results.Ok(purchase);
            });

            app.MapPost("/api/Purchase", async (IPurchaseRepository purchaseRepo, CreatePurchaseDTO purchases) =>
            {
                {
                    var result = await purchaseRepo.Add(purchases);
                    if (result)

                        return Results.Ok("Saved");

                    return Results.Problem();
                }
            });

            app.MapPut("/api/Purchase", async (IPurchaseRepository purchaseRepo, Purchase purchases) =>
            {
                var result = await purchaseRepo.Update(purchases);
                if (result)

                    return Results.Ok("Updated");

                return Results.Problem();
            });

            app.MapGet("/api/Purchase/{id}", async (int id, IPurchaseRepository purchaseRepo) =>
            {
                var purchase = await purchaseRepo.GetById(id);
                if (purchase == null)

                    return Results.NotFound("NotFound");

                return Results.Ok(purchase);
            });
            app.MapDelete("/api/Purchase/{id}", async (int id, IPurchaseRepository purchaseRepo) =>
            {
                var purchase = await purchaseRepo.Delete(id);
                if (purchase)

                    return Results.Ok("Deleted");
                return Results.Problem();
            });
        }
    }
}
