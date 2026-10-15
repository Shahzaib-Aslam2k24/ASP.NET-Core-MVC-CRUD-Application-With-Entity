using Microsoft.EntityFrameworkCore;
using WebApplicationData.Models;

namespace WebApplicationData.Datacontext
{
    public class datacontext : DbContext
    {
        public datacontext(DbContextOptions opt ) : base(opt) { }
        public DbSet<Studentdata> Allstudent { get; set; }
    }
}
