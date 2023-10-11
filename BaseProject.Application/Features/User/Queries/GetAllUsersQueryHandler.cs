using AutoMapper;
using BaseProject.Application.Wrappers;
using BaseProject.Domain.Interfaces.Repositories;
using BaseProject.Domain.Models.Users;
using MediatR;

namespace BaseProject.Application.Features.User.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<UserViewModel>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<UserViewModel>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            var userViewModels = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return new Response<IEnumerable<UserViewModel>>(userViewModels);
        }
    }
}