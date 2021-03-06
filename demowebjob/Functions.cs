using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace demowebjob
{
    public class Functions
    {
        
        //public static void Run([TimerTrigger("0 * * * * *")] TimerInfo myTimer, ILogger log)
        //{

        //    log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        //    log.LogInformation("doing some job");
        //}

        public static void Run([TimerTrigger("0 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            string connString = "Server=tcp:achrafdprdemo.database.windows.net,1433;Initial Catalog=achrafdebfordapr;Persist Security Info=False;User ID=achraf;Password=KhH7Xql5;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            log.LogInformation("doing some job");

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

            Console.Read();


        }
    }

}
