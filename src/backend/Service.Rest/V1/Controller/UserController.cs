using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Queries.User;
using Domain.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Rest.V1.Requests;

namespace Service.Rest.V1.Controller
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ActionName(nameof(CreateUserAsync))]
        public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserRequest request)
        {
            string userId = await _mediator.Send(new CreateUserCommand(request.UserName, request.Password)
            {
                Name = request.Name
            })
            .ConfigureAwait(false);

            return Ok(userId);
        }

        [HttpPatch]
        [Route("{id}/changePassword")]
        [ActionName(nameof(ChangeUserPasswordAsync))]
        public async Task<ActionResult> ChangeUserPasswordAsync([FromRoute] string id, [FromBody] ChangeUserPasswordRequest request)
        {
            bool isSuccess = await _mediator.Send(new ChangeUserPasswordCommand(id, request.NewPassword));

            return isSuccess ? Ok() : BadRequest();
        }

        [HttpGet]
        [ActionName(nameof(GetUsersAsync))]
        public async Task<ActionResult> GetUsersAsync()
        {
            IEnumerable<User> users = await _mediator.Send(new GetUsersQuery())
            .ConfigureAwait(false);

            return Ok(users);
        }
    }
}