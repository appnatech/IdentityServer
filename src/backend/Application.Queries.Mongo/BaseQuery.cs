using MediatR;

namespace Application.Queries
{
    public class BaseQuery<T> : IRequest<T>
    {
    }
}