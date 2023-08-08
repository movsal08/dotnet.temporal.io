using Temporalio.Workflows;

namespace Temporal
{
    [Workflow]
    public class ShippingWorkflow
    {
        [WorkflowRun]
        public async Task<string> RunAsync()
        {
            string result = string.Empty;

            result += await Workflow.ExecuteActivityAsync(
                  () => ShippingActivities.StartShipping(),
                  new()
                  {
                      StartToCloseTimeout = TimeSpan.FromMinutes(2)
                  });

            return result;
        }
    }
}