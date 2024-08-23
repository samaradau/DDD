using DDD.Domain.ValueObjects;

namespace DDD.Domain.Entities;

public sealed class Questionnaire
{
    public ValueObjects.Version InternalVersion { get; set;}
}