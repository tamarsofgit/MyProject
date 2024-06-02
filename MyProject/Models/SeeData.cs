using Microsoft.EntityFrameworkCore;
using MyProject.Data;

namespace MyProject.Models
{
    public class SeeData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyProjectContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyProjectContext>>()))
            {
                // Look for any movies.
                if (context.City.Any())
                {
                    return;   // DB has been seeded
                }
                context.City.AddRange(
                    new City
                    {
                        NameCity = "hashmonaim"

                    },
                    new City
                    {
                        NameCity = "mattiau "
                    },
                    new City
                    {
                        NameCity = "rechovot "
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
