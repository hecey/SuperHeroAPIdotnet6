namespace Superhero.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){    }
    public DbSet<Superhero> SuperHeroes { get; set; }
}