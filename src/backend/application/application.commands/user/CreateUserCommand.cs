using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using application.core.repositories;
using application.core.models;
using MediatR;
using IdentityModel;
using application.commands;

namespace application.Commands.user
{
    public class CreateUserCommand:BaseCommand<string>
    {
        public string Username { get;}
        public string Password { get;}

        //claims
        public string Name { get; set; }


        public CreateUserCommand(string userName,string password)
        {
            Username=userName;
            Password=password;
            Name=userName;
        }
    }

    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand,string>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var subjectId=Guid.NewGuid().ToString();

            await _userRepository.AddAsync(new User()
            {
               SubjectId=subjectId,
               IsActive=true,
               Username=request.Username,
               Password=request.Password,
               Claims=new List<Claim>()
               {
                    new Claim(JwtClaimTypes.Name, request.Name),
               }
            })
            .ConfigureAwait(false);

           return subjectId;
        }
    }
}