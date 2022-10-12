using System.Reflection;

namespace HackerthonProject.Data
{
    public class Seed
    {

        public static async Task SeedAsync(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
			try
			{
				var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

				if (!context.Advocates.Any())
				{
					using var transaction = context.Database.BeginTransaction();	
				}

			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
