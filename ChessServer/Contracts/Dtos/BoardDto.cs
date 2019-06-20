using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer.Contracts.Dtos
{
    public class BoardDto
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public int Turn { get; set; }
        public bool Who { get; set; }
    }
}
