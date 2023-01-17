using Common.ProcessManager;

namespace Common.RepositoryPattern.ProcessManagers;
public interface IBaseProcessManagerRepository<TProcessManager> where TProcessManager : IBaseProcessManager
{
    public Task<TProcessManager> LoadAsync(Guid correlationId);
    public void Save(TProcessManager processManager);
    public void Delete(Guid correlationId); //should it be possible to delete a pm? If yes, when?
}
