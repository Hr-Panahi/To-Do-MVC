using Microsoft.EntityFrameworkCore;
using ToDoList_MVC.Models;

namespace ToDoList_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<tblTask> tblTasks { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Task>().HasKey(t => t.Id);
        //}
    }
}
