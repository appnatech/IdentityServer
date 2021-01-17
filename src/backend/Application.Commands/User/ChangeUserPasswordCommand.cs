using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using MediatR;

namespace Application.Commands.User
{
    public class ChangeUserPasswordCommand : BaseCommand<bool>
    {
        public string SubjectId { get; set; }
        public string NewPassword { get; }

        public ChangeUserPasswordCommand(string subjectId, string newPassword)
        {
            SubjectId = subjectId;
            NewPassword = newPassword;
        }
    }

    public class UpdateUserCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetBySubjectIdAsync(request.SubjectId);
            if (user is null)
            {
                // TODO: We should consider a method to return NotFound to API controller.
                return false;
            }

            user.Password = request.NewPassword;
            await _userRepository.UpdateAsync(request.SubjectId, user);

            return true;
        }
    }
}