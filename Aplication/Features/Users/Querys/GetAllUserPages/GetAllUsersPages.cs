using Application.DTO_s;
using Application.Espesification;
using Application.Filters.Users;
using Application.Interfaces.Repositories;
using Application.Whappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Querys.GetAllUserPages
{
    public class GetAllUsersPages : IRequest<PagesResponse<List<UserDto>>>
    {
        public UsersFilters? Fiters { get; set; }

        public class GetAllUsersPagesHandler : IRequestHandler<GetAllUsersPages, PagesResponse<List<UserDto>>>
        {
            private readonly IRepositoryAsync<User> _repositoryAsync;
            private readonly IMapper _mapper;
            public GetAllUsersPagesHandler(IRepositoryAsync<User> repositoryAsync, IMapper mapper)
            {
                _repositoryAsync = repositoryAsync;
                _mapper = mapper;
            }
            public async Task<PagesResponse<List<UserDto>>> Handle(GetAllUsersPages request, CancellationToken cancellationToken)
            {
                if(request.Fiters != null)
                {
                    var users = await _repositoryAsync.ListAsync(new GetAllUserPagesSpecification(request.Fiters));
                    var result = _mapper.Map<List<UserDto>>(users);
                    return new PagesResponse<List<UserDto>>(result, request.Fiters.PageNumber, request.Fiters.PageZise);
                }
                return new PagesResponse<List<UserDto>>(new List<UserDto>(), request.Fiters.PageNumber, request.Fiters.PageZise);
            }
        }
    }
}
