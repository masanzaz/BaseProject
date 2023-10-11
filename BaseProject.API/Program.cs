using BaseProject.API;

public class Program
{
    public static void Main(string[] args)
    {
        var hostBuilder = CreateHostBuilder(args).Build();
        hostBuilder.Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var env = hostingContext.HostingEnvironment;
#if DEBUG
                    if (env.IsDevelopment())
                    {
                        config.AddJsonFile("appsettings.Development.json");
                    }
#endif
                });
                webBuilder.UseStartup<Startup>();
            });
}