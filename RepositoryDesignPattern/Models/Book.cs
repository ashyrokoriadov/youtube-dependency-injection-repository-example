using RepositoryDesignPattern.Interfaces;
using System;

namespace RepositoryDesignPattern.Models
{
    public class Book : IIdentifiable, ICorrelated
    {
        public Book(int id, string name, Author author)
        {
            Id = id;
            Name = name;
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        public int Id { get; }

        public string Name { get; }

        public Author Author { get; }

        public Guid CorrelationId { get; private set; }

        public Book WithCorrelationId(Guid correlationId)
        {
            var author = Author.WithCorrelationId(correlationId);
            var book = new Book(Id, Name, author);            
            book.CorrelationId = correlationId;
            return book;
        }
    }
}
