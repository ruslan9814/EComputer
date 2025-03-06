﻿using Infrasctructure.Repositories.Interfaces;
using Infrasctructure.UnitOfWork;

namespace Application.Users.Commands;

public sealed record ConfirmEmailCommand(string Token)
    : IRequest<Result>;

public sealed record ConfirmEmailCommandHandler(
    IUserRepository UserRepository,
    IUnitOfWork UnitOfWork)
    : IRequestHandler<ConfirmEmailCommand, Result>
{
    public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await UserRepository.GetUserByConfirmationTokenAsync(request.Token);

        if (user is null)
        {
            return Result.Failure("Неверный токен подтверждения");
        }

        var confirmEmailResult = user.ConfirmEmail();

        if (confirmEmailResult.IsFailure)
        {
            return confirmEmailResult;
        }

        await UserRepository.UpdateAsync(user);
        await UnitOfWork.Commit();

        return Result.Success();
    }
}
