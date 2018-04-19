using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skeddly;
using Skeddly.Model;

namespace DotNet461Console
{
	class Program
	{
		static void Main(string[] args)
		{
			MainAsync(args).Wait();
		}

		static async Task MainAsync(string[] args)
		{
			// Initialize the client
			var client = new SkeddlyClient();

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
