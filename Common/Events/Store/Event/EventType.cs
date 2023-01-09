namespace Common.Events.Store.Event;
/// <summary>
/// Indicates of the different types of events present in the store.
/// </summary>
public enum EventType
{
    /// <summary>
    /// Indicates that an entity was 'created' using this event.
    /// </summary>
    Create = 1,
    /// <summary>
    /// Indicates that one or more properties on an entity was modified.
    /// </summary>
    Modify = 2, 
    /// <summary>
    /// Indicates that an entity was removed using this event.
    /// </summary>
    Remove = 3,
    /// <summary>
    /// Indicates that an entity had the last event corrected using this event.
    /// </summary>
    Correction = 4,
    /// <summary>
    /// Should never be used, used to indicate that an enum field/property has not been sat.
    /// </summary>
    Unknown = 0,
}
