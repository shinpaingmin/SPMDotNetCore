using DotNetTrainingBatch3.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample2
    {
        public async Task Run()
        {
            await ReadJsonPlaceholder();
        }

        private async Task Read()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://localhost:5001/api/Blog");

            if(response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(jsonStr);

                // JsonConvert.SerializeObject(...); // C# object to JSON
                // JsonConvert.DeserializeObject(...); // JSON to C# object

                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!; // ! = cannot be null

                foreach(BlogModel item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        private async Task ReadJsonPlaceholder()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
         

                // JsonConvert.SerializeObject(...); // C# object to JSON
                // JsonConvert.DeserializeObject(...); // JSON to C# object

                List<JsonPostModel> lst = JsonConvert.DeserializeObject<List<JsonPostModel>>(jsonStr)!; // ! = cannot be null

                foreach (JsonPostModel item in lst)
                {
                    Console.WriteLine(item.userId);
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                }
            }
        }
    }
}
