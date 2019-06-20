using ChessServer.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessServer.Contracts
{
    public interface IMatchService
    {
        IEnumerable<MatchDto> GetAllMyMatch(Guid userId);
        MatchDto GetMatch(Guid id);

        MatchDto Creatematch(Guid white, Guid black);

        bool ValidateMove(Guid userId, string fen);
    }
}
