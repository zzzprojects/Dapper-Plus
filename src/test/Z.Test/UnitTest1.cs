using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.Dapper.Plus;

namespace Z.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Helper.CleanDatabase();

            var single1 = new SingleMany {ColumnInt = 1};
            var single2 = new SingleMany {ColumnInt = 8};
            var single3 = new SingleMany {ColumnInt = 64};

            var many1 = new List<SingleMany> {new SingleMany {ColumnInt = 512}, new SingleMany {ColumnInt = 1024}, new SingleMany {ColumnInt = 2048}}; // 3584
            var many2 = new List<SingleMany> {new SingleMany {ColumnInt = 4096}, new SingleMany {ColumnInt = 8192}, new SingleMany {ColumnInt = 16384}}; // 28672
            var many3 = new List<SingleMany> {new SingleMany {ColumnInt = 32768}, new SingleMany {ColumnInt = 65536}, new SingleMany {ColumnInt = 131072}}; // 229376

            Helper.LinkSingleMany(single1, single2, single3, many1, many2, many3);
            Helper.InsertFromMetas(new List<string>() {"BulkInsertAll"}, single1, single2, single3, many1, many2, many3);
            Helper.UpdateFromMetas(new List<string>() {"BulkInsertAll"}, single1, single2, single3, many1, many2, many3);

            using (var cn = Helper.GetConnection())
            {
                //cn.BulkInsert(many1).ThenBulkInsert(x => x.ColumnInt);

                cn.Open();

                // PreTest
            }

            using (var cn = Helper.GetConnection())
            {
                cn.Open();

                // Action
            }


            // GET count
            int columnInt = 0;
            int columnUpdateInt = 0;
            int columnInt_Key = 0;
            int columnUpdateInt_Key = 0;

            using (var connection = Helper.GetConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT SUM(ColumnInt) FROM SingleMany";
                    columnInt = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT SUM(ColumnUpdateInt) FROM SingleMany";
                    columnUpdateInt = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT SUM(ColumnInt) FROM SingleMany_Key";
                    columnInt_Key = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT SUM(ColumnUpdateInt) FROM SingleMany_Key";
                    columnUpdateInt_Key = Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
    }
}