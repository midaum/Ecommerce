using MediatR;
using Domain.Abstractions;

namespace Application.Abstractions;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}