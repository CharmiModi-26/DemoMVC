using CoreMVC.Models;

namespace CoreMVC.Repositories.IRepositories
{
    public interface IBookRepository
    {
        ResponseModel<List<Book>> GetBooks();
        ResponseModel<List<Book>> searchBooks(string value);
        ResponseModel<Book> GetBook(int id);
        ResponseModel<Book> addBook(Book book);
        ResponseModel<Book> updateBook(Book book);
        ResponseModel<Book> deleteBook(int id);
    }
}
