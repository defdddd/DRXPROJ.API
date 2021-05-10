using DRXPROJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.DataBaseConnections.SQLRepository.Manage
{
    public class CostcentersRepository : SQLRepository<Costcenters>
    {
        public override string SqlText => "select * from Costcenters";

        protected override List<Costcenters> ConvertAdapter(DataTable dt)
        {
            var list = new List<Costcenters>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var e = new Costcenters();
                e.Nr = dt.Rows[i].Field<int>("Nr");
                e.Name = dt.Rows[i].Field<string>("Name");
                e.EmployeeId = dt.Rows[i].Field<int>("EmployeeId");
                e.DeleteFlag = dt.Rows[i].Field<bool>("DaleteFlag");
                list.Add(e);
            }
            return list;
        }

        protected override string DeleteString(int id, int id2)
        {
            return $"delete from Costcenters where Id={id}";
        }

        protected override string InsertString(Costcenters Value)
        {
            return $"insert into Costcenters (EmployeeId, Name, DeleteFlag) values ('{Value.EmployeeId}','{Value.Name}','{Value.DeleteFlag}')";
        }

        protected override string UpdateString(Costcenters Value)
        {
            return $"update Costcenters set EmployeeId='{Value.EmployeeId}', Name='{Value.Name}', DeleteFlag='{Value.DeleteFlag}' where Nr={Value.Nr}";
        }
    }
}
