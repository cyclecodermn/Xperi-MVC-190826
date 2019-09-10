using System.Collections.Generic;
using Xperi_MVC.data.Models;

namespace Xperi_MVC.data.Repos
{
    public interface I_ToDoRepo
    {
        void Create(ToDoItem newToDo);
        void Delete(int Id);
        IEnumerable<ToDoItem> GetAll();
        ToDoItem GetById(int Id);
        IEnumerable<ToDoItem> GetByName(string term);
        void Update(ToDoItem updatedToDo);
    }
}