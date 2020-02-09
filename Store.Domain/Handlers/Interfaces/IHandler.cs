using System;
using System.Collections.Generic;
using System.Text;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Handlers.Interfaces
{
    public interface IHandler<T> where T: ICommand
    {

        ICommandResult Handle(T command);

    }
}
