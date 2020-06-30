namespace HumanManagermentBackend.Database
{
    public class DbInitializer
    {
        public static void Initialize(HumanManagerContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
