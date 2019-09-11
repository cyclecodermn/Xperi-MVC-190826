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
    public class DapperRepo : I_ToDoRepo
    {
        private static List<ToDoTableRow> _ToDos;

        public DapperRepo()
        {
            _ToDos = new List<ToDoTableRow>();

            //            var _cn = ConfigurationManager.ConnectionStrings["ToDoDb"].ConnectionString.ToString();
        }

        public IEnumerable<ToDoTableRow> GetAll()
        {
            //_cn= "Server = myServerAddress; Database = ToDoXperi; Trusted_Connection = True;";
            using (var cn = new SqlConnection())
            {
                //cn.ConnectionString = ConfigurationManager
                //    .ConnectionStrings["ToDoDb"]
                //    .ConnectionString;

                cn.ConnectionString = "Server=localhost; Database = ToDoXperi;;Trusted_Connection = True;";

                return cn.Query<ToDoTableRow>("ToDoGetAll",
                        commandType: CommandType.StoredProcedure);
            }


        }

        public ToDoTableRow GetById(int Id)
        {
            var cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost; Database = ToDoXperi;;Trusted_Connection = True;";

            // create parameter object
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);

            return cn.Query<ToDoTableRow>(
                "ToDoGetById",
                parameters,
                commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void Create(ToDoTableRow newToDo)
        {
            var cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost; Database = ToDoXperi;;Trusted_Connection = True;";

            // create parameter object
            var parameters = new DynamicParameters();
            parameters.Add("@Id", newToDo.Id);
            parameters.Add("@Name", newToDo.Name);
            parameters.Add("@Completed", newToDo.Completed);
            parameters.Add("@Note", newToDo.Note);

            cn.Query<ToDoTableRow>(
                            "ToDoInsert",
                            parameters,
                            commandType: CommandType.StoredProcedure);

        }


        public void Update(ToDoTableRow updatedToDo)
        {
            _ToDos.RemoveAll(d => d.Id == updatedToDo.Id);
            _ToDos.Add(updatedToDo);
        }

        public void Delete(int Id)
        {
            var cn = new SqlConnection();
            cn.ConnectionString = "Server=localhost; Database = ToDoXperi;;Trusted_Connection = True;";

            // create parameter object
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Id);

            cn.Query<ToDoTableRow>(
                            "ToDoDelete",
                            parameters,
                            commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<ToDoTableRow> GetByName(string term)
        {
            return _ToDos.Where(d => d.Name.Contains(term));
        }
    }
}
