using Api.Domain.Common.Models;

namespace Api.Domain.AcademicAggregate.ValueObjects;

public class NotationId : ValueObject
{
	public Guid Value { get; }
	private NotationId(Guid value)
	{
		Value = value;
	}

	public static NotationId CreateUnique()
	{
		return new(Guid.NewGuid());
	}

	public static NotationId Create(string value)
	{
		return new(Guid.Parse(value));
	}

    public override IEnumerable<object> GetEqualityComparer()
    {
		yield return Value;
    }
}
