using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;

namespace test
{
    class Program
    {
        private ILogger log;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string connString = "Server=tcp:achrafdprdemo.database.windows.net,1433;Initial Catalog=achrafdebfordapr;Persist Security Info=False;User ID=achraf;Password=KhH7Xql5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            //log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            //log.LogInformation("doing some job");
            Console.WriteLine($"C# Timer trigger function executed at: {DateTime.Now}");

            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Openning Connection ...");

                //open connection
                conn.Open();


                string insert = "INSERT INTO datacheck (myname ,checktime) VALUES (@name,@time)";
                string name = "demo at";
                string time = System.DateTime.Now.ToString();
                using (SqlConnection connection = new SqlConnection(connString))
                {

                    connection.Open();
                    using (SqlCommand command = new SqlCommand(insert, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@time", time);
                        command.ExecuteNonQuery();
                        command.Dispose();

                    }
                    conn.Close();
                }

                Console.WriteLine($"C# Timer trigger function end executed at: {DateTime.Now}");






                //SqlCommand command;
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //String sql = "";
                //string name = "demo at";
                //string time = System.DateTime.Now.ToString();
                //sql.= "insert into datacheck values(@name,@time)";
                //sql.AddWithValue("@name", name);

                //command = new SqlCommand(sql, conn);

                //adapter.InsertCommand = new SqlCommand(sql, conn);
                //adapter.InsertCommand.ExecuteNonQuery();





                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

           
            Console.WriteLine("All Records inserted Successfully");

            // Console.Read();

            // wait 2 seconds before closing Console Application
            System.Threading.Thread.Sleep(2000);


        }
    }
}
