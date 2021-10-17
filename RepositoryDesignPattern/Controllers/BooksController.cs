using Microsoft.AspNetCore.Mvc;
using RepositoryDesignPattern.Models;
using RepositoryDesignPattern.Repository;
using System;

namespace RepositoryDesignPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IRepo<Book> _booksRepository;

        public BooksController(IRepo<Book> booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpPost]
        public IActionResult Add(Book item)
        {
            try
            {
                _booksRepository.Add(item);
                return Ok(true);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _booksRepository.Get(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("All")]
        public IActionResult GetAll()
        {
            try
            {
                var books = _booksRepository.GetAll();
                return Ok(books);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                var item = _booksRepository.Get(id);

                if(item.Id == -1)
                {
                    return Ok(false);
                }
                
                var result = _booksRepository.Remove(item);
                return Ok(result);                
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public IActionResult Update(Book item)
        {
            try
            {
                var result = _booksRepository.Update(item);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
