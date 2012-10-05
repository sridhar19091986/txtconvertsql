using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoScorePredict.MongoCurd
{
    class CommonAttribute : CommonDataLocation
    {
        public static string[] LiveDataETLs = new String[] { "LiveDataETL", db, remote };
        public static string[] HistoryDataTopDetail = new String[] { "HistoryDataTopHostDocument",
            "HistoryDataTopAwayDocument",
            "HistoryDataTopJzDocument",db, remote};
        public static string[] HistoryDataCalculate = new String[] { "HistoryDataCalculateDocument", db, remote};

        public static string[] SimulinkMatchOver = new String[] { "SimulinkMatchOver", db, remote };
        public static string[] SimulinkMatchNow = new String[] { "SimulinkMatchNow", db, remote };
        public static string[] SimulinkRbf = new String[] { "SimulinkRbf", db, remote };

        public static string[] StagingETLs = new String[] { "StagingETLs", db, remote };
        public static string[] ScorePredict = new String[] { "ScorePredict", db, remote };
        

    }
}
