using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Domain.Repositories
{
    public class FakeOrderRepository: IOrderRepository
    {
        public void Save(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
