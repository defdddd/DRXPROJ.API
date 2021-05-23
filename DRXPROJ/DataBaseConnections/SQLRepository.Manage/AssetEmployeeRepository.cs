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
                var e = new AssetEmployee
                {
                    AssetId = dt.Rows[i].Field<int>("AssetId"),
                    EmployeeId = dt.Rows[i].Field<int>("EmployeeId"),
                    From = dt.Rows[i].Field<string>("DateFrom"),
                    To = dt.Rows[i].Field<string>("DateTo"),
                    CstcNr = dt.Rows[i].Field<int>("CstcNr"),
                    EndOfLife = dt.Rows[i].Field<DateTime>("EndOfLife")
                };
                list.Add(e);
            }
            return list;
        }

        protected override string DeleteString(int id,int id2)
        {
            return $"delete from AssetEmployee where AssetId={id} AND EmployeeId={id2}";
        }

        protected override string InsertString(AssetEmployee Value)
        {
            return $"insert into AssetEmployee (AssetId,EmployeeId,DateFrom,DateTo,CstcNr,EndOfLife) values ({Value.AssetId},{Value.EmployeeId},'{Value.From}','{Value.To}',{Value.CstcNr},'{Value.EndOfLife}')";
        }

        protected override string UpdateString(AssetEmployee Value)
        {
            return $"update AssetEmployee set DateFrom='{Value.From}', DateTo='{Value.To}', CstcNr={Value.CstcNr}, EndOfLife='{Value.EndOfLife}'  where AssetId={Value.AssetId} AND EmployeeId={Value.EmployeeId}";
        }
    }
}
