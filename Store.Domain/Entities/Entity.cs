﻿using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Domain.Entities
{
    public class Entity: Notifiable
    {

        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }


    }
}
