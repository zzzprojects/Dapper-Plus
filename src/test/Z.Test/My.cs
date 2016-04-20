using System.Configuration;

namespace Z.Test
{
    public static class My
    {
        public class ConnectionStrings
        {
            public static string DapperPlusConnection = ConfigurationManager.ConnectionStrings["DapperPlusConnection"].ConnectionString;
        }
    }
}