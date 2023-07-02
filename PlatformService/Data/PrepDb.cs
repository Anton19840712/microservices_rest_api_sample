using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
	public static void PrepPopulation(IApplicationBuilder app, bool isProd)
	{
		using var serviceScope = app.ApplicationServices.CreateScope();
		SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
	}

	private static void SeedData(AppDbContext context, bool isProd)
	{
		if (isProd)
		{
			Console.WriteLine("--> Attempting to apply migrations...");
			try
			{
				context.Database.Migrate();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"--> Could not run migrations: {ex.Message}");
			}
		}

		if (!context.Platforms.Any())
		{
			Console.WriteLine("--> Seeding Data...");

			var platforms = new List<Platform>()
			{
				new() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
				new() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
				new() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" },
				new() { Name = "AwesomeFramework", Publisher = "CoolCompany", Cost = "$99" },
				new() { Name = "DataMagic", Publisher = "DataWizards", Cost = "$49" },
				new() { Name = "RoBoCoder", Publisher = "TechGenius", Cost = "Free" },
				new() { Name = "InfiniteConnect", Publisher = "UnlimitedTech", Cost = "$199" },
				new() { Name = "NaNoAI", Publisher = "FutureTech", Cost = "Free" },
				new() { Name = "SuperSpeedDB", Publisher = "DataMasters", Cost = "$149" },
				new() { Name = "CloudGenie", Publisher = "CloudMaster", Cost = "$79" },
				new() { Name = "CyBerSecure", Publisher = "SecureTech", Cost = "$199" },
				new() { Name = "CodeCraft", Publisher = "DigitalArtisans", Cost = "Free" },
				new() { Name = "SmartBot", Publisher = "AIInnovators", Cost = "$299" },
				new() { Name = "EcoEnergy", Publisher = "GreenTech", Cost = "$99" },
				new() { Name = "CryptoVault", Publisher = "BlockChainSolutions", Cost = "Free" },
				new() { Name = "DataSense", Publisher = "DataGenius", Cost = "$49" },
				new() { Name = "TechConnect", Publisher = "TechExperts", Cost = "$199" },
				new() { Name = "PixelPerfect", Publisher = "DesignMasters", Cost = "$79" },
				new() { Name = "CloudScale", Publisher = "ScalabilityTech", Cost = "$149" },
				new() { Name = "MindMeld", Publisher = "BrainwaveInnovations", Cost = "Free" },
				new() { Name = "AutoPilot", Publisher = "AutomationInc", Cost = "$199" },
				new() { Name = "GiGaData", Publisher = "DataTitans", Cost = "$99" },
				new() { Name = "HyperSpeed", Publisher = "VelocityTech", Cost = "Free" },
				new() { Name = "FutureProof", Publisher = "TechVisionaries", Cost = "$299" },
				new() { Name = "AquaTech", Publisher = "WaterInnovations", Cost = "$79" },
				new() { Name = "QuantumCode", Publisher = "QuantumTech", Cost = "$199" },
				new() { Name = "DreamWeaver", Publisher = "ImaginationStudios", Cost = "Free" },
				new() { Name = "RoBoHelper", Publisher = "AIAssistants", Cost = "$149" },
				new() { Name = "GreenConnect", Publisher = "EcoTech", Cost = "$99" },
				new() { Name = "SecureNet", Publisher = "CyBerSecurityInc", Cost = "Free" }
			};

			context.Platforms.AddRange(platforms);

			context.SaveChanges();
		}
		else
		{
			Console.WriteLine("--> We already have data");
		}
	}
}