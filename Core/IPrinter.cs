using System;
using System.Collections.Generic;

namespace Core
{
    public interface IPrinter
    {
        string PrintStatement(List<ITransaction> transactions);
    }
}