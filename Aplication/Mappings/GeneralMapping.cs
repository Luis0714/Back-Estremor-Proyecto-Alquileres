using Application.DTO_s;
using Application.Features.DocumentsTypes.Commands.CreateDocumentTypeCommand;
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
            #region User
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, UserDto>();
            #endregion

            #region Rol
            CreateMap<Rol, RolDto>();
            CreateMap<CreateRolCommand, Rol>();
            #endregion

            #region DocumentType
            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<CreateDocumentTypeCommand, DocumentType>();
            #endregion

        }
    }
}
