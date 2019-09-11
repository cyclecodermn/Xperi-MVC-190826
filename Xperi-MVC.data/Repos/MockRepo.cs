using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xperi_MVC.data.Models;

namespace Xperi_MVC.data.Repos
{
    public class MockRepo : I_ToDoRepo
    {
        private static List<ToDoTableRow> _ToDos;

        static MockRepo()
        {
            _ToDos = new List<ToDoTableRow>()
            {
                new ToDoTableRow{Id=0, Name="(Mock Repo0) Go for a bike ride near home."},
                new ToDoTableRow{Id=1, Name="(Mock Repo1) Go for a bike ride far from home."},
                new ToDoTableRow{Id=2, Name="(Mock Repo2) Oil bike chain"},
            };
        }

        public IEnumerable<ToDoTableRow> GetAll()
        {
            return _ToDos;
        }

        public ToDoTableRow GetById(int Id)
        {
            return _ToDos.FirstOrDefault(d => d.Id == Id);
        }

        public void Create(ToDoTableRow newToDo)
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


        public void Update(ToDoTableRow updatedToDo)
        {
            _ToDos.RemoveAll(d => d.Id == updatedToDo.Id);
            _ToDos.Add(updatedToDo);
        }

        public void Delete(int Id)
        {
            _ToDos.RemoveAll(d => d.Id == Id);
        }

        public IEnumerable<ToDoTableRow> GetByName(string term)
        {
            return _ToDos.Where(d => d.Name.Contains(term));
        }
    }
}
