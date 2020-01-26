using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;

namespace Store.Domain.Entities
{
    public class Product: Entity
    {

        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }

        public Product(string title, decimal price, bool active)
        {

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(active, "Active", "Produto tem que ter status")
                    .IsNotNull(title, "Title", "Produto tem que ter Título")
            );


            Title = title;
            Price = price;
            Active = active;

        }

        public void ChangeInfo(string title, decimal price, bool active)
        {
            Title = title;
            Price = price;
            Active = active;

        }


}
}
