using GomokuApp.Common.Logging;

internal class Program
{
    public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<GomokuApp.Startup>();
               });
    private static void Main(string[] args)
    {
        try
        {
            Log.Initialize();
            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

