using DRXPROJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.DataBaseConnections.SQLRepository.Manage
{
    public class EmployeeRepository : SQLRepository<Employee>
    {
        public override string SqlText => "select * from Employee";

        protected override List<Employee> ConvertAdapter(DataTable dt)
        {
            var list = new List<Employee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var e = new Employee();
                e.Id = dt.Rows[i].Field<int>("Id");
                e.Password = dt.Rows[i].Field<string>("Password");
                e.UserName = dt.Rows[i].Field<string>("UserName");
                e.Name = dt.Rows[i].Field<string>("Name");
                e.CostCenter = dt.Rows[i].Field<string>("CostCenter");
                e.ManagersName = dt.Rows[i].Field<string>("ManagersName");
                e.IsManager = dt.Rows[i].Field<bool>("IsManager");
                list.Add(e);
            }
            return list;
        }

        protected override string DeleteString(int id, int id2)
        {
            return $"delete from Employee where Id={id}";
        }

        protected override string InsertString(Employee Value)
        {
            return $"insert into Employee (UserName,Password,Name,CostCenter,ManagersName,IsManager) values ('{Value.UserName}','{Value.Password}','{Value.Name}','{Value.CostCenter}','{Value.ManagersName}','{Value.IsManager}')";
        }

        protected override string UpdateString(Employee Value)
        {
            return $"update Employee set Name='{Value.Name}', CostCenter='{Value.CostCenter}', ManagersName='{Value.ManagersName}', IsManager='{Value.IsManager}' where Id={Value.Id}";
        }
    }
}
