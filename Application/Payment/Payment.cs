namespace PaymentApp
{
    public static class Payment
    {
        public static bool MakePayment()
        {
            Random rnd = new();

            var result = rnd.Next(1, 11) > 3;

            Console.WriteLine(result ? "Payment success!!" : "Can't make payment");

            return result;
        }

        public static string BackupMakePayment()
        {
            return "Payment backup process successfully done";
        }
    }
}