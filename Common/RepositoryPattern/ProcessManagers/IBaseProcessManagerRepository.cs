using Common.Events.Store.ProcessManager;

namespace Common.RepositoryPattern.ProcessManagers;
public interface IBaseProcessManagerRepository<TProcessManager> where TProcessManager : BaseProcessManager
{
    public TProcessManager Load(Guid correlationId);
    public void Add(TProcessManager processManager);
    public void Update(TProcessManager processManager);
    public void Delete(Guid correlationId); //should it be possible to delete a pm? If yes, when?
}
