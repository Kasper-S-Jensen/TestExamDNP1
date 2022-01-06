using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AuthorBlazor.Models;

namespace AuthorBlazor.Data.Service.Impl
{
    public class AuthorServiceImpl : IAuthorService
    {
        private string path = "https://localhost:5001/api/Author";

        public async Task<IList<Author>> GetAuthorsAsync()
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"{path}");
            Console.WriteLine(responseMessage);
            if (!responseMessage.IsSuccessStatusCode)
            {
                var errResponse = await responseMessage.Content.ReadAsStringAsync();
                Console.WriteLine(errResponse);
                throw new Exception(errResponse);
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(result);
            var authors = JsonSerializer.Deserialize<List<Author>>(result,
                new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});

            return authors;
        }

        public async Task AddAuthorAsync(Author author)
        {
            using HttpClient client = new HttpClient();
            string authorasJSON = JsonSerializer.Serialize(author);
            StringContent content = new StringContent(authorasJSON, Encoding.UTF8, "application/json");
            HttpResponseMessage response =
                await client.PostAsync($"{path}", content);
            if (!response.IsSuccessStatusCode)
            {
                var errResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errResponse);
                throw new Exception(errResponse);
            }
        }

        public async Task RemoveAuthorAsync(int ID)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Author> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}