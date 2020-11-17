using MediatR;

namespace application.commands
{
    public class BaseCommand<T>:IRequest<T>
    {
    }
}