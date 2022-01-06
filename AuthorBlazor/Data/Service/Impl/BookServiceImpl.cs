using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data.Service.Impl
{
    public class BookServiceImpl : IBookService
    {
        
        private string path = "https://localhost:5001/api/Book";
        
        public async Task<IList<Book>> GetBooksAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{path}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                var errResponse = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(errResponse);
                throw new Exception(errResponse);
                
            }
            string result = await responseMessage.Content.ReadAsStringAsync();

            List<Book> books = JsonSerializer.Deserialize<List<Book>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return books;
        }

        public async Task AddBookAsync(Book book, int AuthorID)
        {
            using HttpClient client = new HttpClient();
            string bookAsJSON = JsonSerializer.Serialize(book);
            StringContent content = new StringContent(bookAsJSON, Encoding.UTF8, "application/json");
            HttpResponseMessage response =
                await client.PostAsync($"{path}/{AuthorID}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errResponse);
                throw new Exception(errResponse);
                
            }
        }

        public async Task RemoveBookAsync(int bookISBN)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync($"{path}/{bookISBN}");
            if (!response.IsSuccessStatusCode)
            {
                var errResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errResponse);
                throw new Exception(errResponse);
                
            }
        }

        public Task<Book> UpdateAsync(Book book)
        {
            throw new System.NotImplementedException();
        }

        public Task<Book> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}