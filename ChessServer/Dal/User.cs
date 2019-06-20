using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer.Dal
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
    }
}
