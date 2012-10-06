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
        public string cn_odds;
        public string match_type;
        public DateTime match_time;
        public double asia_odds;
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

        private double ConvertOdd(string hometeam, string odds)
        {
            double Dodds = 0;
            string todds = odds.Trim();
            todds = todds.Replace("-", "");
            switch (todds)
            {
                case "0": Dodds = 0; break;
                case "0.5": Dodds = 0.5; break;
                case "0.5/1": Dodds = 0.75; break;
                case "0/0.5": Dodds = 0.25; break;
                case "1": Dodds = 1; break;
                case "1.5": Dodds = 1.5; break;
                case "1.5/2": Dodds = 1.75; break;
                case "1/1.5": Dodds = 1.25; break;
                case "12.5": Dodds = 12.5; break;
                case "13": Dodds = 13; break;
                case "14.5": Dodds = 14.5; break;
                case "2": Dodds = 2; break;
                case "2.5": Dodds = 2.5; break;
                case "2.5/3": Dodds = 2.75; break;
                case "2/2.5": Dodds = 2.25; break;
                case "3": Dodds = 3; break;
                case "3.5": Dodds = 3.5; break;
                case "3.5/4": Dodds = 3.75; break;
                case "3/3.5": Dodds = 3.25; break;
                case "4": Dodds = 4; break;
                case "4.5": Dodds = 4.5; break;
                case "4.5/5": Dodds = 4.75; break;
                case "4/4.5": Dodds = 4.25; break;
                case "5": Dodds = 5; break;
                case "5.5": Dodds = 5.5; break;
                case "5.5/6": Dodds = 5.75; break;
                case "5/5.5": Dodds = 5.25; break;
                case "6.5": Dodds = 6.5; break;
                case "6.5/7": Dodds = 6.75; break;
                case "6/6.5": Dodds = 6.25; break;
                case "7": Dodds = 7; break;
                case "7.5": Dodds = 7.5; break;
                case "7.5/8": Dodds = 7.75; break;
                case "7/7.5": Dodds = 7.25; break;
                case "8.5": Dodds = 8.5; break;
                case "8.5/9": Dodds = 8.75; break;
                case "9.5": Dodds = 9.5; break;
                case "一/半": Dodds = 1.25; break;
                case "一球": Dodds = 1; break;
                case "七/七半": Dodds = 7.25; break;
                case "七半": Dodds = 7.5; break;
                case "七半/八": Dodds = 7.75; break;
                case "七球": Dodds = 7; break;
                case "三/三半": Dodds = 3.25; break;
                case "三/半": Dodds = 3.5; break;
                case "三半": Dodds = 3.5; break;
                case "三半/四": Dodds = 3.75; break;
                case "三球": Dodds = 3; break;
                case "二/半": Dodds = 2.25; break;
                case "二半": Dodds = 2.5; break;
                case "二半/三": Dodds = 2.75; break;
                case "二球": Dodds = 2; break;
                case "五": Dodds = 5; break;
                case "五/五半": Dodds = 5.25; break;
                case "五半": Dodds = 5.5; break;
                case "五半/六": Dodds = 5.75; break;
                case "兩/兩半": Dodds = 2.25; break;
                case "兩半": Dodds = 2.5; break;
                case "兩半/三": Dodds = 2.75; break;
                case "兩球": Dodds = 2; break;
                case "八半/九": Dodds = 8.75; break;
                case "六/六半": Dodds = 6.25; break;
                case "六半": Dodds = 6.5; break;
                case "六半/七": Dodds = 6.75; break;
                case "六球": Dodds = 6; break;
                case "六球半": Dodds = 6.5; break;
                case "十二球半": Dodds = 12.5; break;
                case "半/一": Dodds = 0.75; break;
                case "半球": Dodds = 0.5; break;
                case "四/半": Dodds = 4.25; break;
                case "四/四半": Dodds = 4.25; break;
                case "四半": Dodds = 4.5; break;
                case "四半/五": Dodds = 4.75; break;
                case "四球": Dodds = 4; break;
                case "平/半": Dodds = 0.25; break;
                case "平手": Dodds = 0; break;
                case "球半": Dodds = 1.5; break;
                case "球半/二": Dodds = 1.75; break;
                case "球半/兩": Dodds = 1.75; break;
                default: Dodds = 0; break;
            }
            if (hometeam.IndexOf("*") == -1) Dodds = -1 * Dodds;
            return Dodds;
        }
        public void CreateLiveCollection()
        {
            MatchAnalysis manalysis = new MatchAnalysis();
            manalysis.CommandTimeout = 0;
            manalysis.ContextOptions.LazyLoadingEnabled = true;
            manalysis.live_Table_lib.MergeOption = MergeOption.NoTracking;
            DateTime dt_now = DateTime.Now.AddDays(-1);
            var today_ma = manalysis.Live_Single.ToLookup(e => e.Home_team_big + "," + e.Away_team_big);
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
                    spc.match_time = (DateTime)doc.match_time.Value.AddHours(8);//修正时间的问题
                    spc.home_team = doc.home_team;
                    spc.away_team = doc.away_team;
                    spc.asia_odds = ConvertOdd(doc.home_team, doc.asia_odds);
                    spc.pnn_310values = doc.pnn_310values;
                    spc.grnn_310values = doc.grnn_310values;
                    spc.grnn_home_goals = doc.grnn_home_goals;
                    spc.grnn_away_goals = doc.grnn_away_goals;


                    if (Math.Abs(spc.asia_odds) > 0.25
                        && spc.pnn_310values * spc.asia_odds > 0
                        && spc.grnn_310values * spc.asia_odds > 0
                        && spc.grnn_home_goals != spc.grnn_away_goals)
                        spc.cn_odds = "***";

                    mongo_ScorePredictForCn.MongoDropColCreateCol.Insert(spc);
                }
            }

            Console.WriteLine("ScorePredictForCnDocument->mongo->ok");
        }
    }
}
