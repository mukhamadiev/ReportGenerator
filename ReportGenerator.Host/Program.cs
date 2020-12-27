using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace ReportGenerator.Host
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                     .ConfigureAppConfiguration(
                         x => x.AddJsonFile(
                             "appsettings.json",
                             optional: false,
                             reloadOnChange: true))
                     .ConfigureServices(
                         (builderContext, container) => CompositionRoot.RegisterDependencies(
                             container,
                             builderContext));
    }
}