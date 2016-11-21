namespace _13UniversitySystem
{
    class Program
    {
        static void Main()
        {
            // var context = new TphUniversityContext();
            // var context = new TptUniversityContext();
            var context = new TpCcUniversityContext();
            context.Database.Initialize(true);
        }
    }
}
