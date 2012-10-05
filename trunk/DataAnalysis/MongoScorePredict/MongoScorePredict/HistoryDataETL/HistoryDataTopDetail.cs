/*
 * 
 * 第2步
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;
using System.Data.Objects;
using MongoScorePredict.LiveDataETL;

namespace MongoScorePredict.HistoryDataETL
{
    public class HistoryDataETLs
    {
        public long _id;  //取比赛结果库的id
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
        public string win_loss_big;
    }
    public class HistoryDataTopDetailDocument
    {
        public long _id;//取当日比赛库的id
        public string match_type;
        public int match_count;
        public List<HistoryDataETLs> history_data_etl;
    }
    public class HistoryDataTopHostDocument : HistoryDataTopDetailDocument
    {
        public string home_team;
        public int? home_team_big;
    }
    public class HistoryDataTopAwayDocument : HistoryDataTopDetailDocument
    {
        public string away_team;
        public int? away_team_big;
    }
    public class HistoryDataTopJzDocument : HistoryDataTopDetailDocument
    {
        public string home_team;
        public string away_team;
        public int? home_team_big;
        public int? away_team_big;
    }
    public class HistoryDataTopDetail : IDisposable
    {
        private string mongo_collection_host = CommonAttribute.HistoryDataTopDetail[0];
        private string mongo_collection_away = CommonAttribute.HistoryDataTopDetail[1];
        private string mongo_collection_jz = CommonAttribute.HistoryDataTopDetail[2];
        private string mongo_db = CommonAttribute.HistoryDataTopDetail[3];
        private string mongo_conn = CommonAttribute.HistoryDataTopDetail[4];
        public MongoCrud<HistoryDataTopHostDocument> mongo_HistoryDataTopHostDocument;
        public MongoCrud<HistoryDataTopAwayDocument> mongo_HistoryDataTopAwayDocument;
        public MongoCrud<HistoryDataTopJzDocument> mongo_HistoryDataTopJzDocument;
        public HistoryDataTopDetail()
        {
            mongo_HistoryDataTopHostDocument = new MongoCrud<HistoryDataTopHostDocument>(mongo_conn, mongo_db, mongo_collection_host);
            mongo_HistoryDataTopAwayDocument = new MongoCrud<HistoryDataTopAwayDocument>(mongo_conn, mongo_db, mongo_collection_away);
            mongo_HistoryDataTopJzDocument = new MongoCrud<HistoryDataTopJzDocument>(mongo_conn, mongo_db, mongo_collection_jz);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~HistoryDataTopDetail()
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


        //创建这个Top表需要遍历即时数据，从mongodb提取比较理想。
        public int take_match_num = 20;

        public void CreateCollection()
        {
            MatchAnalysis manalysis = new MatchAnalysis();
            manalysis.CommandTimeout = 0;
            manalysis.ContextOptions.LazyLoadingEnabled = true;
            manalysis.live_Table_lib.MergeOption = MergeOption.NoTracking;
            ILookup<string, result_tb_lib> lookup_matchType = manalysis.result_tb_lib.ToLookup(e => e.match_type);
            LiveDataETLs ldata = new LiveDataETLs();
            foreach (var today_m in ldata.mongo_LiveDataETL.QueryMongo())
            {
                CreateHostCollection(lookup_matchType, today_m);
                CreateAwayCollection(lookup_matchType, today_m);
                CreateJzCollection(lookup_matchType, today_m);
            }
            Console.WriteLine("HistoryDataTopDetail->mongo->ok");
        }

        private void CreateHostCollection(ILookup<string, result_tb_lib> lookup_matchType, LiveDataETLsDocument today_m)
        {
            HistoryDataTopHostDocument hdataHost = new HistoryDataTopHostDocument();
            hdataHost._id = today_m._id;
            //取当日比赛的主队
            hdataHost.home_team = today_m.home_team;
            hdataHost.home_team_big = today_m.home_team_big;
            hdataHost.match_type = today_m.match_type;
            var history_data = lookup_matchType[today_m.match_type]
                   .Where(e => e.match_time < today_m.match_time)
                .Where(e => e.home_team_big == today_m.home_team_big
                    || e.away_team_big == today_m.home_team_big)
                .OrderByDescending(e => e.match_time).Take(take_match_num);
            hdataHost.history_data_etl = new List<HistoryDataETLs>();
            foreach (var ma in history_data)
            {
                hdataHost.match_count++;
                HistoryDataETLs hdata = new HistoryDataETLs();
                hdata._id = ma.result_tb_lib_id;
                hdata.html_position = ma.html_position;
                hdata.home_team_big = ma.home_team_big;
                hdata.away_team_big = ma.away_team_big;
                hdata.match_type = ma.match_type;
                hdata.match_time = ma.match_time;
                hdata.asia_odds = ma.odds;
                hdata.home_team = ma.home_team;
                hdata.away_team = ma.away_team;
                hdata.home_red_card = ma.home_red_card;
                hdata.away_red_card = ma.away_red_card;
                hdata.full_home_goals = ma.full_home_goals;
                hdata.full_away_goals = ma.full_away_goals;
                hdata.half_home_goals = ma.half_home_goals;
                hdata.half_away_goals = ma.half_away_goals;
                hdata.win_loss_big = ma.win_loss_big;
                hdataHost.history_data_etl.Add(hdata);
            }
            mongo_HistoryDataTopHostDocument.MongoCol.Insert(hdataHost);
        }
        private void CreateAwayCollection(ILookup<string, result_tb_lib> lookup_matchType, LiveDataETLsDocument today_m)
        {
            HistoryDataTopAwayDocument hdataHost = new HistoryDataTopAwayDocument();
            hdataHost._id = today_m._id;
            //取当日比赛的客队
            hdataHost.away_team = today_m.away_team;
            hdataHost.away_team_big = today_m.away_team_big;
            hdataHost.match_type = today_m.match_type;
            var history_data = lookup_matchType[today_m.match_type]
                   .Where(e => e.match_time < today_m.match_time)
                .Where(e => e.home_team_big == today_m.away_team_big
                    || e.away_team_big == today_m.away_team_big)
                .OrderByDescending(e => e.match_time).Take(take_match_num);
            hdataHost.history_data_etl = new List<HistoryDataETLs>();
            foreach (var ma in history_data)
            {
                hdataHost.match_count++;
                HistoryDataETLs hdata = new HistoryDataETLs();
                hdata._id = ma.result_tb_lib_id;
                hdata.html_position = ma.html_position;
                hdata.home_team_big = ma.home_team_big;
                hdata.away_team_big = ma.away_team_big;
                hdata.match_type = ma.match_type;
                hdata.match_time = ma.match_time;
                hdata.asia_odds = ma.odds;
                hdata.home_team = ma.home_team;
                hdata.away_team = ma.away_team;
                hdata.home_red_card = ma.home_red_card;
                hdata.away_red_card = ma.away_red_card;
                hdata.full_home_goals = ma.full_home_goals;
                hdata.full_away_goals = ma.full_away_goals;
                hdata.half_home_goals = ma.half_home_goals;
                hdata.half_away_goals = ma.half_away_goals;
                hdata.win_loss_big = ma.win_loss_big;
                hdataHost.history_data_etl.Add(hdata);
            }
            mongo_HistoryDataTopAwayDocument.MongoCol.Insert(hdataHost);
        }

        private void CreateJzCollection(ILookup<string, result_tb_lib> lookup_matchType, LiveDataETLsDocument today_m)
        {
            HistoryDataTopJzDocument hdataHost = new HistoryDataTopJzDocument();
            hdataHost._id = today_m._id;
            hdataHost.home_team = today_m.home_team;
            hdataHost.away_team = today_m.away_team;
            hdataHost.home_team_big = today_m.home_team_big;
            hdataHost.away_team_big = today_m.away_team_big;
            hdataHost.match_type = today_m.match_type;
            var history_data = lookup_matchType[today_m.match_type]
                .Where(e => e.match_time < today_m.match_time)
                .Where(e => (e.home_team_big == today_m.home_team_big && e.away_team_big == today_m.away_team_big)
                    || (e.home_team_big == today_m.away_team_big && e.away_team_big == today_m.home_team_big))
                .OrderByDescending(e => e.match_time).Take(take_match_num);
            hdataHost.history_data_etl = new List<HistoryDataETLs>();
            foreach (var ma in history_data)
            {
                hdataHost.match_count++;
                HistoryDataETLs hdata = new HistoryDataETLs();
                hdata._id = ma.result_tb_lib_id;
                hdata.html_position = ma.html_position;
                hdata.home_team_big = ma.home_team_big;
                hdata.away_team_big = ma.away_team_big;
                hdata.match_type = ma.match_type;
                hdata.match_time = ma.match_time;
                hdata.asia_odds = ma.odds;
                hdata.home_team = ma.home_team;
                hdata.away_team = ma.away_team;
                hdata.home_red_card = ma.home_red_card;
                hdata.away_red_card = ma.away_red_card;
                hdata.full_home_goals = ma.full_home_goals;
                hdata.full_away_goals = ma.full_away_goals;
                hdata.half_home_goals = ma.half_home_goals;
                hdata.half_away_goals = ma.half_away_goals;
                hdata.win_loss_big = ma.win_loss_big;
                hdataHost.history_data_etl.Add(hdata);
            }
            mongo_HistoryDataTopJzDocument.MongoCol.Insert(hdataHost);
        }
    }
}
