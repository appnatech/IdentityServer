using System.Threading.Tasks;
using application.Commands.user;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using service.rest.v1.requests;

namespace service.rest.v1.controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        [ActionName(nameof(CreateUserAsync))]
        public async Task<ActionResult> CreateUserAsync([FromBody]CreateUserRequest request)
        {
            string userId = await _mediator.Send(new CreateUserCommand(request.UserName,request.Password)
            {
                Name=request.Name
            })
            .ConfigureAwait(false);

            return Ok(userId);
        }
    }
}