namespace Common.SpecificationPattern;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T candidate);
}
