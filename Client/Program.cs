using Temporalio.Client;

namespace Temporal.Client
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Running client");

            var workflowId = "book-room-" + Guid.NewGuid().ToString();

            Console.WriteLine("Hotel book workflow id: {0}", workflowId);

            // Create a client to localhost on "default" namespace
            var client = await TemporalClient.ConnectAsync(new("localhost:7233"));
            // Run workflow
            var result = await client.ExecuteWorkflowAsync<string>(
                "BookRoomWorkflow",
                Array.Empty<object>(),
                new(id: workflowId, taskQueue: "my-task-queue"));

            var shipWorkflowId = "ship-phone-" + Guid.NewGuid().ToString();
            Console.WriteLine("Shipping workflow id: {0}", shipWorkflowId);
            // Run secound workflow
            var resultFromShipping = await client.ExecuteWorkflowAsync<string>(
                "ShippingWorkflow",
                Array.Empty<object>(),
                new(id: shipWorkflowId, taskQueue: "my-task-queue"));

            Console.WriteLine("Workflow result: {0}", result);
            Console.WriteLine("Workflow result: {0}", resultFromShipping);

            Console.ReadKey();
        }
    }
}