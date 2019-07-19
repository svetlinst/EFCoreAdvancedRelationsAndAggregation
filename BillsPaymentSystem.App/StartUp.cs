using BillsPaymentSystem.Data;
using System;

namespace BillsPaymentSystem.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new BillsPaymentSystemContext())
            {
                DbInitializer.Seed(context);
                Console.WriteLine("Done!");
            }
        }
    }
}
