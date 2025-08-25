
namespace Catalog.API.Products.GetProductById {

    public record GetProductByIdQuery(Guid ProductId) : IQuery<GetProductByIdResult> { };
    public record GetProductByIdResult(Product product) { };

    internal class GetProductByIdQueryHandler (
        IDocumentSession session
    )
        : IQueryHandler<GetProductByIdQuery, GetProductByIdResult> {

        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken) {

            var found = await session.LoadAsync<Product>(query.ProductId, cancellationToken);

            if (found is null) {
                throw new ProductNotFoundException();
            }

            return new GetProductByIdResult(found);
        }
    }
}
