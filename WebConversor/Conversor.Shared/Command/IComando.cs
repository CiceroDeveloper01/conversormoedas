using System;
using System.Collections.Generic;
using System.Text;

namespace Conversor.Shared.Command
{
    public interface IComando<T> where T : IComandoBase
    {
        IComandoResultado Handle(T command);
    }
}

