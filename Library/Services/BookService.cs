using Library.Data;
using Library.Dto;
using Library.Model;

namespace Library.Services
{
    public class BookService : IBookService
    {
        //context

        private readonly LibraryDbContext _dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
 
        public async Task<string> CreateBook(Book book)
        {
            try
            {
                await _dbContext.Books.AddAsync(book);
                _dbContext.SaveChanges();
                return "success";

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return $"Something went wrong {ex.InnerException}";
            }
        }

        public async Task <string> DeleteBook(Book book)
        {
           _dbContext.Books.Remove(book);
               _dbContext.SaveChanges();
            return "success";
        }

        public async Task<List<Book>> GetBooks()
        {
       
               List <Book> books =  _dbContext.Books.ToList();
                return books;
        }

        public async Task<Book> GetOneBook(Guid id)
        {
           Book book = await  _dbContext.Books.FindAsync(id);
            if(book != null)
            {
                return book;
            }
            return book;
        }

        public async Task<string> updateBook(Book book)
        {
            try
            {
               _dbContext.Books.Update(book);
              await   _dbContext.SaveChangesAsync();
                return "updated successfully";
            }catch(Exception ex)
            {
                return ($"something went very wrong {ex.InnerException}");
            }
        }
    }
}
