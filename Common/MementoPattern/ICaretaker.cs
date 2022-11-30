namespace Common.MementoPattern;
public interface ICaretaker<TEntity, TMemento> where TEntity : IOriginator<TMemento> where TMemento : IMemento
{ //figure out if this should have specific methods
    //also have a generalised caretaker or one for each aggregate/aggregate-root? 
    //IEnumerable<IMemento> GetMementoes(IAggregateRoot root);
    void Save();
    /// <summary>
    /// Restore to the latest memento.
    /// </summary>
    /// <param name="root"></param>
    void Restore();
}
//https://refactoring.guru/design-patterns/memento
//an instance of the caretaker should only handle a single aggregate root instance