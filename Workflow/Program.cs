using Temporalio.Client;
using Temporalio.Worker;

namespace Test
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // Create a client to localhost on "default" namespace
            var client = await TemporalClient.ConnectAsync(new("localhost:7233"));

            // Cancellation token to shutdown worker on ctrl+c
            using var tokenSource = new CancellationTokenSource();
            Console.CancelKeyPress += (_, eventArgs) =>
            {
                tokenSource.Cancel();
                eventArgs.Cancel = true;
            };

            // Run worker until cancelled
            Console.WriteLine("Running worker");
            using var worker = new TemporalWorker(
                client,
                new TemporalWorkerOptions("my-task-queue").
                    AddActivity(BookRoomActivities.BookHotelRoom).
                    AddActivity(BookRoomActivities.BookHotelTicket).
                    AddActivity(BookRoomActivities.MakeHotelPayment).
                    AddActivity(ShippingActivities.StartShipping).
                    AddWorkflow<BookRoomWorkflow>().
                    AddWorkflow<ShippingWorkflow>());
            try
            {
                await worker.ExecuteAsync(tokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Worker cancelled");
            }
        }
    }
}