using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Z.Dapper.Plus;

namespace Z.Test
{
    public partial class BulkAction_BulkMerge_SingleMixedSelector
    {
		[TestMethod]
		public void Z_Test_0183()
		{
            Helper.CleanDatabase();

            var single1 = new SingleMany {ColumnInt = 1};
            var single2 = new SingleMany {ColumnInt = 8};
            var single3 = new SingleMany {ColumnInt = 64};

            var many1 = new List<SingleMany> {new SingleMany {ColumnInt = 512}, new SingleMany {ColumnInt = 1024}, new SingleMany {ColumnInt = 2048}};
            var many2 = new List<SingleMany> {new SingleMany {ColumnInt = 4096}, new SingleMany {ColumnInt = 8192}, new SingleMany {ColumnInt = 16384}};
            var many3 = new List<SingleMany> {new SingleMany {ColumnInt = 32768}, new SingleMany {ColumnInt = 65536}, new SingleMany {ColumnInt = 131072}};

            Helper.LinkSingleMany(single1, single2, single3, many1, many2, many3);
            Helper.InsertFromMetas("BulkInsert2;BulkInsert3;UpdateValue2;UpdateValue3".Split(';').ToList(), single1, single2, single3, many1, many2, many3);
            Helper.UpdateFromMetas("BulkInsert2;BulkInsert3;UpdateValue2;UpdateValue3".Split(';').ToList(), single1, single2, single3, many1, many2, many3);

            // GET count before
            int columnInt_before = 0;
            int columnUpdateInt_before = 0;
            int columnInt_Key_before = 0;
            int columnUpdateInt_Key_before = 0;

            using (var connection = Helper.GetConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnInt) FROM SingleMany), 0)";
                    columnInt_before = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnUpdateInt) FROM SingleMany), 0)";
                    columnUpdateInt_before = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnInt) FROM SingleMany_Key), 0)";
                    columnInt_Key_before = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnUpdateInt) FROM SingleMany_Key), 0)";
                    columnUpdateInt_Key_before = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            using (var cn = Helper.GetConnection())
            {
                cn.Open();

                // PreTest

                // Action
                cn.BulkMerge("key", single1, x => x.Many2, x => x.Single2);
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
                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnInt) FROM SingleMany), 0)";
                    columnInt = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnUpdateInt) FROM SingleMany), 0)";
                    columnUpdateInt = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnInt) FROM SingleMany_Key), 0)";
                    columnInt_Key = Convert.ToInt32(command.ExecuteScalar());

                    command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnUpdateInt) FROM SingleMany_Key), 0)";
                    columnUpdateInt_Key = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            // Test
			Assert.AreEqual(columnInt_before, columnInt);
					Assert.AreEqual(columnUpdateInt_before, columnUpdateInt);
					Assert.AreEqual(columnInt_Key_before + single1.ColumnInt, columnInt_Key);
					Assert.AreEqual(many2.Sum(x => x.ColumnInt) + single2.ColumnInt, columnUpdateInt_Key);
		}
    }
}