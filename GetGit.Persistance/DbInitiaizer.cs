public class DbInitiaizer
{
    public static void Initialize(GitRequestDbContext context)
    {
        context.Database.EnsureCreated();
    }
}
