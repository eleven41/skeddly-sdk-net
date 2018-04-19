using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Skeddly;
using Skeddly.Model;

namespace DotNetCoreConsole
{
    class Program
    {
		static void Main(string[] args)
		{
			MainAsync(args).Wait();
		}

		static async Task MainAsync(string[] args)
		{
			// Load the configuration
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");
			IConfiguration configuration = builder.Build();

			// Initialize the client
			var options = configuration.GetSkeddlyOptions();
			var client = options.CreateClient();

			// Get the list of actions
			var response = await client.ListActionsAsync(new ListActionsRequest());
			foreach (var action in response.Actions)
			{
				Console.WriteLine("{0}", action.Name);
			}

			Console.WriteLine("Press Enter to continue...");
			Console.ReadLine();
		}
	}
}
