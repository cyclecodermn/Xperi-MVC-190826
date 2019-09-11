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
        private static MockRepo _repo = new MockRepo();

        //I don't know why the field below doesn't work, but I want to figure it out, someday.
        private List<ToDoTableRow> _ToDos = new List<ToDoTableRow>();

        [TestFixture]
        public class MockRepoTest
        {
            [Test]
            public void CanLoadToDos()
            {
                List<ToDoTableRow> ToDos = new List<ToDoTableRow>();
                ToDos = _repo.GetAll().ToList();
                Assert.AreEqual(3, ToDos.Count());
            }

            [Test]
            public void FoundTodosByName()
            {
                List<ToDoTableRow> ToDos = new List<ToDoTableRow>();

                ToDos = _repo.GetByName("home").ToList();
                Assert.AreEqual(2, ToDos.Count());
            }

            [Test]
            public void FoundbyId()
            {
                ToDoTableRow FirstToDo = _repo.GetById(0);
                ToDoTableRow SecondToDo = _repo.GetById(1);
                ToDoTableRow ThirdToDo = _repo.GetById(2);

                Assert.AreEqual ("(Mock Repo0) Go for a bike ride near home.", FirstToDo.Name);
                Assert.AreEqual("(Mock Repo1) Go for a bike ride far from home.", SecondToDo.Name);
                Assert.AreEqual("(Mock Repo2) Oil bike chain", ThirdToDo.Name);

            }
            [Test]
            public void CanAddTodo()
            {
                AddNewTodoForTesting();

                ToDoTableRow newestToDo = new ToDoTableRow();
                newestToDo = _repo.GetById(3);

                Assert.AreEqual("Fix code.", newestToDo.Name);
                _repo.Delete(3);
            }
            [Test]
            public void CanUpdateTodo()
            {
                AddNewTodoForTesting();

                ToDoTableRow updatedToDo = new ToDoTableRow();
                updatedToDo = _repo.GetById(3);

                updatedToDo.Name = "New name.";

                Assert.AreEqual("New name.", updatedToDo.Name);
                _repo.Delete(3);
            }

            public void AddNewTodoForTesting()
            {
                ToDoTableRow newToDo = new ToDoTableRow();
                newToDo.Name = "Fix code.";
                newToDo.Completed = true;
                newToDo.Note = "Some note";

                MockRepo repo = new MockRepo();
                _repo.Create(newToDo);
            }
        }
    }
}
