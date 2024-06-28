using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private readonly string _apiUrl = "http://localhost:5001/api/Blog";
        public async Task Run()
        {
            await Read();
        }

        private async Task Read()
        {
            RestRequest request = new RestRequest(_apiUrl, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request); // Use ExecuteAsync instead of GetAsync to bind method from RestRequest

            if(response.IsSuccessStatusCode)
            {
                string json = response.Content!;    // doesn't require "await", RestSharp will take care of that
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
                Console.WriteLine(response.Content!);
            }
        }

        private async Task Edit(int id)
        {
            RestRequest request = new RestRequest($"{_apiUrl}/{id}", Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if(response.IsSuccessStatusCode)
            {
                string json = response.Content!;
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(json)!;
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        private async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            RestRequest request = new RestRequest(_apiUrl, Method.Post);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            RestRequest request = new RestRequest($"{_apiUrl}/{id}", Method.Put);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }

        private async Task Delete(int id)
        {
            RestRequest request = new RestRequest($"{_apiUrl}/{id}", Method.Delete);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if(response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content!);
            }
            else
            {
                Console.WriteLine(response.Content!);
            }
        }
    }
}
