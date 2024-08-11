using FvckAds.Application.RepositoryInterfaces;
using FvckAds.Domain.Users;
using MediatR;

namespace FvckAds.Application.Users.Commands;

public class CreateUserCommandHandler(IGenericRepository<User> userRepo) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var res = await userRepo.AddEntityAsync(new User() { Tag = request.Tag, CreateDate = DateTime.Now.ToUniversalTime() },
            cancellationToken);

        return res;
    }
}