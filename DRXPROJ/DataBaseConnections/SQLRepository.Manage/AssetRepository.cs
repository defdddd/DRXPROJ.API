using DRXPROJ.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DRXPROJ.DataBaseConnections.SQLRepository.Manage
{
    public class AssetRepository : SQLRepository<Asset>
    {
        public override string SqlText => "select * from Asset";

        protected override List<Asset> ConvertAdapter(DataTable dt)
        {
            var list = new List<Asset>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var e = new Asset();
                e.Id= dt.Rows[i].Field<int>("Id");
                e.Name = dt.Rows[i].Field<string>("Name");
                e.Description = dt.Rows[i].Field<string>("Description");
                e.Date = dt.Rows[i].Field<DateTime>("Date");
                e.CstcNr = dt.Rows[i].Field<int>("CstcNr");
                list.Add(e);
            }
            return list;
        }

        protected override string DeleteString(int id, int id2)
        {
            return $"delete from Asset where Id='{id}'";
        }

        protected override string InsertString(Asset Value)
        {
            return $"insert into Asset (Name,Description,Date,CstcNr) values ('{Value.Name}','{Value.Description}','{Value.Date}',{Value.CstcNr})";
        }

        protected override string UpdateString(Asset Value)
        {
            return $"update Asset set Name='{Value.Name}', Description='{Value.Description}', Date='{Value.Date}', CstcNr='{Value.CstcNr}' where Id={Value.Id}";
        }
    }
}
