namespace Common.RepositoryPattern;
/// <summary>
/// Used to prevent accessing one aggregate root via another aggregate.
/// </summary>
/// <typeparam name="T"></typeparam>
public record IdReference<T> : ValueObject where T : struct
{
    public T Id { get; private set; }

	public IdReference(T id)
	{
		Id = id;
	}

    public static implicit operator IdReference<T>(T id) => new(id);
    public static implicit operator T(IdReference<T> idReference) => idReference.Id;
    public static bool operator ==(IdReference<T> left, T right) => left.Equals(right);
    public static bool operator !=(IdReference<T> left, T right) => !left.Equals(right);

    public virtual bool Equals(IdReference<T>? other)
    {
        if (other is null) return false;
        return Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
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

    public static implicit operator IdReference(Guid id) => new(id);
    public static implicit operator Guid(IdReference idReference) => idReference.Id;
    public static bool operator ==(IdReference left, Guid right) => left.Equals(right);
    public static bool operator !=(IdReference left, Guid right) => !left.Equals(right);

    public virtual bool Equals(IdReference? other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}