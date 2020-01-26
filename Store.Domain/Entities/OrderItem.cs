using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class OrderItem: Entity
    {

        public Product Product { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }


        public OrderItem(Product product, int quantity)
        {

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(product, "Product", "Produto Inválido")
                    .IsGreaterThan(quantity,0,"Quantity", "A quantidade deve ser maior que zero")
                );

            Product = product;
            Price = Product != null ? Product.Price : 0;
            Quantity = quantity;
        }

        public decimal Total()
        {
            return Price * Quantity;
        }

    }
}
