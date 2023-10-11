using BaseProject.Application.Wrappers;
using BaseProject.Domain.Models.Users;
using MediatR;

namespace BaseProject.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<Response<IEnumerable<UserViewModel>>>
    {

    }
}