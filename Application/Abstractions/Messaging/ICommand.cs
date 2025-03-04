﻿using MediatR;
using Domain.Abstractions;

namespace Application.Abstractions;
public interface ICommand : IRequest<Result>, IBaseCommand
{
}
public interface ICommand<TReponse> : IRequest<Result<TReponse>>, IBaseCommand
{
}
public interface IBaseCommand
{
}