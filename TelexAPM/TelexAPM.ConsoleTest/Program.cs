using System.Threading.Tasks;
using TelexApm.Services;
using Microsoft.Extensions.Configuration;

class Program
{
    static async Task Main(string[] args)
    {
        //config builder - i'm setting appsettings as config file
        var Config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        TelexConfiguration telexConfig = GetTelexConfig(Config);

        await Test(telexConfig);
    }

    public static async Task Test(TelexConfiguration telexConfig)
    {

        TelexClient telex = new(telexConfig);
        var x = new Exception("Console Test Telex Error");
        await telex.TrackErrorAsync(x);

        Console.WriteLine("test done");
    }

    public static TelexConfiguration GetTelexConfig(IConfigurationRoot _config)
    {
        TelexConfiguration config = new()
        {
            BaseUrl = _config["Telex:BaseUrl"],
            ChannelHookId = _config["Telex:ChannelHookId"],
        };

        return config;
    }
}