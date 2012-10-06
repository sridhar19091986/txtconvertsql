using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoScorePredict.MongoCurd
{
    //数据分割成 采集层，共享层，应用层

    class CommonDataLocation
    {


        protected static string db = "ScorePredictCn";


        protected static string remote = "mongodb://localhost/?safe=true";

        //protected static string sqlconn = "Data Source=localhost;Initial Catalog=TcpDbContext;Integrated Security=True;";

        //protected static string remote = "mongodb://192.168.4.249/?safe=true";


        //protected static string sqlconn = "Data Source=192.168.4.249;Initial Catalog=TcpDbContextab_TEST;User ID=sa;Password=hantele123;MultipleActiveResultSets=True";
    }
}
