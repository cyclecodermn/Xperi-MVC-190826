using System.Collections.Generic;
using Xperi_MVC.data.Models;

namespace Xperi_MVC.data.Repos
{
    public interface I_ToDoRepo
    {
        void Create(ToDoTableRow newToDo);
        void Delete(int Id);
        IEnumerable<ToDoTableRow> GetAll();
        ToDoTableRow GetById(int Id);
        IEnumerable<ToDoTableRow> GetByName(string term);
        void Update(ToDoTableRow updatedToDo);
    }
}