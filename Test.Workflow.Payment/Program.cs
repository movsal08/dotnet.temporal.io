﻿using Temporalio.Client;
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

            // Create an activity instance since we have instance activities. If we had
            // all static activities, we could just reference those directly.
            var activities = new MyActivities();

            // Create worker with the activity and workflow registered
            using var worker = new TemporalWorker(
                client,
                new TemporalWorkerOptions("my-task-queue").
                    AddActivity(activities.SayHello).
                    AddWorkflow<SayHelloWorkflow>());

            // Run worker until cancelled
            Console.WriteLine("Running worker");
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