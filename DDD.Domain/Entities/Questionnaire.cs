namespace DDD.Domain.Entities;

public sealed class Questionnaire(ValueObjects.Version internalVersion)
{
    public ValueObjects.Version InternalVersion => internalVersion;
}