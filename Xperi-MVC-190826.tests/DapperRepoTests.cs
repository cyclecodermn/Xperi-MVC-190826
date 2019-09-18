using Xperi_MVC.data.Repos;
using Xperi_MVC.data;
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
                DapperRepo myRepo = new DapperRepo();

                List<ToDoTableRow> AllToDos = new List<ToDoTableRow>();
                //AllToDos = _repo.GetAll().ToList();
                AllToDos = myRepo.GetAll().ToList();

                Assert.AreEqual(3, AllToDos.Count());
            }

            //[Test]
            //public void FoundTodosByName()
            //{
            //    List<ToDoTableRow> ToDos = new List<ToDoTableRow>();

            //    ToDos = _repo.GetByName("home").ToList();
            //    Assert.AreEqual(2, ToDos.Count());
            //}

            [Test]
            public void FoundbyId()
            {
               // var testRepo = new DapperRepo();

                ToDoTableRow FirstToDo = _repo.GetById(0);
                ToDoTableRow SecondToDo = _repo.GetById(1);
                ToDoTableRow ThirdToDo = _repo.GetById(2);

                Assert.AreEqual("(SQL Repo0) Go for a bike ride near home.", FirstToDo.Name);
                Assert.AreEqual("(SQL Repo1) Go for a bike ride far from home.", SecondToDo.Name);
                Assert.AreEqual("(SQL Repo2) Oil bike chain", ThirdToDo.Name);

            }
            [Test]
            public void CanAddTodo()
            {
                AddNewTodoForTesting();

                ToDoTableRow newestToDo = new ToDoTableRow();
                newestToDo = _repo.GetById(3);

                Assert.AreEqual("Fix code.", newestToDo.Name);
                _repo.Delete(3);
                //NOTE: Future errs are likely because I do not have a output
                //var here, to update the IDs that will likely have changed.
            }
            [Test]
            public void CanDeleteTodo()
            {
                List<ToDoTableRow> AllToDos = new List<ToDoTableRow>();
                AddNewTodoForTesting();
                AllToDos = _repo.GetAll().ToList();
                int countBeforeDelete = AllToDos.Count();

                _repo.Delete(countBeforeDelete);

                AllToDos = new List<ToDoTableRow>();
                AllToDos = _repo.GetAll().ToList();
                int countAfterDelete = AllToDos.Count();

                Assert.AreEqual(countBeforeDelete-1, countAfterDelete);
            }



            [Test]
            public void CanUpdateTodo()
            {
                AddNewTodoForTesting();

                ToDoTableRow updatedToDo = new ToDoTableRow();
                updatedToDo = _repo.GetById(3);

                updatedToDo.Name = "New name.";

                _repo.Update(updatedToDo);

                Assert.AreEqual("New name.", updatedToDo.Name);
                _repo.Delete(4);
            }

            public void AddNewTodoForTesting()
            {
                ToDoTableRow newToDo = new ToDoTableRow();
                newToDo.Name = "Fix code.";
                newToDo.Completed = true;
                newToDo.Note = "Some note";

                //              MockRepo repo = new MockRepo();
                _repo.Create(newToDo);
            }
        }
    }
}
