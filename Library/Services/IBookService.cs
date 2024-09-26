using Library.Dto;
using Library.Model;

namespace Library.Services
{
    public interface IBookService
    {
     public  Task<string> CreateBook(Book book);

     public  Task<List<Book>> GetBooks();

     public  Task<Book> GetOneBook(Guid id);


     public  Task<string> updateBook(Book book);

     public  Task<string>  DeleteBook(Book book);
    }
}
