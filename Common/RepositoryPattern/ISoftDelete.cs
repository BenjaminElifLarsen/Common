namespace Common.RepositoryPattern;
public interface ISoftDelete
{
    bool Deleted { get; set; }
    void Delete();
}
