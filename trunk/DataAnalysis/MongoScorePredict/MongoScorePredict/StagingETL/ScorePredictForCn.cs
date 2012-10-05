using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;
using System.Data.Objects;

namespace MongoScorePredict.StagingETL
{
    public class ScorePredictForCnDocument
    {
        public long _id;  //public int live_table_lib_id;
        public string match_type;
        public DateTime match_time;
        public string asia_odds;
        public string home_team;
        public string away_team;

        public int pnn_310values;
        public int grnn_310values;
        public int grnn_home_goals;
        public int grnn_away_goals;
    }

    public class ScorePredictForCn : IDisposable
    {
        private string mongo_collection = CommonAttribute.ScorePredictForCn[0];
        private string mongo_db = CommonAttribute.ScorePredictForCn[1];
        private string mongo_conn = CommonAttribute.ScorePredictForCn[2];
        public MongoCrud<ScorePredictForCnDocument> mongo_ScorePredictForCn;
        public ScorePredictForCn()
        {
            mongo_ScorePredictForCn = new MongoCrud<ScorePredictForCnDocument>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ScorePredictForCn()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) { }
                disposed = true;
            }
        }
        #endregion
        public void CreateLiveCollection()
        {
            MatchAnalysis manalysis = new MatchAnalysis();
            manalysis.CommandTimeout = 0;
            manalysis.ContextOptions.LazyLoadingEnabled = true;
            manalysis.live_Table_lib.MergeOption = MergeOption.NoTracking;
            DateTime dt_now = DateTime.Now.AddDays(-1);
            var today_ma = manalysis.Live_Single.Select(e => e.Home_team_big + "," + e.Away_team_big).ToList();
            ScorePredict sp = new ScorePredict();
            var docs = sp.mongo_ScorePredict.QueryMongo();
            foreach (var doc in docs)
            {
                string match = doc.home_team_big.ToString() + "," + doc.away_team_big.ToString();
                if (today_ma.Contains(match))
                {
                    ScorePredictForCnDocument spc = new ScorePredictForCnDocument();
                    spc._id = doc._id;
                    spc.match_type = doc.match_type;
                    spc.match_time = (DateTime)doc.match_time;
                    spc.home_team = doc.home_team;
                    spc.away_team = doc.away_team;
                    spc.asia_odds = doc.asia_odds;
                    spc.pnn_310values = doc.pnn_310values;
                    spc.grnn_310values = doc.grnn_310values;
                    spc.grnn_home_goals = doc.grnn_home_goals;
                    spc.grnn_away_goals = doc.grnn_away_goals;

                    mongo_ScorePredictForCn.MongoDropColCreateCol.Insert(spc);
                }
            }

            Console.WriteLine("ScorePredictForCnDocument->mongo->ok");
        }
    }
}
