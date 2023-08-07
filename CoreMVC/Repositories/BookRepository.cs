using CoreMVC.Models;
using CoreMVC.Repositories.IRepositories;
using System.Collections;

namespace CoreMVC.Repositories
{
    public class BookRepository : IBookRepository
    {
        private static List<Book> books = new List<Book>();

        public BookRepository()
        {
            if (books.Count == 0)
            {
                books = new List<Book>();
                books.Add(new Book() { Id = 1, Title = "MVC", Author = "Tim" });
                books.Add(new Book() { Id = 2, Title = "dotNet Core", Author = "Nitish" });
                books.Add(new Book() { Id = 3, Title = "Console", Author = "Dhaval" });
                books.Add(new Book() { Id = 4, Title = "Web API", Author = "Chirag" });
                books.Add(new Book() { Id = 5, Title = "dotNet Framework", Author = "Pankaj" });
            }
        }

        public ResponseModel<Book> addBook(Book book)
        {
            ResponseModel<Book> res = new ResponseModel<Book>();
            try
            {
                if (!books.Exists(x => x.Id == book.Id || (x.Title == book.Title && x.Author == book.Author)))
                {
                    books.Add(book);
                    res.status = true;
                    res.data = books.Where(x => x.Title == book.Title && x.Author == book.Author).FirstOrDefault();
                }
                else
                {
                    res.status = false;
                    res.message = "Book already exists";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
            }
            return res;
        }

        public ResponseModel<Book> deleteBook(int id)
        {
            ResponseModel<Book> res = new ResponseModel<Book>();
            try
            {
                if (books.Exists(x => x.Id == id))
                {
                    Book existingBook = books.Where(x => x.Id == id).FirstOrDefault();
                    if (books.Remove(existingBook))
                    {
                        res.status = true;
                        res.data = existingBook;
                    }
                    else
                    {
                        res.status = false;
                        res.message = "Something went wrong..! Book is not deleted";
                    }
                }
                else
                {
                    res.status = false;
                    res.message = "No Book found";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
            }
            return res;
        }

        public ResponseModel<Book> GetBook(int id)
        {
            ResponseModel<Book> res = new ResponseModel<Book>();
            try
            {
                if (books.Exists(x => x.Id == id))
                {
                    res.status = true;
                    res.data = books.Where(x => x.Id == id).FirstOrDefault();
                }
                else
                {
                    res.status = false;
                    res.message = "Book not found";
                }
            }
            catch (Exception e)
            {
                res.status = false;
                res.message = e.Message;
            }
            return res;
        }

        public ResponseModel<List<Book>> GetBooks()
        {
            ResponseModel<List<Book>> res = new ResponseModel<List<Book>>();
            try
            {
                res.status = true;
                res.data = books;
            }
            catch (Exception e)
            {
                res.status = false;
                res.message = e.Message;
            }
            return res;
        }

        public ResponseModel<List<Book>> searchBooks(string value)
        {
            ResponseModel<List<Book>> res = new ResponseModel<List<Book>>();
            try
            {
                if (books.Exists(x => x.Title.ToLower().Contains(value.ToLower()) || x.Author.ToLower().Contains(value.ToLower()))) {
                    res.status = true;
                    res.data = books.Where(x => x.Title.ToLower().Contains(value.ToLower()) || x.Author.ToLower().Contains(value.ToLower())).ToList();
                }
                else
                {
                    res.status = false;
                    res.message = "No book found";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
            }
            return res;
        }

        public ResponseModel<Book> updateBook(Book book)
        {
            ResponseModel<Book> res = new ResponseModel<Book>();
            try
            {
                if (books.Exists(x => x.Id == book.Id))
                {
                    Book existingbook = books.Where(x => x.Id == book.Id).FirstOrDefault();
                    existingbook.Title = book.Title;
                    existingbook.Author = book.Author;
                    res.status = true;
                    res.data = book;
                }
                else
                {
                    res.status = false;
                    res.message = "Book not found";
                }
            }
            catch (Exception ex)
            {
                res.status = false;
                res.message = ex.Message;
            }
            return res;
        }
    }
}
