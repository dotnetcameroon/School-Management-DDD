using Api.Application.Common;

namespace Api.Application.UsersManagement.GetUsers;

public record GetUsersQuery() : IRequest<Result<PagedList<UserResponse>>>;
