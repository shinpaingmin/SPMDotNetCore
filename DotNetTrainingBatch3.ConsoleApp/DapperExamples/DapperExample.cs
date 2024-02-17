using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DotNetTrainingBatch3.ConsoleApp.Models;
using System.Reflection.Metadata;

namespace DotNetTrainingBatch3.ConsoleApp.DapperExamples
{
    internal class DapperExample
    {
        // global variable
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "TestDb",
            UserID = "sa",
            Password = ""
        };
        public void Read()
        {
            

            string query = "SELECT [BlogId], [BlogTitle], [BlogAuthor], [BlogContent] FROM [dbo].[tbl_blog]";


            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();  // Query is from dapper package

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

            string query = @"SELECT [BlogId], [BlogTitle], [BlogAuthor], [BlogContent] FROM [dbo].[tbl_blog]
                                WHERE BlogId = @BlogId";    // To prevent SQL injection

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            // var item = db.Query<BlogModel>(query, new { BlogId = id }).FirstOrDefault(); // tricky

            var item = db.Query<BlogModel>(query, blog).FirstOrDefault();

            if (item is null)
            {
                Console.WriteLine("No data found");
                return;
            }


            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);

        }

        public void Create(string title, string author, string content)
        {

            string query = @"INSERT INTO [dbo].[tbl_blog]
                            ([BlogTitle], [BlogAuthor], [BlogContent])
                            VALUES
                            (@BlogTitle, @BlogAuthor, @BlogContent)";

            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Created Successfully" : "Failed to create a new record";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            

            string query = @"UPDATE [dbo].[tbl_blog]
                            SET [BlogTitle] = @BlogTitle, 
                                [BlogAuthor] = @BlogAuthor,
                                [BlogContent] = @BlogContent
                            WHERE [BlogId] = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id,
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Updated Successfully" : "Failed to update the existing record";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {           

            string query = @"DELETE FROM [dbo].[tbl_blog] WHERE BlogId = @BlogId";

            BlogModel blog = new BlogModel()
            {
                BlogId = id   
            };

            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "Deleted Successfully" : "Failed to delete the record";
            Console.WriteLine(message);
        }
    }
}
