/*
 * 
 * 第1步
 * 
 * 所有的列都采用统一的id，用列存储表示
 * 
 * 1.今天的比赛数据
 * 
 * 2.由主队，客队，比赛类型约束，生成近20场比赛的数据，因此，需要开始历史数据的收集
 * 
 * 
 * 需要支持历史数据和即时数据
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;
using System.Data.Objects;

namespace MongoScorePredict.LiveDataETL
{
    //由于只保存在mongodb，{ get; set; }不需要
    public class LiveDataETLsDocument
    {
        public long _id;  //public int live_table_lib_id;
        public int live;//是否是即时数据
        public int? html_position;
        public int? home_team_big;
        public int? away_team_big;
        public string match_type;
        public DateTime? match_time;
        public string asia_odds;
        public string home_team;
        public string away_team;
        public int? home_red_card;
        public int? away_red_card;
        public int? full_home_goals;
        public int? full_away_goals;
        public int? half_home_goals;
        public int? half_away_goals;
    }

    public class LiveDataETLs : IDisposable
    {
        private string mongo_collection = CommonAttribute.LiveDataETLs[0];
        private string mongo_db = CommonAttribute.LiveDataETLs[1];
        private string mongo_conn = CommonAttribute.LiveDataETLs[2];
        public MongoCrud<LiveDataETLsDocument> mongo_LiveDataETL;
        public LiveDataETLs()
        {
            mongo_LiveDataETL = new MongoCrud<LiveDataETLsDocument>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~LiveDataETLs()
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
            var today_ma = manalysis.live_Table_lib.Where(e => e.match_time.Value > dt_now);
            foreach (var ma in today_ma)
            {
                LiveDataETLsDocument ldata = new LiveDataETLsDocument();
                ldata._id = ma.live_table_lib_id;
                ldata.live = 1;
                ldata.html_position = ma.html_position;
                ldata.home_team_big = ma.home_team_big;
                ldata.away_team_big = ma.away_team_big;
                ldata.match_type = ma.match_type;
                ldata.match_time = ma.match_time;
                ldata.asia_odds = ma.status;
                ldata.home_team = ma.home_team;
                ldata.away_team = ma.away_team;
                ldata.home_red_card = ma.home_red_card;
                ldata.away_red_card = ma.away_red_card;
                ldata.full_home_goals = ma.full_home_goals;
                ldata.full_away_goals = ma.full_away_goals;
                ldata.half_home_goals = ma.half_home_goals;
                ldata.half_away_goals = ma.half_away_goals;
                mongo_LiveDataETL.MongoCol.Insert(ldata);
            }
            Console.WriteLine("LiveDataETLDocument->mongo->ok");
        }
        public void CreateResultCollection(int overday)
        {
            MatchAnalysis manalysis = new MatchAnalysis();
            manalysis.CommandTimeout = 0;
            manalysis.ContextOptions.LazyLoadingEnabled = true;
            manalysis.live_Table_lib.MergeOption = MergeOption.NoTracking;
            DateTime dt_now = DateTime.Now.AddDays(-1*overday);
            var result_ma = manalysis.result_tb_lib.Where(e => e.match_time.Value > dt_now);
            foreach (var ma in result_ma)
            {
                LiveDataETLsDocument ldata = new LiveDataETLsDocument();
                ldata._id = ma.result_tb_lib_id;
                ldata.live = 0;
                ldata.html_position = ma.html_position;
                ldata.home_team_big = ma.home_team_big;
                ldata.away_team_big = ma.away_team_big;
                ldata.match_type = ma.match_type;
                ldata.match_time = ma.match_time;
                ldata.asia_odds = ma.odds;
                ldata.home_team = ma.home_team;
                ldata.away_team = ma.away_team;
                ldata.home_red_card = ma.home_red_card;
                ldata.away_red_card = ma.away_red_card;
                ldata.full_home_goals = ma.full_home_goals;
                ldata.full_away_goals = ma.full_away_goals;
                ldata.half_home_goals = ma.half_home_goals;
                ldata.half_away_goals = ma.half_away_goals;
                mongo_LiveDataETL.MongoCol.Insert(ldata);
            }
            Console.WriteLine("LiveDataETLDocument->mongo->ok");
        }
    }
}
