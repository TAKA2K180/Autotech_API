namespace Autotech.Main.Data.Contracts
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext();
    }
}
