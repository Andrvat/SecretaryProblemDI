using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecretaryProblemDI.Generators;

namespace SecretaryProblemDI;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
        {
            services.AddHostedService<TaskSimulator>();
            services.AddSingleton(_ => new CliArgumentsParser(args));
            services.AddScoped<AttemptsDbConfigurator>();
            services.AddDbContext<AttemptsDbContext>();
            services.AddScoped<ContendersFileGenerator>();
            services.AddSingleton<ContendersDbGenerator>();
            services.AddScoped<TaskContext>();
            services.AddScoped<Princess>();
            services.AddScoped<Hall>();
            services.AddScoped<Friend>();
        });
    }
}