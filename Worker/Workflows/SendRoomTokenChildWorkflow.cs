using Temporalio.Workflows;

namespace Temporal
{
    [Workflow]
    public class SendRoomTokenChildWorkflow
    {
        [WorkflowRun]
        public async Task<string> RunAsync()
        {
            string result = string.Empty;

            result += await Workflow.ExecuteActivityAsync(
                  () => SendRoomTokenActivities.StartShipping(),
                  new()
                  {
                      StartToCloseTimeout = TimeSpan.FromMinutes(2)
                  });

            return result;
        }
    }
}