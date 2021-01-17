using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Domain.Core.Repositories;
using IdentityModel;
using MediatR;

namespace Application.Commands.User
{
    public class CreateUserCommand : BaseCommand<string>
    {
        public string Username { get; }
        public string Password { get; }
        public string Name { get; set; }

        public CreateUserCommand(string userName, string password)
        {
            Username = userName;
            Password = password;
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var subjectId = Guid.NewGuid().ToString();

            await _userRepository.AddAsync(new Domain.Core.Models.User()
            {
                SubjectId = subjectId,
                IsActive = true,
                Username = request.Username,
                Password = request.Password,
                Claims = new List<Claim>()
                {
                    new Claim(JwtClaimTypes.Name, request.Name),
                }
            });

            return subjectId;
        }
    }
}