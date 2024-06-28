// See https://aka.ms/new-console-template for more information
using DotNetTrainingBatch3.ConsoleApp.AddDotNetExamples;
using DotNetTrainingBatch3.ConsoleApp.DapperExamples;
using DotNetTrainingBatch3.ConsoleApp.EfCoreExamples;
using DotNetTrainingBatch3.ConsoleApp.HttpClientExamples;
using DotNetTrainingBatch3.ConsoleApp.Models;
using DotNetTrainingBatch3.ConsoleApp.RestClientExamples;
using Newtonsoft.Json;


//F5 => Run 
// Shift+F5 => Stop
// Ctrl + K, C => comment
// Ctrl + K, U => uncomment
//Console.ReadKey();
//Console.ReadLine();
//NuGet = npm 

// Ctrl + .
// F9 => Break point


//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(13);
//adoDotNetExample.Create("Hello Japan", "Shin Paing Min", "Welcome to Japan!");
//adoDotNetExample.Update(2, "Test 2", "shin", "hehe haha!");
//adoDotNetExample.Delete(1);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(2);
//dapperExample.Create("abc", "ABC", "dslfjslfkj");
//dapperExample.Update(12, "abc", "ABC", "English alphabets");
//dapperExample.Delete(11);

//EfCoreExample efCoreExample = new EfCoreExample();
//efCoreExample.Read();
//efCoreExample.Create("slkdfj", "dsklfjsd", "kdjsfkl");
//efCoreExample.Update(11, "slkdfj", "dsklfjsd", "kdjsfkl");
//efCoreExample.Delete(4);

//Console.WriteLine("Waiting for APi");
//Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

//BlogModel blog = new BlogModel();
//blog.BlogTitle = "Title";
//blog.BlogAuthor = "Author";
//blog.BlogContent = "Content";

// SerializeObject -> C# obj - JSON 
//string json = JsonConvert.SerializeObject(blog);
//BlogModel blog2 = JsonConvert.DeserializeObject<BlogModel>(json)!;
//Console.WriteLine(blog2.BlogTitle);

Console.WriteLine("Waiting for API...");
Console.ReadKey();

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Run();

RestClientExample restClientExample = new RestClientExample();
await restClientExample.Run();