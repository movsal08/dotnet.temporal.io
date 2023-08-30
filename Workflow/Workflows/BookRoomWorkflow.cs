using Temporalio.Api.Update.V1;
using Temporalio.Workflows;

namespace Temporal
{
    [Workflow]
    public class BookRoomWorkflow
    {
        [WorkflowRun]
        public async Task<string> RunAsync()
        {
            string result = string.Empty;

            result += await Workflow.ExecuteActivityAsync(
                  () => BookRoomActivities.BookHotelRoom(),
                  new()
                  {
                      StartToCloseTimeout = TimeSpan.FromMinutes(2)
                  });

            result += await Workflow.ExecuteActivityAsync(
                () => BookRoomActivities.BookHotelTicket(),
                new()
                {
                    StartToCloseTimeout = TimeSpan.FromMinutes(2)
                });

            result += await Workflow.ExecuteActivityAsync(
               () => BookRoomActivities.MakeHotelPayment(),
               new()
               {
                   StartToCloseTimeout = TimeSpan.FromMinutes(2)
               });

            // Start child workflow asynchronously
            await Workflow.StartChildWorkflowAsync(
                (SendRoomTokenChildWorkflow wf) => wf.RunAsync(), 
                new()
                {
                    Id = $"child[send-token][{Guid.NewGuid()}]",
                    ParentClosePolicy = ParentClosePolicy.Abandon
                });

            return result;
        }
    }
}