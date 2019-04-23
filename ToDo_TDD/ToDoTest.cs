using Xunit;
using ToDo.Data;
using ToDo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System.Linq;


namespace ToDo_TDD
{
    public class ToDoTest
    {
        [Fact]
        public void CanGetOneToDoItem()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoItems").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoItems toDoItem = new ToDoItems();
                toDoItem.ToDoListID = 1;
                toDoItem.Name = "Do a Jig";
                toDoItem.IsComplete = false;

                context.Add(toDoItem);
                context.SaveChanges();

                // Act
                var result = context.ToDoItems.FirstOrDefault(m => m.ID == toDoItem.ID);

                // Assert

                Assert.Equal(result, toDoItem);


            };
        }

        [Fact]
        public void CanGetOneToDoItemFromThree_One()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoItems").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoItems toDoItem1 = new ToDoItems();
                toDoItem1.ToDoListID = 1;
                toDoItem1.Name = "Do a Jig";
                toDoItem1.IsComplete = false;

                ToDoItems toDoItem2 = new ToDoItems();
                toDoItem2.ToDoListID = 2;
                toDoItem2.Name = "Play my Tenor Sax";
                toDoItem2.IsComplete = false;

                ToDoItems toDoItem3 = new ToDoItems();
                toDoItem3.ToDoListID = 2;
                toDoItem3.Name = "Play my Alto Sax";
                toDoItem3.IsComplete = false;

                context.Add(toDoItem1);
                context.Add(toDoItem2);
                context.Add(toDoItem3);
                context.SaveChanges();

                // Act
                var result = context.ToDoItems.FirstOrDefault(m => m.ID == toDoItem1.ID);

                // Assert

                Assert.Equal(result, toDoItem1);


            };
        }

        [Fact]
        public void CanGetOneToDoItemFromThree_Two()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoItems").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoItems toDoItem1 = new ToDoItems();
                toDoItem1.ToDoListID = 1;
                toDoItem1.Name = "Do a Jig";
                toDoItem1.IsComplete = false;

                ToDoItems toDoItem2 = new ToDoItems();
                toDoItem2.ToDoListID = 2;
                toDoItem2.Name = "Play my Tenor Sax";
                toDoItem2.IsComplete = false;

                ToDoItems toDoItem3 = new ToDoItems();
                toDoItem3.ToDoListID = 2;
                toDoItem3.Name = "Play my Alto Sax";
                toDoItem3.IsComplete = false;

                context.Add(toDoItem1);
                context.Add(toDoItem2);
                context.Add(toDoItem3);
                context.SaveChanges();

                // Act
                var result = context.ToDoItems.FirstOrDefault(m => m.ID == toDoItem2.ID);

                // Assert

                Assert.Equal(result, toDoItem2);


            };
        }

        [Fact]
        public void CanGetOneToDoItemFromThree_Three()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoItems").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoItems toDoItem1 = new ToDoItems();
                toDoItem1.ToDoListID = 1;
                toDoItem1.Name = "Do a Jig";
                toDoItem1.IsComplete = false;

                ToDoItems toDoItem2 = new ToDoItems();
                toDoItem2.ToDoListID = 2;
                toDoItem2.Name = "Play my Tenor Sax";
                toDoItem2.IsComplete = false;

                ToDoItems toDoItem3 = new ToDoItems();
                toDoItem3.ToDoListID = 2;
                toDoItem3.Name = "Play my Alto Sax";
                toDoItem3.IsComplete = false;

                context.Add(toDoItem1);
                context.Add(toDoItem2);
                context.Add(toDoItem3);
                context.SaveChanges();

                // Act
                var result = context.ToDoItems.FirstOrDefault(m => m.ID == toDoItem3.ID);

                // Assert

                Assert.Equal(result, toDoItem3);


            };
        }

        [Fact]
        public void CanGetOneToDoList()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoLists").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoLists toDoList = new ToDoLists();
                toDoList.UserName = "Its Me";
                toDoList.Name = "TODO after Success";

                context.Add(toDoList);
                context.SaveChanges();

                // Act
                var result = context.ToDoLists.FirstOrDefault(m => m.ID == toDoList.ID);

                // Assert

                Assert.Equal(result, toDoList);


            };
        }

        [Fact]
        public void CanGetOneToDoListFromThree_One()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoLists").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoLists toDoList1 = new ToDoLists();
                toDoList1.UserName = "Its Me";
                toDoList1.Name = "TODO after Success";

                ToDoLists toDoList2 = new ToDoLists();
                toDoList2.UserName = "Its Me";
                toDoList2.Name = "Hobbies to get back to";

                ToDoLists toDoList3 = new ToDoLists();
                toDoList3.UserName = "Its Me";
                toDoList3.Name = "New Hobbies";

                context.Add(toDoList1);
                context.Add(toDoList2);
                context.Add(toDoList3);
                context.SaveChanges();

                // Act
                var result = context.ToDoLists.FirstOrDefault(m => m.ID == toDoList1.ID);

                // Assert

                Assert.Equal(result, toDoList1);


            };
        }

        [Fact]
        public void CanGetOneToDoListFromThree_Two()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoLists").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoLists toDoList1 = new ToDoLists();
                toDoList1.UserName = "Its Me";
                toDoList1.Name = "TODO after Success";

                ToDoLists toDoList2 = new ToDoLists();
                toDoList2.UserName = "Its Me";
                toDoList2.Name = "Hobbies to get back to";

                ToDoLists toDoList3 = new ToDoLists();
                toDoList3.UserName = "Its Me";
                toDoList3.Name = "New Hobbies";

                context.Add(toDoList1);
                context.Add(toDoList2);
                context.Add(toDoList3);
                context.SaveChanges();

                // Act
                var result = context.ToDoLists.FirstOrDefault(m => m.ID == toDoList2.ID);

                // Assert

                Assert.Equal(result, toDoList2);


            };
        }

        [Fact]
        public void CanGetOneToDoListFromThree_Three()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoLists").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoLists toDoList1 = new ToDoLists();
                toDoList1.UserName = "Its Me";
                toDoList1.Name = "TODO after Success";

                ToDoLists toDoList2 = new ToDoLists();
                toDoList2.UserName = "Its Me";
                toDoList2.Name = "Hobbies to get back to";

                ToDoLists toDoList3 = new ToDoLists();
                toDoList3.UserName = "Its Me";
                toDoList3.Name = "New Hobbies";

                context.Add(toDoList1);
                context.Add(toDoList2);
                context.Add(toDoList3);
                context.SaveChanges();

                // Act
                var result = context.ToDoLists.FirstOrDefault(m => m.ID == toDoList3.ID);

                // Assert

                Assert.Equal(result, toDoList3);


            };
        }

        [Fact]
        public void CanUpdateToDoItem()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoItems").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoItems toDoItem = new ToDoItems();
                toDoItem.ToDoListID = 1;
                toDoItem.Name = "Do a Jig";
                toDoItem.IsComplete = false;

                context.Add(toDoItem);
                context.SaveChanges();

                toDoItem.Name = "Leap up for Joy";
                context.Update(toDoItem);
                context.SaveChanges();

                // Act
                var result = context.ToDoItems.FirstOrDefault(m => m.ID == toDoItem.ID);

                // Assert

                Assert.Equal(result, toDoItem);


            };
        }

        [Fact]
        public void CanUpdateToDoList()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoLists").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoLists toDoList = new ToDoLists();
                toDoList.UserName = "Its Me";
                toDoList.Name = "TODO after Success";

                context.Add(toDoList);
                context.SaveChanges();

                toDoList.UserName = "Its not You";
                context.Update(toDoList);
                context.SaveChanges();

                // Act
                var result = context.ToDoLists.FirstOrDefault(m => m.ID == toDoList.ID);

                // Assert

                Assert.Equal(result, toDoList);


            };
        }

        /*
        [Fact]
        public void CanDeleteToDoItem()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoItems").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoItems toDoItem = new ToDoItems();
                toDoItem.ToDoListID = 1;
                toDoItem.Name = "Do a Jig";
                toDoItem.IsComplete = false;

                context.Add(toDoItem);
                context.SaveChanges();

                // Act
                var result = context.ToDoItems.FirstOrDefault(m => m.ID == toDoItem.ID);

                // Assert

                Assert.Equal(result, toDoItem);

                
                context.Remove(toDoItem);
                context.SaveChanges();

                // Act
                //var result2 = context.ToDoItems.FirstOrDefault(m => m.ID == toDoItem.ID);

                // Assert

                Assert.Null(toDoItem);


            };
        }

        [Fact]
        public void CanDeleteToDoList()
        {
            DbContextOptions<ToDoDbContext> options = new DbContextOptionsBuilder<ToDoDbContext>().UseInMemoryDatabase("CanCreateToDoLists").Options;

            using (ToDoDbContext context = new ToDoDbContext(options))
            {
                // Arrange
                ToDoLists toDoList = new ToDoLists();
                toDoList.UserName = "Its Me";
                toDoList.Name = "TODO after Success";

                context.Add(toDoList);
                context.SaveChanges();

                // Act
                var result = context.ToDoLists.FirstOrDefault(m => m.ID == toDoList.ID);

                // Assert

                Assert.Equal(result, toDoList);

                
                context.Remove(toDoList);
                context.SaveChanges();

                // Act
                

                // Assert

                Assert.Null(toDoList);


            };
        }
        */
    }
}
