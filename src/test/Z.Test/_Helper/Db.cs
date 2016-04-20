using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Z.Dapper.Plus;

namespace Z.Test
{
    public static class Helper
    {
        static Helper()
        {
            DapperPlusManager.Entity<SingleMany>(null).Map(x => new {x.ColumnInt, x.ColumnUpdateInt}).Output(x => x.ID);
            DapperPlusManager.Entity<SingleMany>("key").Table("SingleMany_Key").Map(x => new {x.ColumnInt, x.ColumnUpdateInt}).Output(x => x.ID);
        }

        public static void CleanDatabase()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "TRUNCATE TABLE SingleMany";
                    command.ExecuteNonQuery();

                    command.CommandText = "TRUNCATE TABLE SingleMany_Key";
                    command.ExecuteNonQuery();

                    command.CommandText = "TRUNCATE TABLE EntitySimple_Mapper";
                    command.ExecuteNonQuery();
                }
            }
        }

        public static DbConnection GetConnection()
        {
            return new SqlConnection(My.ConnectionStrings.DapperPlusConnection);
        }

        public static void InsertFromMetas(List<string> metas, SingleMany single1, SingleMany single2, SingleMany single3, List<SingleMany> many1, List<SingleMany> many2, List<SingleMany> many3)
        {
            var count = 0;

            if (metas.Contains("BulkInsertAll") || metas.Contains("BulkInsert1"))
            {
                using (var connection = GetConnection())
                {
                    connection.Open();

                    var list = new List<SingleMany>();
                    list.Add(single1);
                    list.AddRange(many1);
                    list.AddRange(many1.Select(x => x.Single1));
                    list.AddRange(many2.Select(x => x.Single1));
                    list.AddRange(many3.Select(x => x.Single1));
                    list.AddRange(many1.SelectMany(y => y.Many1));
                    list.AddRange(many2.SelectMany(y => y.Many1));
                    list.AddRange(many3.SelectMany(y => y.Many1));

                    connection.BulkInsert(list);
                    connection.BulkInsert("key", list);
                }

                count += single1.ColumnInt + many1.Sum(x => x.ColumnInt);
            }

            if (metas.Contains("BulkInsertAll") || metas.Contains("BulkInsert2"))
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    //connection.BulkInsert(single2).BulkInsert(many2)
                    //    .AlsoBulkInsert(x => x.Single1).AlsoBulkInsert(x => x.Single2).AlsoBulkInsert(x => x.Single3)
                    //    .AlsoBulkInsert(x => x.Many1).AlsoBulkInsert(x => x.Many2).AlsoBulkInsert(x => x.Many3);
                    //connection.BulkInsert("key", single2).BulkInsert("key", many2)
                    //.AlsoBulkInsert("key", x => x.Single1).AlsoBulkInsert("key", x => x.Single2).AlsoBulkInsert("key", x => x.Single3)
                    //.AlsoBulkInsert("key", x => x.Many1).AlsoBulkInsert("key", x => x.Many2).AlsoBulkInsert("key", x => x.Many3);

                    var list = new List<SingleMany>();
                    list.Add(single2);
                    list.AddRange(many2);
                    list.AddRange(many1.Select(x => x.Single2));
                    list.AddRange(many2.Select(x => x.Single2));
                    list.AddRange(many3.Select(x => x.Single2));
                    list.AddRange(many1.SelectMany(y => y.Many2));
                    list.AddRange(many2.SelectMany(y => y.Many2));
                    list.AddRange(many3.SelectMany(y => y.Many2));

                    connection.BulkInsert(list);
                    connection.BulkInsert("key", list);
                }

                count += single2.ColumnInt + many2.Sum(x => x.ColumnInt);
            }

            if (metas.Contains("BulkInsertAll") || metas.Contains("BulkInsert3"))
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    //connection.BulkInsert(single3).BulkInsert(many3)
                    //    .AlsoBulkInsert(x => x.Single1).AlsoBulkInsert(x => x.Single2).AlsoBulkInsert(x => x.Single3)
                    //    .AlsoBulkInsert(x => x.Many1).AlsoBulkInsert(x => x.Many2).AlsoBulkInsert(x => x.Many3);
                    //connection.BulkInsert("key", single3).BulkInsert("key", many3)
                    //.AlsoBulkInsert("key", x => x.Single1).AlsoBulkInsert("key", x => x.Single2).AlsoBulkInsert("key", x => x.Single3)
                    //.AlsoBulkInsert("key", x => x.Many1).AlsoBulkInsert("key", x => x.Many2).AlsoBulkInsert("key", x => x.Many3);
                    // 
                    var list = new List<SingleMany>();
                    list.Add(single3);
                    list.AddRange(many3);
                    list.AddRange(many1.Select(x => x.Single3));
                    list.AddRange(many2.Select(x => x.Single3));
                    list.AddRange(many3.Select(x => x.Single3));
                    list.AddRange(many1.SelectMany(y => y.Many3));
                    list.AddRange(many2.SelectMany(y => y.Many3));
                    list.AddRange(many3.SelectMany(y => y.Many3));

                    connection.BulkInsert(list);
                    connection.BulkInsert("key", list);
                }

                count += single3.ColumnInt + many3.Sum(x => x.ColumnInt);
            }

            //using (var connection = GetConnection())
            //{
            //    connection.Open();

            //    using (var command = connection.CreateCommand())
            //    {
            //        command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnInt) FROM SingleMany), 0)";
            //        Assert.AreEqual(count, Convert.ToInt32(command.ExecuteScalar()));

            //        command.CommandText = "SELECT ISNULL((SELECT SUM(ColumnInt) FROM SingleMany_Key), 0)";
            //        Assert.AreEqual(count, Convert.ToInt32(command.ExecuteScalar()));
            //    }
            //}
        }

        public static void UpdateFromMetas(List<string> metas, SingleMany single1, SingleMany single2, SingleMany single3, List<SingleMany> many1, List<SingleMany> many2, List<SingleMany> many3)
        {
            if (metas.Contains("UpdateValueAll") || metas.Contains("UpdateValue1"))
            {
                single1.ColumnUpdateInt = single1.ColumnInt;
                many1.ForEach(x => x.ColumnUpdateInt = x.ColumnInt);

                many1.ForEach(x => x.Many1.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));
                many2.ForEach(x => x.Many1.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));
                many3.ForEach(x => x.Many1.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));

                many1.ForEach(x => x.Single1.ColumnUpdateInt = x.Single1.ColumnInt);
                many2.ForEach(x => x.Single1.ColumnUpdateInt = x.Single1.ColumnInt);
                many3.ForEach(x => x.Single1.ColumnUpdateInt = x.Single1.ColumnInt);
            }

            if (metas.Contains("UpdateValueAll") || metas.Contains("UpdateValue2"))
            {
                single2.ColumnUpdateInt = single2.ColumnInt;
                many2.ForEach(x => x.ColumnUpdateInt = x.ColumnInt);

                many1.ForEach(x => x.Many2.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));
                many2.ForEach(x => x.Many2.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));
                many3.ForEach(x => x.Many2.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));

                many1.ForEach(x => x.Single2.ColumnUpdateInt = x.Single2.ColumnInt);
                many2.ForEach(x => x.Single2.ColumnUpdateInt = x.Single2.ColumnInt);
                many3.ForEach(x => x.Single2.ColumnUpdateInt = x.Single2.ColumnInt);
            }

            if (metas.Contains("UpdateValueAll") || metas.Contains("UpdateValue3"))
            {
                single3.ColumnUpdateInt = single3.ColumnInt;
                many3.ForEach(x => x.ColumnUpdateInt = x.ColumnInt);

                many1.ForEach(x => x.Many3.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));
                many2.ForEach(x => x.Many3.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));
                many3.ForEach(x => x.Many3.ForEach(y => y.ColumnUpdateInt = y.ColumnInt));

                many1.ForEach(x => x.Single3.ColumnUpdateInt = x.Single3.ColumnInt);
                many2.ForEach(x => x.Single3.ColumnUpdateInt = x.Single3.ColumnInt);
                many3.ForEach(x => x.Single3.ColumnUpdateInt = x.Single3.ColumnInt);
            }
        }

        public static void LinkSingleMany(SingleMany single1, SingleMany single2, SingleMany single3, List<SingleMany> many1, List<SingleMany> many2, List<SingleMany> many3)
        {
            single1.Single1 = single1;
            single1.Single2 = single2;
            single1.Single3 = single3;

            single2.Single1 = single1;
            single2.Single2 = single2;
            single2.Single3 = single3;

            single3.Single1 = single1;
            single3.Single2 = single2;
            single3.Single3 = single3;

            single1.Many1 = many1;
            single1.Many2 = many2;
            single1.Many3 = many3;

            single2.Many1 = many1;
            single2.Many2 = many2;
            single2.Many3 = many3;

            single3.Many1 = many1;
            single3.Many2 = many2;
            single3.Many3 = many3;

            many1.ForEach(x => x.Single1 = new SingleMany {ColumnInt = single1.ColumnInt});
            many1.ForEach(x => x.Single2 = new SingleMany {ColumnInt = single2.ColumnInt});
            many1.ForEach(x => x.Single3 = new SingleMany {ColumnInt = single3.ColumnInt});

            many2.ForEach(x => x.Single1 = new SingleMany {ColumnInt = single1.ColumnInt});
            many2.ForEach(x => x.Single2 = new SingleMany {ColumnInt = single2.ColumnInt});
            many2.ForEach(x => x.Single3 = new SingleMany {ColumnInt = single3.ColumnInt});

            many3.ForEach(x => x.Single1 = new SingleMany {ColumnInt = single1.ColumnInt});
            many3.ForEach(x => x.Single2 = new SingleMany {ColumnInt = single2.ColumnInt});
            many3.ForEach(x => x.Single3 = new SingleMany {ColumnInt = single3.ColumnInt});

            many1.ForEach(x => x.Many1 = new List<SingleMany> {new SingleMany {ColumnInt = single1.ColumnInt}});
            many1.ForEach(x => x.Many2 = new List<SingleMany> {new SingleMany {ColumnInt = single2.ColumnInt}});
            many1.ForEach(x => x.Many3 = new List<SingleMany> {new SingleMany {ColumnInt = single3.ColumnInt}});

            many2.ForEach(x => x.Many1 = new List<SingleMany> {new SingleMany {ColumnInt = single1.ColumnInt}});
            many2.ForEach(x => x.Many2 = new List<SingleMany> {new SingleMany {ColumnInt = single2.ColumnInt}});
            many2.ForEach(x => x.Many3 = new List<SingleMany> {new SingleMany {ColumnInt = single3.ColumnInt}});

            many3.ForEach(x => x.Many1 = new List<SingleMany> {new SingleMany {ColumnInt = single1.ColumnInt}});
            many3.ForEach(x => x.Many2 = new List<SingleMany> {new SingleMany {ColumnInt = single2.ColumnInt}});
            many3.ForEach(x => x.Many3 = new List<SingleMany> {new SingleMany {ColumnInt = single3.ColumnInt}});


            //many1.ForEach(x => x.Many1 = new List<SingleMany>() {new SingleMany() {ColumnInt = 262576}});
            //many1.ForEach(x => x.Many2 = new List<SingleMany>() {new SingleMany() {ColumnInt = 525152}});
            //many1.ForEach(x => x.Many3 = new List<SingleMany>() {new SingleMany() {ColumnInt = 1050304}});

            //many2.ForEach(x => x.Many1 = new List<SingleMany>() {new SingleMany() {ColumnInt = 2100608}});
            //many2.ForEach(x => x.Many2 = new List<SingleMany>() {new SingleMany() {ColumnInt = 4201216}});
            //many2.ForEach(x => x.Many3 = new List<SingleMany>() {new SingleMany() {ColumnInt = 8402432}});

            //many3.ForEach(x => x.Many1 = new List<SingleMany>() {new SingleMany() {ColumnInt = 16804864}});
            //many3.ForEach(x => x.Many2 = new List<SingleMany>() {new SingleMany() {ColumnInt = 33609728}});
            //many3.ForEach(x => x.Many3 = new List<SingleMany>() {new SingleMany() {ColumnInt = 67219456}});

            //many1.ForEach(x => x.Single1 = new SingleMany() {ColumnInt = 1});
            //many1.ForEach(x => x.Single2 = new SingleMany() {ColumnInt = 2});
            //many1.ForEach(x => x.Single3 = new SingleMany() {ColumnInt = 3});

            //many2.ForEach(x => x.Single1 = new SingleMany() {ColumnInt = 4});
            //many2.ForEach(x => x.Single2 = new SingleMany() {ColumnInt = 5});
            //many2.ForEach(x => x.Single3 = new SingleMany() {ColumnInt = 6});

            //many3.ForEach(x => x.Single1 = new SingleMany() {ColumnInt = 7});
            //many3.ForEach(x => x.Single2 = new SingleMany() {ColumnInt = 8});
            //many3.ForEach(x => x.Single3 = new SingleMany() {ColumnInt = 9});
        }
    }
}