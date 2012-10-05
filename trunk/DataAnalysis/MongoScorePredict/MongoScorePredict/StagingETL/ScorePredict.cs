using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;

namespace MongoScorePredict.StagingETL
{
    public class ScorePredictDocument
    {
        public long _id;  //public int live_table_lib_id;
        public string match_type;
        public DateTime? match_time;
        public string asia_odds;
        public string home_team;
        public string away_team;

        public int? home_team_big;
        public int? away_team_big;

        public int pnn_310values;
        public int grnn_310values;
        public int grnn_home_goals;
        public int grnn_away_goals;
    }

    public class ScorePredict : IDisposable
    {
        private string mongo_collection = CommonAttribute.ScorePredict[0];
        private string mongo_db = CommonAttribute.ScorePredict[1];
        private string mongo_conn = CommonAttribute.ScorePredict[2];
        public MongoCrud<ScorePredictDocument> mongo_ScorePredict;
        public ScorePredict()
        {
            mongo_ScorePredict = new MongoCrud<ScorePredictDocument>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~ScorePredict()
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
            LiveDataETL.LiveDataETLs lde = new LiveDataETL.LiveDataETLs();
            StagingETLs ses = new StagingETLs();
            var docs = lde.mongo_LiveDataETL.QueryMongo();
            foreach (var doc in docs)
            {
                var std = ses.mongo_StagingETLs.QueryMongo().Where(e => e._id == doc._id).FirstOrDefault();
                if (std == null) continue;

                ScorePredictDocument spd = new ScorePredictDocument();
                spd._id = doc._id;
                spd.match_time = doc.match_time;
                spd.match_type = doc.match_type;
                spd.home_team = doc.home_team;
                spd.home_team_big = doc.home_team_big;
                spd.away_team_big = doc.away_team_big;
                spd.away_team = doc.away_team;
                spd.asia_odds = doc.asia_odds;

                spd.grnn_310values = std.grnn_310values;
                spd.grnn_home_goals = std.grnn_home_goals;
                spd.grnn_away_goals = std.grnn_away_goals;
                spd.pnn_310values = std.pnn_310values;

                mongo_ScorePredict.MongoDropColCreateCol.Insert(spd);
            }

            Console.WriteLine("mongo_ScorePredict->mongo->ok");
        }
    }
}
