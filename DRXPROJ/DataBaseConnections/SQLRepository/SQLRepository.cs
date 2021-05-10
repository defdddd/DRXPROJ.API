using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DRXPROJ.DataBaseConnections.SQLRepository
{
    public abstract class SQLRepository<T>
    {
        private static readonly string con = @"Data Source=DESKTOP-N80BQR0;Initial Catalog=DRX;Integrated Security=True;Pooling=False";
        private SqlDataAdapter da;
        private DataTable ds;
        public abstract string SqlText { get; }
        protected abstract List<T> ConvertAdapter(DataTable dt);
        protected abstract string InsertString(T Value);
        protected abstract string UpdateString(T Value);
        protected abstract string DeleteString(int id, int id2);
        public List<T> GetAll()
        {
            ds = new DataTable();
            using (var connection = new SqlConnection(con))
            {
                da = new SqlDataAdapter(SqlText, connection);
                da.Fill(ds);
            }
            return ConvertAdapter(ds);
        }
        public void Insert(T value)
        {
            string insertString = InsertString(value);

            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                using (var cmd = new SqlCommand(insertString, connection))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public void Delete(int id, [Optional] int id2)
        {
            string deleteString = DeleteString(id,id2);

            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                using (var cmd = new SqlCommand(deleteString, connection))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
        public void Update(T value)
        {
            string updateString = UpdateString(value);

            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                using (var cmd = new SqlCommand(updateString, connection))
                {
                    cmd.ExecuteNonQuery();
                }

            }
        }
    }

}
