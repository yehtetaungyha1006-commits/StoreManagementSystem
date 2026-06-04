using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalproject
{
    internal class DBConnect
    {
        public static string ProductConn =
            @"Data Source=YEHTETT\SQLEXPRESS;
              Database=ProductDB;
              Integrated Security=SSPI";

        public static string CustomerConn =
            @"Data Source=YEHTETT\SQLEXPRESS;
              Database=CustomerDB;
              Integrated Security=SSPI";

        public static string OrderConn =
            @"Data Source=YEHTETT\SQLEXPRESS;
              Database=OrderDB;
              Integrated Security=SSPI";
    }
}
