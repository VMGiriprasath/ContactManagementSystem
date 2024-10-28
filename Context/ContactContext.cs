using Microsoft.EntityFrameworkCore;

public class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
        
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=GIRIPRASATHVM;Initial Catalog=ContactDB;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>()
            .Property(c => c.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Contact>()
            .Property(c => c.LastName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<Contact>()
            .Property(c => c.PhoneNumber)
            .HasMaxLength(15);

        modelBuilder.Entity<Contact>()
            .Property(c => c.Email)
            .HasMaxLength(50);

        modelBuilder.Entity<Contact>()
            .Property(c => c.Address)
            .HasMaxLength(100);
    }
}
