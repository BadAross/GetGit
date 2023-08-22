public static class EFModel
{
    public static GitRequestDbContext dbContext = null;

    public static void InitilizeDBContext(IServiceProvider serviceProvider)
    {
        IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
        dbContext = serviceScope.ServiceProvider.GetService<GitRequestDbContext>();
    }
}