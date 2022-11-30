namespace Common.SpecificationPattern;
public interface IErrorConversion
{
    public abstract static IEnumerable<string> Convert(BinaryFlag binaryFlag);
}

public interface IErrorConversion<T> where T : class
{
    public abstract static IEnumerable<string> Convert(BinaryFlag binaryFlag, T entity);
}