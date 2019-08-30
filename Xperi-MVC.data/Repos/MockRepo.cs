using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xperi_MVC.data.Models;

namespace Xperi_MVC.data.Repos
{
    public class MockRepo
    {
        private static List<ToDoItem> _ToDos;

        static MockRepo()
        {
            _ToDos = new List<ToDoItem>()
            {
                new ToDoItem{Id=0, Name="(Mock Repo0) Go for a bike ride near home."},
                new ToDoItem{Id=1, Name="(Mock Repo1) Go for a bike ride far from home."},
                new ToDoItem{Id=2, Name="(Mock Repo2) Oil bike chain"},
            };
        }

            public IEnumerable<ToDoItem> GetAll()
        {
            return _ToDos;
        }

                public  ToDoItem GetById(int Id)
        {
            return _ToDos.FirstOrDefault(d => d.Id == Id);
        }

        public  void Create(ToDoItem newToDo)
        {
            if (_ToDos.Any())
            {
                newToDo.Id = _ToDos.Max(d => d.Id) + 1;
            }
            else
            {
                newToDo.Id = 0;
            }

            _ToDos.Add(newToDo);
        }


        public  void Update(ToDoItem updatedToDo)
        {
            _ToDos.RemoveAll(d => d.Id == updatedToDo.Id);
            _ToDos.Add(updatedToDo);
        }

        public  void Delete(int Id)
        {
            _ToDos.RemoveAll(d => d.Id == Id);
        }

        public IEnumerable<ToDoItem> GetByName(string term)
        {
            return _ToDos.Where(d => d.Name.Contains(term));
        }
    }
}
