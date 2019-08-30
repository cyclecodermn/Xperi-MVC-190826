using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xperi_MVC.data.Models;

namespace Xperi_MVC.data.Repos
{
    public class DapperRepo
    {
        private static List<ToDoItem> _ToDos;

        static DapperRepo()
        {

            _ToDos = new List<ToDoItem>();

            var _cn = ConfigurationManager.ConnectionStrings["ToDoDb"].ConnectionString.ToString();

        }

            public IEnumerable<ToDoItem> GetAll()
        {
            //_cn= "Server = myServerAddress; Database = ToDoXperi; Trusted_Connection = True;";
                using (var cn = new SqlConnection())
                {
                //cn.ConnectionString = ConfigurationManager
                //    .ConnectionStrings["ToDoDb"]
                //    .ConnectionString;

                cn.ConnectionString = "Server = myServerAddress; Database = ToDoXperi; Trusted_Connection = True;";

                return cn.Query<ToDoItem>("MovieSelectAll",
                        commandType: CommandType.StoredProcedure);
                }


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
