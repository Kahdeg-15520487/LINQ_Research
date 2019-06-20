using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer.Dal
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid WhiteId { get; set; }
        public User White { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime FinishedDate { get; set; }
        public virtual ICollection<BoardState> BoardStates { get; set; }
    }
}
