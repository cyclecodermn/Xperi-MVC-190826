using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xperi_MVC.data.Models;
using Xperi_MVC.data.Repos;

namespace Xperi_MVC_190826.Controllers
{
    public class ToDoController: Controller
    {
        private static DapperRepo _repo = new DapperRepo();

        public ActionResult ShowAllToDos()
        {
            List<ToDoItem> AllToDos = new List<ToDoItem>();
            AllToDos = _repo.GetAll().ToList();

            return View(AllToDos);
        }
    }


}