namespace Api.Domain.Common.Models;

public interface IDomainEvent
{
    void Raise();
}
