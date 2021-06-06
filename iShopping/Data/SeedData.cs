using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iShopping.Models;
using System;
using System.Linq;

namespace iShopping.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new iShoppingDbContext(serviceProvider.GetRequiredService<DbContextOptions<iShoppingDbContext>>()))
            {
                // Look for any ContactUs.
                if (context.ContactUs.Any())
                {
                    return;   // DB has been seeded
                }

                context.ContactUs.AddRange(
                    new ContactUs
                    {
                        FirstName = "Tan",
                        LastName = "Trinh",
                        Email = "tanthanhtrinh@hotmail.com",
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        PhoneNumber = "0987110341"
                    },
                    new ContactUs
                    {
                        FirstName = "Tam",
                        LastName = "Nguyen",
                        Email = "tanthanhtrinh@hotmail.com",
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        PhoneNumber = "0987654321",
                    },
                    new ContactUs
                    {
                        FirstName = "Cuong",
                        LastName = "Nguyen",
                        Email = "cuongnguyen@hotmail.com",
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        PhoneNumber = "0987654321",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}