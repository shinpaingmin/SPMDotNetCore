using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(100);
            //await Create("title123", "author", "content");\
            await Delete(1);
        }

        private async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/api/Blog");

            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(json)!;

                foreach(BlogModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"http://localhost:5001/api/Blog/{id}");

            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(json)!;

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);

            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Create(string title, string author, string content)
        {

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            string jsonBlog = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, "application/json");   // StringContent inheritance from HttpContent

            string url = "http://localhost:5001/api/Blog";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url, httpContent);

            if(response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content,
            };

            string jsonBlog = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, "application/json");   // StringContent inheritance from HttpContent

            string url = $"http://localhost:5001/api/Blog/{id}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url, httpContent);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private async Task Delete(int id)
        {
            string url = $"http://localhost:5001/api/Blog/{id}";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
