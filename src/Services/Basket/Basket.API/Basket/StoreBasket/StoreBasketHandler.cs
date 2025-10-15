
using Discount.Grpc;

namespace Basket.API.Basket.StoreBasket {

    public record StoreBasketCommand(ShoppingCart Cart):ICommand<StoreBasketResult>;
    public record StoreBasketResult(string username);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand> {

        public StoreBasketCommandValidator() {
            RuleFor(x => x.Cart).NotNull().WithMessage("Cart is required");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("Username is required");
        }
    }

    internal class StoreBasketCommandHandler 
        (IBasketRepository repository, DiscountProtoService.DiscountProtoServiceClient discountProto)
        : ICommandHandler<StoreBasketCommand, StoreBasketResult> {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken) {
            ShoppingCart cart = command.Cart;

            foreach (var item in cart.Items) {

                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;
            }

            await repository.StoreBasket(cart, cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);
        }
    }
}
