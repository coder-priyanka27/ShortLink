using ShortLink.Data;
using ShortLink.Data.Models;

namespace ShortLink.Client.Data
{
    public static class DbInitializer
    {
        public static void SeedDefaultData(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if(!dbContext.Users.Any())
                {
                    dbContext.Users.Add(new AppUser()
                    {
                        FullName = "Priyanka Rambhad User",
                        Email = "priyanka@rambhad.com"

                    });
                    dbContext.SaveChanges();
                }
                if(!dbContext.Urls.Any())
                {
                    dbContext.Urls.Add(new Url()
                    {
                        OriginalLink = "https://www.example.com",
                        ShortLink = "exmpl",
                        NoOfClicks = 20,
                        DateCreated = DateTime.Now,

                        UserId = dbContext.Users.First().Id
                    });

                    dbContext.SaveChanges();
                }
            }
        }
    }
}
