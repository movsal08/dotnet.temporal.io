namespace HotelApp
{
    public static class Hotel
    {
        public static bool ReserveRoom()
        {
            Random rnd = new();

            var result = rnd.Next(1, 11) > 3;

            Console.WriteLine(result ? "Room reserved!!" : "Can't reserve room");

            return result;
        }

        public static string BackupReserveRoom()
        {
            return "Hotel backup process successfully done";
        }
    }
}