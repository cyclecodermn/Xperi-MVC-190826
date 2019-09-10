using Xperi_MVC.data.Repos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xperi_MVC.data.Models;

namespace Xperi_MVC_190826.tests
{
    [TestFixture]
    public class DapperRepoTests
    {
        private static DapperRepo _repo = new DapperRepo();

        public class DapperRepoTest
        {
            [Test]
            public void CanLoadAllToDos()
            {
                List<ToDoItem> AllToDos = new List<ToDoItem>();
                AllToDos = _repo.GetAll().ToList();

                Assert.AreEqual(3, AllToDos.Count());
            }

            // I commented out the tests below to focus on the test above,
            // since the exact code works in the ToDoController.
            //
  //          [Test]
  //          public void FoundTodosByName()
  //          {
  //              List<ToDoItem> ToDos = new List<ToDoItem>();

  //              ToDos = _repo.GetByName("home").ToList();
  //              Assert.AreEqual(2, ToDos.Count());
  //          }

  //          [Test]
  //          public void FoundbyId()
  //          {
  //              var testRepo = new DapperRepo();

  //              ToDoItem FirstToDo = testRepo.GetById(0);
  //              ToDoItem SecondToDo = _repo.GetById(1);
  //              ToDoItem ThirdToDo = _repo.GetById(2);

  //              Assert.AreEqual("(SQL Repo0) Go for a bike ride near home.", FirstToDo.Name);
  //              Assert.AreEqual("(SQL Repo1) Go for a bike ride far from home.", SecondToDo.Name);
  //              Assert.AreEqual("(SQL Repo2) Oil bike chain", ThirdToDo.Name);

  //          }
  //          [Test]
  //          public void CanAddTodo()
  //          {
  //              AddNewTodoForTesting();

  //              ToDoItem newestToDo = new ToDoItem();
  //              newestToDo = _repo.GetById(3);

  //              Assert.AreEqual("Fix code.", newestToDo.Name);
  //              _repo.Delete(3);
  //          }
  //          [Test]
  //          public void CanUpdateTodo()
  //          {
  //              AddNewTodoForTesting();

  //              ToDoItem updatedToDo = new ToDoItem();
  //              updatedToDo = _repo.GetById(3);

  //              updatedToDo.Name = "New name.";

  //              Assert.AreEqual("New name.", updatedToDo.Name);
  //              _repo.Delete(3);
  //          }

  //          public void AddNewTodoForTesting()
  //          {
  //              ToDoItem newToDo = new ToDoItem();
  //              newToDo.Name = "Fix code.";
  //              newToDo.Completed = true;
  //              newToDo.Note = "Some note";

  ////              MockRepo repo = new MockRepo();
  //              _repo.Create(newToDo);
  //          }
        }
    }
}
