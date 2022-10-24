using Common.Other;

namespace Common.SpecificationPattern;
public interface IErrorConversion //when proper tested and they work, move them over to the Common project. 
{
    public abstract static IEnumerable<string> Convert(BinaryFlag binaryFlag);
}

public interface IErrorConversion<T> where T : class
{
    public abstract static IEnumerable<string> Convert(BinaryFlag binaryFlag, T entity);
}