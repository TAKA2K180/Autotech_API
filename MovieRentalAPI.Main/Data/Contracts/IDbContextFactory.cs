namespace MovieRentalAPI.Main.Data.Contracts
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext();
    }
}
