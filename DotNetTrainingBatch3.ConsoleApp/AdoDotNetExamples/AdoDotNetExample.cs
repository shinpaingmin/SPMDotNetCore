using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DotNetTrainingBatch3.ConsoleApp.AddDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "";

            string query = "SELECT [BlogId], [BlogTitle], [BlogAuthor], [BlogContent] FROM [dbo].[tbl_blog]";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            // data set
            // data table
            // data row
            // data column
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine("Blog ID: " + dr["BlogId"]);
                Console.WriteLine("Blog Title " + dr["BlogTitle"]);
                Console.WriteLine("Blog Author " + dr["BlogAuthor"]);
                Console.WriteLine("Blog Content " + dr["BlogContent"]);
            }
        }

        public void Edit(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "";

            string query = @"SELECT [BlogId], [BlogTitle], [BlogAuthor], [BlogContent] FROM [dbo].[tbl_blog]
                                WHERE BlogId = @BlogId";    // To prevent SQL injection
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow dr = dt.Rows[0];

            
            Console.WriteLine("Blog ID: " + dr["BlogId"]);
            Console.WriteLine("Blog Title " + dr["BlogTitle"]);
            Console.WriteLine("Blog Author " + dr["BlogAuthor"]);
            Console.WriteLine("Blog Content " + dr["BlogContent"]);
            
        }

        public void Create(string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "";

            string query = @"INSERT INTO [dbo].[tbl_blog]
                            ([BlogTitle], [BlogAuthor], [BlogContent])
                            VALUES
                            (@BlogTitle, @BlogAuthor, @BlogContent)";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Created Successfully" : "Failed to create a new record";
            Console.WriteLine (message);
        }

        public void Update(int id, string title, string author, string content)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "";

            string query = @"UPDATE [dbo].[tbl_blog]
                            SET [BlogTitle] = @BlogTitle, 
                                [BlogAuthor] = @BlogAuthor,
                                [BlogContent] = @BlogContent
                            WHERE [BlogId] = @BlogId";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Updated Successfully" : "Failed to update the existing record";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "TestDb";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "";

            string query = @"DELETE FROM [dbo].[tbl_blog] WHERE BlogId = @BlogId";
            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@BlogId", id);
           
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            string message = result > 0 ? "Deleted Successfully" : "Failed to delete the record";
            Console.WriteLine(message);
        }
    }
}
