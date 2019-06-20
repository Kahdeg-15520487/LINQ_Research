using AutoMapper;
using ChessServer.Contracts.Dtos;
using ChessServer.Dal;

namespace ChessServer
{
    internal class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            this.CreateMap<User, UserDto>();
            this.CreateMap<Match, MatchDto>();
            this.CreateMap<BoardState, BoardDto>();

            this.CreateMap<UserDto, User>();
            this.CreateMap<MatchDto, Match>();
            this.CreateMap<BoardDto, BoardState>();
        }
    }
}