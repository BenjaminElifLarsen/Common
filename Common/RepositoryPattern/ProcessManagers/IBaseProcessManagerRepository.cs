using Common.Events.Store.ProcessManager;

namespace Common.RepositoryPattern.ProcessManagers;
public interface IBaseProcessManagerRepository<TProcessManager> where TProcessManager : BaseProcessManager
{
    public Task<TProcessManager> LoadAsync(Guid correlationId);
    public void Save(TProcessManager processManager);
    public void Delete(Guid correlationId); //should it be possible to delete a pm? If yes, when?
}
