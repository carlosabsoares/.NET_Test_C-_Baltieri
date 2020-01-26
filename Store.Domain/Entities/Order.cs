using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities
{
    public class Order : Entity
    {
        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public string Number { get; private set; }
        public IList<OrderItem> Items { get; private set; }
        public EOrderStatus Status { get; private set; }
        public decimal DeliveryFree { get; private set; }
        public Discount Discount { get; private set; }


        public Order(Customer customer, decimal deliveryFree, Discount discount)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(customer, "Customer", "Cliente inválido")
                );


            Customer = customer;
            Date = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatus.WaitingPayment;
            DeliveryFree = deliveryFree;
            Discount = discount;
            Items = new List<OrderItem>();
        }

        public void AddItem ( Product product, int quantity)
        {
            var item = new OrderItem(product, quantity);

            //AddNotifications(item.Notifications);
            if (item.Valid) //item.Notifications
                Items.Add(item);
        }

        public decimal Total()
        {
            decimal total = 0;

            foreach (var item in Items)
            {
                total += item.Total();
            }

            total += DeliveryFree;
            total -= Discount != null ? Discount.Value():0;

            return total;

        }
        public void Pay(decimal amount)
        {
            if (amount == Total())
                this.Status = EOrderStatus.WaitingDelivery;
        }

        public void Cancel()
        {
            this.Status = EOrderStatus.Canceled;
        }


    }
}
