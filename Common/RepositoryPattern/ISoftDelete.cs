namespace Common.RepositoryPattern;
public interface ISoftDelete
{
    bool Deleted { get; }
    void Delete();
}

public interface ISoftDeleteDate
{
    DateOnly? DeletedFrom { get; }
    void Delete(DateOnly? dateTime);
}
