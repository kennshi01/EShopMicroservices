namespace Basket.API.Basket.StoreBasket;

public record StoreBaskerRequest(ShoppingCart Cart);

public record StoreBasketResponse(string UserName);

public class StoreBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/basket", async (StoreBaskerRequest request, ISender sender) =>
            {
                var command = request.Adapt<StoreBasketCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<StoreBasketResponse>();

                return Results.Created($"/basket/{response.UserName}", response);
            })
            .WithName("StoreBasket")
            .Produces<StoreBasketResponse>()
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Store Basket")
            .WithDescription("Store Basket");
    }
}