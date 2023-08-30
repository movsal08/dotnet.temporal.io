using HotelApp;
using PaymentApp;
using System.Text;
using Temporalio.Activities;
using TicketApp;

namespace Temporal
{
    public static class BookRoomActivities
    {
        // Activities can be async and/or static too! We just demonstrate instance
        // methods since many will use them that way.
        [Activity]
        public static string BookHotelRoom()
        {
            var (Success, Error) = BookRoom();

            if (!Success)
            {
                return Error;
            }

            return "Room book success!";
        }

        [Activity]
        public static string BookHotelTicket()
        {
            var (Success, Error) = BookTicket();

            if (!Success)
            {
                return Error;
            }

            return "Ticket book success!";
        }

        [Activity]
        public static string MakeHotelPayment()
        {
            var (Success, Error) = MakePayment();

            if (!Success)
            {
                return Error;
            }

            return "Payment success!";
        }

        private static (bool Success, string Error) BookRoom()
        {
            Console.WriteLine("Booking hotel room");

            var roomReserved = Hotel.ReserveRoom();

            if (!roomReserved)
            {
                StringBuilder backupResult = new();

                backupResult.AppendLine(Hotel.BackupReserveRoom());

                backupResult.AppendLine("Failed to reserve room");

                return (false, backupResult.ToString());
            }

            return (true, string.Empty);
        }

        private static (bool Success, string Error) BookTicket()
        {
            Console.WriteLine("Booking ticket");

            var ticketBooked = Ticket.BookTicket();

            if (!ticketBooked)
            {
                StringBuilder backupResult = new();

                backupResult.AppendLine(Hotel.BackupReserveRoom());
                backupResult.AppendLine(Ticket.BackupBookTicket());

                backupResult.AppendLine("Failed to reserve ticket");

                return (false, backupResult.ToString());
            }

            return (true, string.Empty);
        }

        private static (bool Success, string Error) MakePayment()
        {
            Console.WriteLine("Make payment");

            var paymentMade = Payment.MakePayment();

            if (!paymentMade)
            {
                StringBuilder backupResult = new();

                backupResult.AppendLine(Hotel.BackupReserveRoom());
                backupResult.AppendLine(Ticket.BackupBookTicket());
                backupResult.AppendLine(Payment.BackupMakePayment());

                backupResult.AppendLine("Failed to make payment");

                return (false, backupResult.ToString());
            }

            return (true, string.Empty);
        }
    }
}