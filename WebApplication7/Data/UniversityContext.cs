using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WebApplication7.Models;

namespace WebApplication7.Data
{
    public class UniversityContext : DbContext
    {
        private static UniversityContext instance;
       public  DbSet<Student>  Student  { get; set; }
        public static UniversityContext Instance()
        {
            
            if (instance == null)
            {
                instance = Instantiate_UniversityContext();

            }
            return instance;
        }
        private UniversityContext(DbContextOptions o) :base(o){ }
        private static  UniversityContext Instantiate_UniversityContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UniversityContext>();
            optionsBuilder.UseSqlite("Data Source=C:\\gl3\\framework\\project\\2022 GL3 .NET Framework TP4 - SQLite database.db");
            Debug.WriteLine("je suis declenchée"); 
            return new UniversityContext(optionsBuilder.Options);

        }

    }
}
