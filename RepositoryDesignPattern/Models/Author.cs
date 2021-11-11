using RepositoryDesignPattern.Interfaces;
using System;

namespace RepositoryDesignPattern.Models
{
    public class Author : IIdentifiable, ICorrelated
    {
        public Author(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; }

        public string FirstName {get;}

        public string LastName { get; }

        public Guid CorrelationId { get; private set; }

        public Author WithCorrelationId(Guid correlationId)
        {
            var author = (Author)MemberwiseClone();
            author.CorrelationId = correlationId;
            return author;
        }
    }
}
