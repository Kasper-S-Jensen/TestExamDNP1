using System.Collections.Generic;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data.Service
{
    public interface IAuthorService
    {
        Task<IList<Author>> GetAuthorAsync();
        Task AddAuthorAsync(Author author);
        Task RemoveAuthorAsync(int ID);
        Task<Author> UpdateAsync(Author author);
        Task<Author> GetAsync(int id);

    }
}