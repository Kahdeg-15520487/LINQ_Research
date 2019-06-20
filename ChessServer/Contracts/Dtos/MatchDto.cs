using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer.Contracts.Dtos
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public UserDto White { get; set; }
        public UserDto Black { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public BoardDto[] BoardStates { get; set; }
    }
}
