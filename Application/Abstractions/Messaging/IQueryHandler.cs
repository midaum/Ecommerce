﻿using MediatR;
using Domain.Abstractions;

namespace Application.Abstractions;
public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}