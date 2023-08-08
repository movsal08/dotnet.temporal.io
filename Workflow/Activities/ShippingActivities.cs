using Temporalio.Activities;

namespace Temporal
{
    public class ShippingActivities
    {
        [Activity]
        public static string StartShipping()
        {
            Console.WriteLine("Phone shipped!");

            return "Shipped!";
        }
    }
}