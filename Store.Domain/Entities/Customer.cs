using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using Store.Domain.Enums;
using Store.Domain.Repositories.Interfaces;

namespace Store.Domain.Entities
{
    public class Customer: Entity
    {

        public Customer(string name, string email)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNull(name, "Custumer", "O nome deve ser informado")
                    .IsNotNull(email, "Custumer", "email deve ser informado")
            );

            Name = name;
            Email = email;

        }

        public string Name { get; set; }
        public string  Email { get; set; }


    }
}
