using MediatR;

namespace Application.Commands
{
    public class BaseCommand<T> : IRequest<T>
    {
    }
}