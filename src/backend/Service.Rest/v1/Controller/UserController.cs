using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.User;
using Application.Queries.User;
using Domain.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Rest.v1.Requests;

namespace Service.Rest.v1.Controller
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
        public async Task<ActionResult> CreateUserAsync([FromBody]CreateUserRequest request)
        {
            string userId = await _mediator.Send(new CreateUserCommand(request.UserName, request.Password)
            {
                Name = request.Name
            })
            .ConfigureAwait(false);

            return Ok(userId);
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