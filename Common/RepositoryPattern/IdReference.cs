namespace Common.RepositoryPattern;
/// <summary>
/// Used to prevent accessing one aggregate root via another aggregate.
/// </summary>
/// <typeparam name="T"></typeparam>
public record IdReference<T> : ValueObject
{
    public T Id { get; private set; }

	public IdReference(T id)
	{
		Id = id;
	}
}

/// <summary>
/// Used to prevent accessing one aggregate root via another aggregate.
/// </summary>
public record IdReference : IdReference<Guid>
{
    public IdReference(Guid id) : base(id)
    {
    }
}