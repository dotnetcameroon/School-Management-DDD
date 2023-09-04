namespace Api.Domain.Common.Models;

public abstract class Entity<TId>
{
    public TId Id { get; protected set; }
    public Entity(TId id)
    {
        Id = id;
    }

    public static bool operator ==(Entity<TId> self, Entity<TId> other)
    {
        if (self is null)
            return false;

        return self.Equals(other);
    }

    public static bool operator !=(Entity<TId> self, Entity<TId> other)
    {
        if (self is null)
            return true;

        return !self.Equals(other);
    }

    public bool Equals(Entity<TId>? other)
    {
        if (other is null)
            return false;

        return Id!.Equals(other.Id) &&
            GetHashCode() == other.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null || GetType() != obj.GetType())
        {
            return false;
        }
        return Equals((Entity<TId>)obj);
    }

    public override int GetHashCode()
    {
        return Id!.GetHashCode();
    }
}
