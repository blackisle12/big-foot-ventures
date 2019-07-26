using Amazon.Lambda.Core;
using System;
using System.Net.Http;
using System.Threading.Tasks;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BigFootVentures.Job.Notification.Trademark
{
    public class Function
    {
        #region "Public Methods"

        public async Task FunctionHandler(string input, ILambdaContext context)
        {
            Console.WriteLine("Starting Notification_Trademark function..");

            await this.ConnectToNotificationTrademarkProofOfUse();

            await this.ConnectToNotificationTrademarkSixMonthsAnniversary();

            Console.WriteLine("Finishing Notification_Trademark function..");
        }

        #endregion

        #region "Private Methods"

        private async Task ConnectToNotificationTrademarkProofOfUse()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = "http://trademarkers.us-east-2.elasticbeanstalk.com/Notification/TrademarkGetProofOfUse?username=sa&password=FxWaWJ3csC58k";

                    Console.WriteLine("Connecting to Notification Trademark Proof of Use..");
                    Console.WriteLine("URI: " + uri);

                    var response = await client.GetAsync(uri);

                    Console.WriteLine("Status Code: " + response.StatusCode);
                    Console.WriteLine("Content: " + await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error encountered:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        private async Task ConnectToNotificationTrademarkSixMonthsAnniversary()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var uri = "http://trademarkers.us-east-2.elasticbeanstalk.com/Notification/TrademarkGetSixMonthsAnniversary?username=sa&password=FxWaWJ3csC58k";

                    Console.WriteLine("Connecting to Notification Trademark Six Months Anniversary..");
                    Console.WriteLine("URI: " + uri);

                    var response = await client.GetAsync(uri);

                    Console.WriteLine("Status Code: " + response.StatusCode);
                    Console.WriteLine("Content: " + await response.Content.ReadAsStringAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error encountered:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }

        #endregion
    }
}
