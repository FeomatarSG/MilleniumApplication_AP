using NUnit.Framework;
using MilleniumApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using MilleniumApplication.Controllers;
using System.Linq;

namespace MilleniumApplication.Tests
{
    public class SqliteItemsControllerTest : ItemsControllerTest
    {
        public SqliteItemsControllerTest()
        : base(
            new DbContextOptionsBuilder<ItemsContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ItemsControllerGetElements_Test()
        {
            using (var context = new ItemsContext(ContextOptions))
            {
                ItemsController controller = new ItemsController(context);
                var items = controller.GetAllElements();

                Assert.AreEqual(7, items.Count());
            }
        }

        [Test]
        public void ItemsControllerGetOneItem_Test()
        {
            using (var context = new ItemsContext(ContextOptions))
            {
                ItemsController controller = new ItemsController(context);
                var item1 = controller.GetElement(1);

                var obj = new Item() { Id = 1, Description = "Opis", Name = "El_1", Price = 5 };
                Assert.AreEqual(obj, item1);
            }
        }

        //private ItemsContext GetContextWithData()
        //{
        //    var options = new DbContextOptionsBuilder<ItemsContext>()
        //                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
        //                      .Options;
        //    var context = new ItemsContext(options);

        //    context.TestElements.Add(new TestElements { Id = 1, Name = "El_1", Price = 7, Description = "Opis w elemencie testowym" });
        //    context.TestElements.Add(new TestElements { Id = 2, Name = "El_2", Price = 15, Description = "Opis - El_2" });
        //    context.TestElements.Add(new TestElements { Id = 3, Name = "A", Price = 35, Description = "Opis - A" });
        //    context.TestElements.Add(new TestElements { Id = 5, Name = "B", Price = 55, Description = "Opis - B" });
        //    context.TestElements.Add(new TestElements { Id = 6, Name = "C", Price = 11, Description = "Opis - C" });
        //    context.TestElements.Add(new TestElements { Id = 11, Name = "D", Price = 102, Description = "Opis - D" });
        //    context.TestElements.Add(new TestElements { Id = 12, Name = "D1", Price = 85, Description = "Opis - D1" });


        //    context.SaveChanges();

        //    return context;
        //}
    }
}