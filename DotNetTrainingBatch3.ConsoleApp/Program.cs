// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
//F5 => Run 
// Shift+F5 => Stop
// Ctrl + K, C => comment
// Ctrl + K, U => uncomment
//Console.ReadKey();
//Console.ReadLine();
//NuGet = npm 

// Ctrl + .
// F9 => Break point
#region Read
SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "TestDb";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sasa@123";

string query = "select * from tbl_blog";
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
foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine(dr["BlogId"]);
    Console.WriteLine(dr["BlogTitle"]);
    Console.WriteLine(dr["BlogAuthor"]);
    Console.WriteLine(dr["BlogContent"]);
}
#endregion