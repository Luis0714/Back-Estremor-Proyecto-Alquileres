using Application.DTO_s;
using Application.Features.Roles.Command.CreateRolCommand;
using Application.Features.Users.Commands.CrateUserCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            #region Commands User
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDto>();
            #endregion

            #region Rol
            CreateMap<Rol, RolDto>();
            CreateMap<CreateRolCommand, Rol>();
            #endregion
        }
    }
}
