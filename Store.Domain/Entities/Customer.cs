using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Entities
{
    public class Customer: Entity
    {

        public Customer(string name, string email)
        {
            name = name;
            email = email;
        }

        public string Name { get; set; }
        public string  Email { get; set; }


    }
}
