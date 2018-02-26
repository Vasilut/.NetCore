using System;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ScoalaContext())
            {
                var prof = db.Profesor;
            }
            Console.WriteLine("Hello World!");
            //Scaffold-DbContext "Host=192.168.111.140;Port=5432;Database=Scoala;User Id=postgres;Password=password01!;" Npgsql.EntityFrameworkCore.PostgreSQL
        }
    }
}
