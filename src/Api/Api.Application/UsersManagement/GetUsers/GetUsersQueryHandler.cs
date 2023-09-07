using Api.Application.Common;
using Api.Application.Repositories;

namespace Api.Application.UsersManagement.GetUsers;

public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<PagedList<UserResponse>>>
{
    private readonly IUserRepository _userRepository;

    public GetUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<PagedList<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var domainUsers = await _userRepository.GetAsync();
        var users = domainUsers.Select(
            u => new UserResponse(
                u.Id.Value,
                u.FirstName,
                u.LastName,
                u.Password.Hash,
                u.Role,
                u.Classes.Select(
                    c => c.Id.Value).ToArray()))
            .ToList();

        return new PagedList<UserResponse>(users, 1, users.Count, users.Count);
    }
}
