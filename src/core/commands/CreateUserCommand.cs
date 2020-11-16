using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using core.models;
using core.store;
using IdentityModel;
using MediatR;

namespace core.Commands
{
    public class CreateUserCommand:BaseCommand<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //claims
        public string Name { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
    }

    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand,User>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
           return _userRepository.AddAsync(new User()
           {
               SubjectId=Guid.NewGuid().ToString(),
               IsActive=true,
               Username=request.Username,
               Password=request.Password,
               Claims=new List<Claim>()
               {
                    new Claim(JwtClaimTypes.Name, request.Name),
                    new Claim(JwtClaimTypes.GivenName, request.GivenName),
                    new Claim(JwtClaimTypes.FamilyName, request.FamilyName),
               }
           });
        }
    }
}