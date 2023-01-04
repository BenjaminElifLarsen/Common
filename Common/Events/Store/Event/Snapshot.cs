namespace Common.Events.Store.Event;
public class Snapshot
{ //consider making an interface with the properties, but a generic aggregateId. Same for event and aggregate model
    public int AggregateId { get; private set; }
    public string SerialisedData { get; private set; }
    public int Version { get; private set; }
}

/*
 * Idea: If wanting to ensure any stored snapshot is compatiable with their aggregate root model, even if properties/fields are renamed, could use switch cases like the Avro Kafka does.
 *  Two switch cases: 
 *   1) Switch on an int and gets an object out from a property/field.
 *   2) Switch on the same int as 1, but writes the object to the property/field.
 *  So something like this:
 *   https://github.com/BenjaminElifLarsen/Kafka-school-experiment/blob/master/consumer/Kafka-Consumer/Kafka-Consumer/House.cs
 *   https://github.com/BenjaminElifLarsen/Kafka-school-experiment/blob/master/consumer/Kafka-Consumer/Kafka-Consumer/House.avsc
 *   The type and doc parts of the schema should not be needed for own version. The data would of course be stored as a JSON file 
 *  This would mean that the domain models would need to be valid even if restored to an much old version (so any newer fields should be nullable).
 * Idea Extended:
 *  We got:
 *   Name: class/record name.
 *   NameSpace: The namespace of the class/record.
 *  Thus it is possible to use Activator, if willing to use reflection, to create an instance of the needed class without having massive switch cases when it comes to deserialise SerialisedData into an start/creation 'Event' 
 *   So a single class that converts snapshots into 'event's that can be used for hydration. Mayhaps a similar system could be in place for all stored Events. 
 */