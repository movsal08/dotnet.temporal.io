namespace TicketApp
{
    public static class Ticket
    {
        public static bool BookTicket()
        {
            Random rnd = new();

            var result = rnd.Next(1, 11) > 3;

            Console.WriteLine(result ? "Ticket reserved!!" : "Can't reserve ticket");

            return result;
        }

        public static string BackupBookTicket()
        {
            return "Ticket backup process successfully done";
        }
    }
}