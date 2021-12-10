using AutoMapper;
using TicTacToeGameApi.Models;
using TicTacToeGameApi.Models.DTOs;

namespace TicTacToeGameApi.AutoMapperProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Player, PlayerDTO>();

            CreateMap<Game, GameDTO>()
                .ForMember(dest => dest.DeckSize, opt =>
                {
                    opt.MapFrom(src => src.Deck.Count);
                });

            CreateMap<Team, TeamDTO>();

            CreateMap<GameSetup, GameSetupDTO>().ForMember(dest => dest.IsPasswordProtected, opt =>
            {
                opt.MapFrom(src => src.Password.Length > 0);
            });
        }
    }
}