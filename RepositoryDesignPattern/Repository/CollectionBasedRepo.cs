using RepositoryDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryDesignPattern.Repository
{
    public class CollectionBasedRepo : IRepo<Book>
    {
        private readonly List<Book> _repository = new List<Book>();        
        
        public bool Add(Book item)
        {
            try
            {
                _repository.Add(item);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public Book Get(int id)
        {
            try
            {
                var result = _repository.SingleOrDefault(item => item.Id == id);
                return result;
            }
            catch (Exception)
            {
                //N/A - not available - недоступный
                return new Book(-1, "N/A", new Author(-1, "N/A", "N/A"));
            }
        }

        public IEnumerable<Book> GetAll()
        {
            try
            {
                return _repository;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Book>();
            }
        }

        public bool Remove(Book item)
        {
            try
            {
                _repository.Remove(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Book item)
        {
            try
            {
                var itemToUpdate = Get(item.Id);
                Remove(itemToUpdate);
                Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
