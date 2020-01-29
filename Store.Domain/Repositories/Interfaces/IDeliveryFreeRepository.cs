using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Repositories.Interfaces
{
    public interface IDeliveryFreeRepository
    {
        decimal Get(string zipCode);
    }
}
