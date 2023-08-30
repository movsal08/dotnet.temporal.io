using Temporalio.Activities;

namespace Temporal
{
    public class SendRoomTokenActivities
    {
        [Activity]
        public static string StartShipping()
        {
            Console.WriteLine("Room token sent");

            return "Token sent!";
        }
    }
}