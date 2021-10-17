using RepositoryDesignPattern.Interfaces;
using System;

namespace RepositoryDesignPattern.Models
{
    public class Book : IIdentifiable
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
    }
}
