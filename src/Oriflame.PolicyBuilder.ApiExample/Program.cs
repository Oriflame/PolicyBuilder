using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Oriflame.PolicyBuilder.Generator;

namespace Oriflame.PolicyBuilder.ApiExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            var generator = host.Services.GetService(typeof(IGenerator)) as IGenerator;
            generator.Generate(@"APITemplates\ApiExample\policies", typeof(Program).Assembly);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
