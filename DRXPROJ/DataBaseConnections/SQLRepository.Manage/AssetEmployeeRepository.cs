using DRXPROJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.DataBaseConnections.SQLRepository.Manage
{
    public class AssetEmployeeRepository : SQLRepository<AssetEmployee>
    {
        public override string SqlText => "select * from AssetEmployee";

        protected override List<AssetEmployee> ConvertAdapter(DataTable dt)
        {
            var list = new List<AssetEmployee>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var e = new AssetEmployee();
                e.AssetId= dt.Rows[i].Field<int>("AssetId");
                e.EmployeeId = dt.Rows[i].Field<int>("EmployeeId");
                e.From = dt.Rows[i].Field<string>("DateFrom");
                e.To = dt.Rows[i].Field<string>("DateTo");
                e.CstcNr = dt.Rows[i].Field<int>("CstcNr");
                e.EndOfLife = dt.Rows[i].Field<DateTime>("EndOfLife");
                list.Add(e);
            }
            return list;
        }

        protected override string DeleteString(int id,int id2)
        {
            return $"delete from AssetEmployee where Id={id}";
        }

        protected override string InsertString(AssetEmployee Value)
        {
            return $"insert into AssetEmployee (AssetId,EmployeeId,DateFrom,DateTo,CstcNr,EndOfLife) values ({Value.AssetId},{Value.EmployeeId},'{Value.From}','{Value.To}',{Value.CstcNr},'{Value.EndOfLife})";
        }

        protected override string UpdateString(AssetEmployee Value)
        {
            return $"update AssetEmployee set DateFrom='{Value.From}', DateTo='{Value.To}', CstcNr={Value.CstcNr} where AssetId={Value.AssetId} AND EmployeeId={Value.EmployeeId}";
        }
    }
}
