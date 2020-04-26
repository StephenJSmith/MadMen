using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
  public class MadMenContextSeed
  {
    public static async Task Seed(MadMenContext context, ILoggerFactory loggerFactory)
    {
      try
      {
          await context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        var logger = loggerFactory.CreateLogger<MadMenContext>();
        logger.LogError(ex.Message);
      }
    }
  }
}