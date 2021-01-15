using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using IdentityModel;
using MediatR;

namespace Application.Commands.User
{
    public class UpdateUserCommand : BaseCommand<bool>
    {
        public string SubjectId { get; set; }
        public string Password { get; }
        public string Name { get; set; }

        public UpdateUserCommand(string subjectId, string name, string password)
        {
            SubjectId = subjectId;
            Name = name;
            Password = password;
        }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySubjectIdAsync(request.SubjectId);
            if (user is null)
            {
                // TODO: We should consider a method to return NotFound to API controller.
                return false;
            }

            user.Password = request.Password;
            user.UpdateClaim(JwtClaimTypes.Name, request.Name);
            await _userRepository.UpdateAsync(request.SubjectId, user);

            return true;
        }
    }
}