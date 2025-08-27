
namespace Catalog.API.Products.DeleteProduct {

    public record DeleteProductCommand(Guid ProductId) : ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
    internal class DeleteProductHandler (IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult> {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken) {

            var found = await session.LoadAsync<Product>(command.ProductId, cancellationToken);

            if(found == null) {
                throw new ProductNotFoundException(command.ProductId);
            }

            session.Delete<Product>(command.ProductId);
            await session.SaveChangesAsync(cancellationToken);

            return new DeleteProductResult(true);
        }
    }
}
