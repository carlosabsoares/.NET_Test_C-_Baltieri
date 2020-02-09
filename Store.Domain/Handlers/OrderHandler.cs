using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Flunt.Notifications;
using Store.Domain.Commands;
using Store.Domain.Commands.Interfaces;
using Store.Domain.Entities;
using Store.Domain.Handlers.Interfaces;
using Store.Domain.Repositories.Interfaces;
using Store.Domain.Utils;

namespace Store.Domain.Handlers
{
    public class OrderHandler : Notifiable, IHandler<CreateOrderCommand>
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IDeliveryFreeRepository _deliveryFreeRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderHandler(
            ICustomerRepository customerRepository,
            IDeliveryFreeRepository deliveryFreeRepository,
            IDiscountRepository discountRepository,
            IProductRepository productRepository,
            IOrderRepository orderRepository
            )
        {
            _customerRepository = customerRepository;
            _deliveryFreeRepository = deliveryFreeRepository;
            _discountRepository = discountRepository;
            _productRepository = productRepository;
            _orderRepository = _orderRepository;
        }

        public ICommandResult Handle(CreateOrderCommand command)
        {
            command.Validate();
            if(command.Invalid)
                return new GenericCommandResult(false,"Pedido inválido",command.Notifications);

            var customer = _customerRepository.Get(command.Customer);
            var deliveryFree = _deliveryFreeRepository.Get(command.ZipCode);
            var discount = _discountRepository.Get(command.PromoCode);

            //Gerar o pedido
            var products = _productRepository.Get(ExtractGuids.Extract(command.Items)).ToList();

            var order = new Order(customer,deliveryFree,discount);
            foreach (var item in command.Items)
            {
                var product = products.Where(x => x.Id == item.Product).FirstOrDefault();
                order.AddItem(product,item.Quantity);
            }


            // 5. Agrupa as notificações
            AddNotifications(order.Notifications);

            if(Invalid)
                return new GenericCommandResult(false,"Falha ao gerar o pedido", Notifications);

            _orderRepository.Save(order);
                return  new GenericCommandResult(true,$"Pedido{order.Number} gerado com sucesso", order);
        }
    }
}
