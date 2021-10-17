﻿using RepositoryDesignPattern.Interfaces;

namespace RepositoryDesignPattern.Models
{
    public class Author : IIdentifiable
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
    }
}
