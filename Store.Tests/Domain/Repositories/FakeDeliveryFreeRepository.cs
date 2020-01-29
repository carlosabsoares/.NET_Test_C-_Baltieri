using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Domain.Repositories
{
    public class FakeDeliveryFreeRepository : IDeliveryFreeRepository
    {
        public decimal Get(string zipCode)
        {
            return 10;
        }
    }
}
