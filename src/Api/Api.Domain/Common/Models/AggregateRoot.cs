namespace Api.Domain.Common.Models;

public abstract class AggregateRoot<TId> : Entity<TId>
{
	private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

	public AggregateRoot(TId id) : base(id)
	{
	}
}
