﻿using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Entities;

namespace Store.Domain.Repositories.Interfaces
{
    public interface IDiscountRepository
    {

        Discount Get(string code);

    }
}
