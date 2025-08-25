
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.GetProductById {

    public record GetProductByIdResponse(Product product);

    public class GetProductByIdEndpoint : ICarterModule {

        public void AddRoutes(IEndpointRouteBuilder app) {
            app.MapGet("/product/{id}", async (Guid id, ISender sender) => {

                var found = await sender.Send(new GetProductByIdQuery(id));

                var response = new GetProductByIdResponse(found.product);

                return Results.Ok(response);

            })
            .WithName("GetProductById");
        }
    }
}
