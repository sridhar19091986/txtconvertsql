using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;

namespace MongoScorePredict.DataMingForMatlab
{
    public class SimulinkMatchNowDocument
    {
        public long _id;
        public int Analysis_result_id;
        public DateTime? match_time;
        public string match_type;
        public string home_team;
        public string away_team;

        public string status;
        public double? Dodds;
        public int? Home_w;
        public int? Home_d;
        public int? Home_l;
        public double? Home_goals;
        public double? Away_goals;
        public double? Cross_goals;
        public double? Fit_win_loss;
        public int? Recent_scores;
        public int? Recent_2scores;
        public int? Recent_3scores;
        public int? Recent_4scores;
        public int? Recent_5scores;
        public int? Recent_6scores;

        public int? Lottery_Ticket;
        public int? Full_home_goals;
        public int? Full_away_goals;
        public int? Full_total_goals;
        public int? Full_diff_goals;
    }

    public class SimulinkMatchNow
    {
        private string mongo_collection = CommonAttribute.SimulinkMatchNow[0];
        private string mongo_db = CommonAttribute.SimulinkMatchNow[1];
        private string mongo_conn = CommonAttribute.SimulinkMatchNow[2];

        public MongoCrud<SimulinkMatchNowDocument> mongocrud;

        public SimulinkMatchNow()
        {
            mongocrud = new MongoCrud<SimulinkMatchNowDocument>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SimulinkMatchNow()
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

    }
}
