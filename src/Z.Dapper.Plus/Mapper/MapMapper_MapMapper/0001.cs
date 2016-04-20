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
    public partial class Mapper_MapMapper_MapMapper
    {
		[TestMethod]
		public void Z_Test_0001()
		{
			// Title2: MapSingle

            Helper.CleanDatabase();

			var singleBefore = new EntitySimple_Mapper { Single1 = 1, Single2 = 2, Many1 = 10, Many2 = 20, Many3 = 30, Many4 = 40};
            var single = new EntitySimple_Mapper { Single1 = 1, Single2 = 2, Many1 = 10, Many2 = 20, Many3 = 30, Many4 = 40};

            using (var cn = Helper.GetConnection())
            {
                cn.Open();

                // PreTest

                // Action
                DapperPlusManager.Entity<EntitySimple_Mapper>("0b8909b5-048e-4844-91f1-fdd8d24025d6").Map(x => x.Single1);cn.BulkInsert("0b8909b5-048e-4844-91f1-fdd8d24025d6", single);
            }

			// GET count
            int single1 = 0;
            int single2 = 0;
            int many1 = 0;
            int many2 = 0;
			int many3 = 0;
			int many4 = 0;

			int single1_Destination = 0;
            int single2_Destination = 0;
            int many1_Destination = 0;
            int many2_Destination = 0;
			int many3_Destination = 0;
			int many4_Destination = 0;

            using (var connection = Helper.GetConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
SELECT TOP 1
        [Single1] ,
        [Single2] ,
        [Many1] ,
        [Many2] ,
        [Many3] ,
        [Many4] ,
        [Single1_Destination] ,
        [Single2_Destination] ,
        [Many1_Destination] ,
        [Many2_Destination] ,
        [Many3_Destination] ,
        [Many4_Destination]
FROM    [Z.Dapper.Plus].[dbo].[EntitySimple_Mapper]";

                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        single1 = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
						single2 = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
						many1 = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
						many2 = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
						many3 = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
						many4 = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);

                        single1_Destination = reader.IsDBNull(6) ? 0 : reader.GetInt32(6);
						single2_Destination = reader.IsDBNull(7) ? 0 : reader.GetInt32(7);
						many1_Destination = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
						many2_Destination = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
						many3_Destination = reader.IsDBNull(10) ? 0 : reader.GetInt32(10);
						many4_Destination = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                    }
                }
            }

            // Test
			Assert.AreEqual(singleBefore.Single1, single1);
			Assert.AreEqual(0, single2);
			Assert.AreEqual(0, many1);
			Assert.AreEqual(0, many2);
			Assert.AreEqual(0, many3);
			Assert.AreEqual(0, many4);

			Assert.AreEqual(0, single1_Destination);
			Assert.AreEqual(0, single2_Destination);
			Assert.AreEqual(0, many1_Destination);
			Assert.AreEqual(0, many2_Destination);
			Assert.AreEqual(0, many3_Destination);
			Assert.AreEqual(0, many4_Destination);

			Assert.AreEqual(singleBefore.Single1, single.Single1);
			Assert.AreEqual(singleBefore.Single2, single.Single2);
			Assert.AreEqual(singleBefore.Many1, single.Many1);
			Assert.AreEqual(singleBefore.Many2, single.Many2);
			Assert.AreEqual(singleBefore.Many3, single.Many3);
			Assert.AreEqual(singleBefore.Many4, single.Many4);
		}
    }
}