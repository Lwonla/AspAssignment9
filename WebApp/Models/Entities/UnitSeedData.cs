using Microsoft.EntityFrameworkCore;
using WebApp.Contexts;

namespace WebApp.Models.Entities;

public static class UnitSeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DataContext(serviceProvider.GetRequiredService<DbContextOptions<DataContext>>()))
        {
            if (context.UnitEntity.Any())
            {
                return;   // DB has been seeded
            }
            context.UnitEntity.AddRange(
                new UnitEntity
                {
                    Title = "Marshall WH-CH710",
                    Description = "Noise-cancelling wireless around-ear headphones with selectable Ambient Sound mode.",
                    Ingress = "The WH-CH710N Wireless Noise-Canceling Headphones offer powerful, distraction-free listening wherever you are.",
                    ImageUrl = "images/Marshall120x113.jpg",
                    Price = 15850M,
                    Category = "New"
                },
                new UnitEntity
                {
                    Title = "Sony WH-1000XM4",
                    Description = "The world's best noise cancellation has gotten even a little better.",
                    Ingress = "The WH-1000XM4 headphones blend our most advanced noise cancelling with exceptional sound quality and a range of smart features for an unrivalled listening experience.",
                    ImageUrl = "images/Sony120x113.jpg",
                    Price = 17850M,
                    Category = "Popular"
                },
                new UnitEntity
                {
                    Title = "Sound On kit",
                    Description = "Features acoustics fine-tuned by sound engineers for the perfect sound.",
                    Ingress = "The Sound On kit is a collection of the best audio products from Marshall.",
                    ImageUrl = "images/SoundOn120x113.jpg",
                    Price = 12400M,
                    Category = "Featured"
                }
            );
            context.SaveChanges();
        }
    }
}