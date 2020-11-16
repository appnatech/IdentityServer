using MediatR;

namespace core.Commands
{
    public class BaseCommand<T>:IRequest<T>
    {
    }
}