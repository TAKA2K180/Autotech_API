namespace Autotech.BusinessLayer.Data.Contracts
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext();
    }
}
