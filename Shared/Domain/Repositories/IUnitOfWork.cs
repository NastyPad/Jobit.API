namespace Jobit.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}