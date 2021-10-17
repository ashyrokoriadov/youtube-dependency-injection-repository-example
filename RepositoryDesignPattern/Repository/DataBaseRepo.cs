using RepositoryDesignPattern.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace RepositoryDesignPattern.Repository
{
    public class DataBaseRepo : IRepo<Book>
    {
        //заменить на данные для Вашей базы данных
        private readonly string connectionString = @"Server= ANDREY-LAPTOP\SQLEXPRESS; " +
                "Database= RandomTestData; " +
                "Integrated Security=True;";
        
        public bool Add(Book item)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            var result = new Book(-1, "N/A", new Author(-1, "N/A", "N/A"));
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "SELECT TOP 1 A.Id AS 'AuthorId', A.FirstName AS 'AuthorFirstName', " +
                        "A.LastName AS 'AuthorLastName', B.Id AS 'BookId', B.Name AS 'BookName' " +
                        "FROM dbo.TEST_AUTHORS A JOIN TEST_BOOKS B ON A.Id = B.AuthorId WHERE B.Id = @Id;";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Id", id));

                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                var author = new Author(
                                    id: int.Parse(reader["AuthorId"].ToString()),
                                    firstName: reader["AuthorFirstName"].ToString(),
                                    lastName: reader["AuthorLastName"].ToString()
                                    );

                                result = new Book(
                                    id: int.Parse(reader["BookId"].ToString()),
                                    name: reader["BookName"].ToString(),
                                    author: author
                                    );
                            }
                        }
                    }
                    connection.Close();
                }

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
            var result = new List<Book>();
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    var query = "SELECT A.Id AS 'AuthorId', A.FirstName AS 'AuthorFirstName', " +
                        "A.LastName AS 'AuthorLastName', B.Id AS 'BookId', B.Name AS 'BookName' " +
                        "FROM dbo.TEST_AUTHORS A JOIN TEST_BOOKS B ON A.Id = B.AuthorId;";

                    using (var command = new SqlCommand(query, connection))
                    {                        
                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                var author = new Author(
                                    id: int.Parse(reader["AuthorId"].ToString()),
                                    firstName: reader["AuthorFirstName"].ToString(),
                                    lastName: reader["AuthorLastName"].ToString()
                                    );

                                var book = new Book(
                                    id: int.Parse(reader["BookId"].ToString()),
                                    name: reader["BookName"].ToString(),
                                    author: author
                                    );

                                result.Add(book);
                            }
                        }
                    }
                    connection.Close();
                }

                return result;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Book>();
            }
        }

        public bool Remove(Book item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Book item)
        {
            throw new NotImplementedException();
        }
    }
}
