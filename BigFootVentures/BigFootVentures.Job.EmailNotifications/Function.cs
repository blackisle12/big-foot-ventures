using Amazon.Lambda.Core;
using MySql.Data.MySqlClient;
using System;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BigFootVentures.Job.EmailNotifications
{
    public class Function
    {
        public void FunctionHandler()
        {
            using (var connection = new MySqlConnection(Environment.GetEnvironmentVariable("DBConnectionString")))
            {
                connection.Open();
            }
        }
    }
}
