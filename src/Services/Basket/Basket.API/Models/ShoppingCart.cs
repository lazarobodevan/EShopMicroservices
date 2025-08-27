﻿namespace Basket.API.Models {
    public class ShoppingCart {

        public string UserName { get; set; } = default!;
        public List<ShoppingCarItem> Items { get; set; } = new List<ShoppingCarItem>();
        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart(string userName) {
            UserName = userName;
        }

        public ShoppingCart() { }
    }
}
