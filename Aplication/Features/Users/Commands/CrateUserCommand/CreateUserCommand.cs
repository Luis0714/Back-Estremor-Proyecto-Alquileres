using Application.Constants;
using Application.DTO_s;
using Application.Espesification;
using Application.Execteptions.Validation;
using Application.Interfaces.Repositories;
using Application.Messages.User;
using Application.Services.Abstraction.AzureServices;
using Application.Services.Abstraction.SecurityServices;
using Application.Services.Abstraction.UsersServices;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Commands.CrateUserCommand
{
    public class CreateUserCommand : IRequest<Response<UserDto>>
    {
        public string? Name { get; set; }
        public IFormFile? FileImage { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? numberPhone { get; set; }
        public string? Document { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int DocumentTypeId { get; set; }
        public string? Address { get; set; }
        public int RolId { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<UserDto>>
    {
       
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<User> _repositoryAsync;
        private readonly IEncrypPasswordService _encrypPasswordService;
        private readonly IUserSerivice _userSerivice;
        private readonly IAzureBlogStorageService _azureBlogStorage;

        public CreateUserCommandHandler(
            IMapper mapper, 
            IRepositoryAsync<User> repositoryAsync, 
            IEncrypPasswordService encrypPasswordService, 
            IUserSerivice userSerivice, 
            IAzureBlogStorageService azureBlogStorage)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
            _encrypPasswordService = encrypPasswordService;
            _userSerivice = userSerivice;
            _azureBlogStorage = azureBlogStorage;
        }

        public async Task<Response<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var pathImage = await _azureBlogStorage.UploadAsync(request.FileImage, Containers.UsersContainer);
            //update image 
            /*await _azureBlogStorage.UploadAsync(request.FileImage, Containers.UsersContainer, user.imagen(string));
             * delete
             * await _azureBlogStorage.UploadAsync(Containers.UsersContainer, user.image(no null ni emty));
             * await _azureBlogStorage.UploadAsync(Containers.UsersContainer, user.image(no null ni emty));
            */
            var record = _mapper.Map<User>(request);
            record.Password = _encrypPasswordService.Encrypt(record.Password);

            if (string.IsNullOrEmpty(pathImage)) record.Image = UserConst.DEFAULTIMAGE;
            else record.Image = pathImage;

            var usuarioExistente = await _repositoryAsync.GetBySpecAsync(new GetCurrentUserSpecification(request.Email, record.Password));
            if (usuarioExistente != default) throw new ApiException(MessageUserErrors.UserExist);

         
            record.Edad = _userSerivice.CalcularEdad(record.DateOfBirth);
            var data = await _repositoryAsync.AddAsync(record, cancellationToken);
            var result = _mapper.Map<UserDto>(data);
            return new Response<UserDto>(result,MessageUserErrors.CreatedUser);
        }
    }
}
