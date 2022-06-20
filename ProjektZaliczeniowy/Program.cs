using System;

namespace ProjektZaliczeniowy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (GabinetContext db = new GabinetContext())
            {
                db.Database.EnsureCreated();
                db.Add(new Role { Name = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();
            }
        }
    }
}