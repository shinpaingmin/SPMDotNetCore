﻿using DotNetTrainingBatch3.ConsoleApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IBlogApi refitApi = RestService.For<IBlogApi>("http://localhost:5001");
        public async Task Run()
        {
            await Read();
            //await Edit(2);
            //await Create("sherlock", "author1", "Sherlock Holmes");
        }

        private async Task Read()
        {
            List<BlogModel> lst = await refitApi.GetBlogs();

            foreach(BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        private async Task Edit(int id)
        {
            try
            {
                BlogModel item = await refitApi.GetBlog(id);
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Create(string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = title,
                };

                string message = await refitApi.CreateBlog(blog);
                Console.WriteLine(message);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private async Task Update(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    BlogTitle = title,
                    BlogAuthor = author,
                    BlogContent = content
                };

                string message = await refitApi.UpdateBlog(id, blog);
                Console.WriteLine(message);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);  
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }
        }

        private async Task Delete(int id)
        {
            try
            {
                string message = await refitApi.DeleteBlog(id);
                Console.WriteLine(message);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
