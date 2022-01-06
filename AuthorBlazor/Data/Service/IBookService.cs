using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data.Service
{
    public interface IBookService
    {
        Task<IList<Book>> GetBooksAsync();
        Task AddBookAsync(Book book, int AuthorID);
        Task RemoveBookAsync(int bookISBN);
        Task<Book> UpdateAsync(Book book);
        Task<Book> GetAsync(int id);
        
    }
}