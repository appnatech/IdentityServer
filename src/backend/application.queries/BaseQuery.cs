using MediatR;

namespace application.queries
{
    public class BaseQuery<T> : IRequest<T>
    {
    }
}