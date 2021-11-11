using System;

namespace RepositoryDesignPattern.Interfaces
{
    public interface ICorrelated
    {
        Guid CorrelationId {get;}
    }
}
