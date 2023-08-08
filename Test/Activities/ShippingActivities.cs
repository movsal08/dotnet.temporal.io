using Temporalio.Activities;

namespace Test
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