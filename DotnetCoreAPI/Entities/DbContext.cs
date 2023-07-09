using Microsoft.EntityFrameworkCore;


namespace DotnetCoreAPI.Entities
{
    public partial class DBContext : DbContext
    {


        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public virtual DbSet<personaldetails> personaldetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL
                    ("server=Mysql@localhost:3306;port=3306;user=root;password=Admin@123;database=employeedetails");
            }
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<personaldetails>(entity =>
            {
                entity.ToTable("personaldetails");
            });

            OnModelCreatingPartial(modelBuilder);

        }

    }
}