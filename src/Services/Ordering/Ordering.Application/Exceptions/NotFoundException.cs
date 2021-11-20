using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Exceptions
{
    class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
