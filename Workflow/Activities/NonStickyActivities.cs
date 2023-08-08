using System.Diagnostics.Tracing;
using Temporalio.Activities;

namespace Temporal
{
    public class NonStickyActivities
    {
        private readonly string uniqueWorkerTaskQueue;

        public NonStickyActivities(string uniqueWorkerTaskQueue) =>
            this.uniqueWorkerTaskQueue = uniqueWorkerTaskQueue;

        [Activity]
        public string GetUniqueTaskQueue()
        {
            return uniqueWorkerTaskQueue;
        }
    }
}