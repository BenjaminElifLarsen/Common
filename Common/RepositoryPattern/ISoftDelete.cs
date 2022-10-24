namespace Common.RepositoryPattern;
public interface ISoftDelete
{
    bool Deleted { get; }
    void Delete();
}

public interface ISoftDeleteDate
{
    DateTime? DeletedFrom { get; }
    void Delete(DateTime? dateTime);
}
