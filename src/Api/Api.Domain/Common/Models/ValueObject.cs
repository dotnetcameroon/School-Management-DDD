namespace Api.Domain.Common.Models;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetEqualityComparer();

    public static bool operator ==(ValueObject self, ValueObject other)
    {
        if (self is null)
            return false;

        return self.Equals(other);
    }

    public static bool operator !=(ValueObject self, ValueObject other)
    {
        if (self is null)
            return true;

        return !self.Equals(other);
    }

    public bool Equals(ValueObject? other)
    {
        if (other is null)
            return false;

        var firstEqualityComparers = GetEqualityComparer();
        var secondEqualityComparers = other.GetEqualityComparer();

        if (firstEqualityComparers.Count() != secondEqualityComparers.Count())
            return false;

        for (int i = 0; i < firstEqualityComparers.Count(); i++)
        {
            if (! firstEqualityComparers.ElementAt(i).Equals(secondEqualityComparers.ElementAt(i)))
                return false;
        }

        return GetHashCode() == other.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        //
        // See the full list of guidelines at
        //   http://go.microsoft.com/fwlink/?LinkID=85237
        // and also the guidance for operator== at
        //   http://go.microsoft.com/fwlink/?LinkId=85238
        //
        
        if (obj is null || GetType() != obj.GetType())
        {
            return false;
        }
        
        // TODO: write your implementation of Equals() here
        return Equals((ValueObject) obj);
    }

    public override int GetHashCode()
    {
        // TODO: write your implementation of GetHashCode() here
        return GetEqualityComparer()
            .Select(e => e.GetHashCode())
            .Aggregate((curr, acc) => curr + (int)Math.Exp(acc));
    }
}
