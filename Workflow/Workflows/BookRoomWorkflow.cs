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

            await Workflow.ExecuteActivityAsync(
               () => BookRoomActivities.MakeHotelPayment(),
               new()
               {
                   StartToCloseTimeout = TimeSpan.FromMinutes(2)
               });

            return result;
        }
    }
}