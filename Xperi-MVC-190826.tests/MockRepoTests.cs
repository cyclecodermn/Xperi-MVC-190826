using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xperi_MVC.data.Models;
using Xperi_MVC.data.Repos;

namespace Xperi_MVC_190826.tests
{
    public class StaticMockRepoTests
    {
        //I don't know why the fields below do not work, but I want to figure it out, someday.
        MockRepo _repo = new MockRepo();
        private List<ToDoItem> _ToDos = new List<ToDoItem>();

        [TestFixture]
        public class MockRepoTest
        {
            [Test]
            public void CanLoadToDos()
            {
                MockRepo repo = new MockRepo();
                List<ToDoItem> ToDos = new List<ToDoItem>();
                ToDos = repo.GetAll().ToList();
                Assert.AreEqual(3, ToDos.Count());
            }

            [Test]
            public void FoundTodosByName()
            {
                MockRepo repo = new MockRepo();
                List<ToDoItem> ToDos = new List<ToDoItem>();

                ToDos = repo.GetByName("home").ToList();
                Assert.AreEqual(2, ToDos.Count());
            }

            [Test]
            public void FoundbyId()
            {
                MockRepo repo = new MockRepo();

                ToDoItem FirstToDo = repo.GetById(0);
                ToDoItem SecondToDo = repo.GetById(1);
                ToDoItem ThirdToDo = repo.GetById(2);

                Assert.AreEqual ("Go for a bike ride near home.", FirstToDo.Name);
                Assert.AreEqual("Go for a bike ride far from home.", SecondToDo.Name);
                Assert.AreEqual("Oil bike chain", ThirdToDo.Name);

            }
            [Test]
            public void CanAddTodo()
            {
                AddNewTodoForTesting();

                MockRepo repo = new MockRepo();
                ToDoItem newestToDo = new ToDoItem();
                newestToDo = repo.GetById(3);

                Assert.AreEqual("Fix code.", newestToDo.Name);
                repo.Delete(3);
            }
            [Test]
            public void CanUpdateTodo()
            {
                AddNewTodoForTesting();

                MockRepo repo = new MockRepo();
                
                ToDoItem updatedToDo = new ToDoItem();
                updatedToDo = repo.GetById(3);

                updatedToDo.Name = "New name.";

                Assert.AreEqual("New name.", updatedToDo.Name);
                repo.Delete(3);
            }

            public void AddNewTodoForTesting()
            {
                ToDoItem newToDo = new ToDoItem();
                newToDo.Name = "Fix code.";
                newToDo.Completed = true;
                newToDo.Note = "Some note";

                MockRepo repo = new MockRepo();
                repo.Create(newToDo);

            }
        }
    }
}
