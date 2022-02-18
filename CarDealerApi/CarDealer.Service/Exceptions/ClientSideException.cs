using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.Exceptions
{
    public class ClientSideException : NotFoundException
    {
        public ClientSideException(string message) : base(message)
        {

        }
    }
}
