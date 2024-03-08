using DotNetTrainingBatch3.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp.EfCoreExamples
{
    public class EfCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();

            foreach(BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            //BlogModel blog = db.Blogs.Where(item => item.BlogId == id).FirstOrDefault();
            BlogModel blog = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;

            if(blog is null)
            {
                Console.WriteLine("No blog found");
                return;
            }

            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogAuthor);
            Console.WriteLine(blog.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();   //execute query here

            string message = result > 0 ? "Saved successfully" : "Denied";

            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            AppDbContext db = new AppDbContext();
            BlogModel blog = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;

            if(blog is null)
            {
                Console.WriteLine("No data found");
                return;
            };

            blog.BlogTitle = title;
            blog.BlogAuthor = author;
            blog.BlogContent = content;
            int result = db.SaveChanges();

            string message = result > 0 ? "Updated successfully" : "denied";

            Console.WriteLine(message);
        }

        public void Delete(int id) 
        {
            AppDbContext db = new AppDbContext();
            BlogModel blog = db.Blogs.FirstOrDefault(item => item.BlogId == id)!;

            if (blog is null)
            {
                Console.WriteLine("No data found");
                return;
            };

            db.Blogs.Remove(blog);
            int result = db.SaveChanges();

            string message = result > 0 ? "Deleted successfully" : "denied";

            Console.WriteLine(message);
        }
    }
}
