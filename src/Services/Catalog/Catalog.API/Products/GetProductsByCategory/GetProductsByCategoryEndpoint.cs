
namespace Catalog.API.Products.GetProductsByCategory {

    public record GetProductsByCategoryRequest(string Category);
    public record GetProductsByCategoryResponse(IEnumerable<Product> Products);

    public class GetProductsByCategoryEndpoint : ICarterModule {
        public void AddRoutes(IEndpointRouteBuilder app) {
            app.MapGet("/products/category/{Category}", async (string Category, ISender sender) => {

                var result = await sender.Send(new GetProductsByCategoryQuery(Category));

                var response = result.Adapt<GetProductsByCategoryResponse>();

                return Results.Ok(response);

            })
            .WithName("GetProductsByCategory");
        }
    }
}
