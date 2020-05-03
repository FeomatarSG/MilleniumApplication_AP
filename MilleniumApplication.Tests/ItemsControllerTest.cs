using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MilleniumApplication.Models;

namespace MilleniumApplication.Tests
{
    public class ItemsControllerTest
    {
        public ItemsControllerTest(DbContextOptions<ItemsContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        protected DbContextOptions<ItemsContext> ContextOptions { get; set; }

        private void Seed()
        {
            using (var context = new ItemsContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Add(new Item { Id = 1, Name = "El_1", Price = 5, Description = "Opis" });
                context.Add(new Item { Id = 2, Name = "El_2", Price = 15, Description = "Opis - El_2" });
                context.Add(new Item { Id = 3, Name = "A", Price = 35, Description = "Opis - A" });
                context.Add(new Item { Id = 5, Name = "B", Price = 55, Description = "Opis - B" });
                context.Add(new Item { Id = 6, Name = "C", Price = 11, Description = "Opis - C" });
                context.Add(new Item { Id = 11, Name = "D", Price = 102, Description = "Opis - D" });
                context.Add(new Item { Id = 12, Name = "D1", Price = 85, Description = "Opis - D1" });

                context.SaveChanges();
            }
        }



        //public ItemsContext Context => InMemoryContext();

        //public void Dispose()
        //{
        //    Context?.Dispose();
        //}

        //private static ItemsContext InMemoryContext()
        //{
        //    var options = new DbContextOptionsBuilder<ItemsContext>()
        //        .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //        .EnableSensitiveDataLogging()
        //        .Options;
        //    var context = new ItemsContext(options);

        //    context.Items.Add(new Item { Id = 1, Name = "El_1", Price = 7, Description = "Opis w elemencie testowym" });
        //    context.Items.Add(new Item { Id = 2, Name = "El_2", Price = 15, Description = "Opis - El_2" });
        //    context.Items.Add(new Item { Id = 3, Name = "A", Price = 35, Description = "Opis - A" });
        //    context.Items.Add(new Item { Id = 5, Name = "B", Price = 55, Description = "Opis - B" });
        //    context.Items.Add(new Item { Id = 6, Name = "C", Price = 11, Description = "Opis - C" });
        //    context.Items.Add(new Item { Id = 11, Name = "D", Price = 102, Description = "Opis - D" });
        //    context.Items.Add(new Item { Id = 12, Name = "D1", Price = 85, Description = "Opis - D1" });


        //    return context;
        //}
    }
}
