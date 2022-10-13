using HackerthonProject.DTOs;
using HackerthonProject.Models;

using System.Reflection;
using System.Text.Json;

namespace HackerthonProject.Data
{
    public class Seed
    {

        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
			try
			{
				//var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				if (!context.Companies.Any())
				{
                    using var transaction = context.Database.BeginTransaction();
					var companyData = File.ReadAllText("./Data/SeedData/Company.json");
                    //var company = JsonConvert.DeserializeObject<List<Company>>(companyData);
                    var company = JsonSerializer.Deserialize<List<Company>>(companyData);

                    foreach (var item in company)
                    {
                        context.Companies.Add(item);
                    }

                    await context.SaveChangesAsync();

                    transaction.Commit();

                }


				if (!context.Advocates.Any())
				{
					using var transaction = context.Database.BeginTransaction();

                    var advocateData = File.ReadAllText("./Data/SeedData/Advocate.json");

					var advocate = JsonSerializer.Deserialize<List<Advocate>>(advocateData);
					
					

					foreach (var item in advocate)
					{
					  	context.Advocates.Add(item);
					}

					await context.SaveChangesAsync();

					transaction.Commit();
						
				}

			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Seed>();
				logger.LogError(ex.Message);
			}
        }
    }
}
