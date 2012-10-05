using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;
using MongoScorePredict.HistoryDataETL;
using MongoScorePredict.AlgorithmModel;

namespace MongoScorePredict.DataMingForMatlab
{
    public class SimulinkMatchNowDocument
    {
        public long _id { get; set; }
        public int live { get; set; }//是否是即时数据

        public int home_team_big { get; set; }
        public int away_team_big { get; set; }
        public string match_type { get; set; }
        public DateTime match_time { get; set; }
        public string asia_odds { get; set; }
        public string home_team { get; set; }
        public string away_team { get; set; }

        public int Hmatch_count;

        public int Htotal_wins;  //总胜
        public int Htotal_draws; //总平
        public int Htotal_loss;   //总负   
        public int Hhost_wins;//主胜
        public int Hhost_draws;   //主平
        public int Hhost_loss;   //主负
        public int Haway_wins;   //客胜
        public int Haway_draws;   //客平
        public int Haway_loss;  //客负

        public int Hht_total_wins;  //总胜
        public int Hht_total_draws; //总平
        public int Hht_total_loss;   //总负   

        public int Hgoals_win_2o; //"净胜2+" 
        public int Hgoals_win_1;   //净胜1
        public int Hgoals_draw_0; //平
        public int Hgoals_loss_1;   //净负1
        public int Hgoals_loss_2o;   //"净负2+"

        public int Hmygoals_0;   //进球数0
        public int Hmygoals_1;   //进球数1
        public int Hmygoals_2;   //进球数2
        public int Hmygoals_3o;   //"进球数3+"

        public int Htotal_goals_0t1;   //"0-1球"
        public int Htotal_goals_2t3;   //"2-3球"
        public int Htotal_goals_4t6;   //"4-6球"
        public int Htotal_goals_7o;   //7球以上

        public int Htotal_goals_single;   //单数
        public int Htotal_goals_double;   //双数

        public int Hscore_recent_6;   //6轮积分;
        public int Hscore_recent_5;  //5轮积分;
        public int Hscore_recent_4;   //4轮积分;
        public int Hscore_recent_3;   //3轮积分;
        public int Hscore_recent_2; //2轮积分;
        public int Hscore_recent_1;   //1轮积分  

        public int Amatch_count;

        public int Atotal_wins;  //总胜
        public int Atotal_draws; //总平
        public int Atotal_loss;   //总负   
        public int Ahost_wins;//主胜
        public int Ahost_draws;   //主平
        public int Ahost_loss;   //主负
        public int Aaway_wins;   //客胜
        public int Aaway_draws;   //客平
        public int Aaway_loss;  //客负

        public int Aht_total_wins;  //总胜
        public int Aht_total_draws; //总平
        public int Aht_total_loss;   //总负   

        public int Agoals_win_2o; //"净胜2+" 
        public int Agoals_win_1;   //净胜1
        public int Agoals_draw_0; //平
        public int Agoals_loss_1;   //净负1
        public int Agoals_loss_2o;   //"净负2+"

        public int Amygoals_0;   //进球数0
        public int Amygoals_1;   //进球数1
        public int Amygoals_2;   //进球数2
        public int Amygoals_3o;   //"进球数3+"

        public int Atotal_goals_0t1;   //"0-1球"
        public int Atotal_goals_2t3;   //"2-3球"
        public int Atotal_goals_4t6;   //"4-6球"
        public int Atotal_goals_7o;   //7球以上

        public int Atotal_goals_single;   //单数
        public int Atotal_goals_double;   //双数

        public int Ascore_recent_6;   //6轮积分;
        public int Ascore_recent_5;  //5轮积分;
        public int Ascore_recent_4;   //4轮积分;
        public int Ascore_recent_3;   //3轮积分;
        public int Ascore_recent_2; //2轮积分;
        public int Ascore_recent_1;   //1轮积分  

        public int Jmatch_count;

        public int Jtotal_wins;  //总胜
        public int Jtotal_draws; //总平
        public int Jtotal_loss;   //总负   
        public int Jhost_wins;//主胜
        public int Jhost_draws;   //主平
        public int Jhost_loss;   //主负
        public int Jaway_wins;   //客胜
        public int Jaway_draws;   //客平
        public int Jaway_loss;  //客负

        public int Jht_total_wins;  //总胜
        public int Jht_total_draws; //总平
        public int Jht_total_loss;   //总负   

        public int Jgoals_win_2o; //"净胜2+" 
        public int Jgoals_win_1;   //净胜1
        public int Jgoals_draw_0; //平
        public int Jgoals_loss_1;   //净负1
        public int Jgoals_loss_2o;   //"净负2+"

        public int Jmygoals_0;   //进球数0
        public int Jmygoals_1;   //进球数1
        public int Jmygoals_2;   //进球数2
        public int Jmygoals_3o;   //"进球数3+"

        public int Jtotal_goals_0t1;   //"0-1球"
        public int Jtotal_goals_2t3;   //"2-3球"
        public int Jtotal_goals_4t6;   //"4-6球"
        public int Jtotal_goals_7o;   //7球以上

        public int Jtotal_goals_single;   //单数
        public int Jtotal_goals_double;   //双数

        public int Jscore_recent_6;   //6轮积分;
        public int Jscore_recent_5;  //5轮积分;
        public int Jscore_recent_4;   //4轮积分;
        public int Jscore_recent_3;   //3轮积分;
        public int Jscore_recent_2; //2轮积分;
        public int Jscore_recent_1;   //1轮积分  

    }

    public class SimulinkMatchNow:IDisposable
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

        public void CreateLiveCollection()
        {
            HistoryDataCalculate hdatacal = new HistoryDataCalculate();
            var cals = hdatacal.mongo_HistoryDataCalculateDocument.QueryMongo()
                .Where(e=>e.live==1);
            foreach (var today_now in cals)
            {
                SimulinkMatchNowDocument smnd = new SimulinkMatchNowDocument();
                smnd._id = today_now._id;

                smnd.match_time = (DateTime)today_now.match_prop.match_time;
                smnd.match_type = today_now.match_prop.match_type;
                smnd.home_team = today_now.match_prop.home_team;
                smnd.away_team = today_now.match_prop.away_team;
                smnd.home_team_big =(int) today_now.match_prop.home_team_big;
                smnd.away_team_big = (int)today_now.match_prop.away_team_big;
                smnd.asia_odds = today_now.match_prop.asia_odds;

                smnd.Hmatch_count = today_now.host_probability.match_count;
                smnd.Htotal_wins = today_now.host_probability.total_wins;
                smnd.Htotal_draws = today_now.host_probability.total_draws;
                smnd.Htotal_loss = today_now.host_probability.total_loss;
                smnd.Hhost_wins = today_now.host_probability.host_wins;
                smnd.Hhost_draws = today_now.host_probability.host_draws;
                smnd.Hhost_loss = today_now.host_probability.host_loss;
                smnd.Haway_wins = today_now.host_probability.away_wins;
                smnd.Haway_draws = today_now.host_probability.away_draws;
                smnd.Haway_loss = today_now.host_probability.away_loss;
                smnd.Hht_total_wins = today_now.host_probability.ht_total_wins;
                smnd.Hht_total_draws = today_now.host_probability.ht_total_draws;
                smnd.Hht_total_loss = today_now.host_probability.ht_total_loss;
                smnd.Hgoals_win_2o = today_now.host_probability.goals_win_2o;
                smnd.Hgoals_win_1 = today_now.host_probability.goals_win_1;
                smnd.Hgoals_draw_0 = today_now.host_probability.goals_draw_0;
                smnd.Hgoals_loss_1 = today_now.host_probability.goals_loss_1;
                smnd.Hgoals_loss_2o = today_now.host_probability.goals_loss_2o;
                smnd.Hmygoals_0 = today_now.host_probability.mygoals_0;
                smnd.Hmygoals_1 = today_now.host_probability.mygoals_1;
                smnd.Hmygoals_2 = today_now.host_probability.mygoals_2;
                smnd.Hmygoals_3o = today_now.host_probability.mygoals_3o;
                smnd.Htotal_goals_0t1 = today_now.host_probability.total_goals_0t1;
                smnd.Htotal_goals_2t3 = today_now.host_probability.total_goals_2t3;
                smnd.Htotal_goals_4t6 = today_now.host_probability.total_goals_4t6;
                smnd.Htotal_goals_7o = today_now.host_probability.total_goals_7o;
                smnd.Htotal_goals_double = today_now.host_probability.total_goals_double;
                smnd.Htotal_goals_single = today_now.host_probability.total_goals_single;
                smnd.Hscore_recent_1 = today_now.host_probability.score_recent_1;
                smnd.Hscore_recent_2 = today_now.host_probability.score_recent_2;
                smnd.Hscore_recent_3 = today_now.host_probability.score_recent_3;
                smnd.Hscore_recent_4 = today_now.host_probability.score_recent_4;
                smnd.Hscore_recent_5 = today_now.host_probability.score_recent_5;
                smnd.Hscore_recent_6 = today_now.host_probability.score_recent_6;

                smnd.Amatch_count = today_now.away_probability.match_count;
                smnd.Atotal_wins = today_now.away_probability.total_wins;
                smnd.Atotal_draws = today_now.away_probability.total_draws;
                smnd.Atotal_loss = today_now.away_probability.total_loss;
                smnd.Ahost_wins = today_now.away_probability.host_wins;
                smnd.Ahost_draws = today_now.away_probability.host_draws;
                smnd.Ahost_loss = today_now.away_probability.host_loss;
                smnd.Aaway_wins = today_now.away_probability.away_wins;
                smnd.Aaway_draws = today_now.away_probability.away_draws;
                smnd.Aaway_loss = today_now.away_probability.away_loss;
                smnd.Aht_total_wins = today_now.away_probability.ht_total_wins;
                smnd.Aht_total_draws = today_now.away_probability.ht_total_draws;
                smnd.Aht_total_loss = today_now.away_probability.ht_total_loss;
                smnd.Agoals_win_2o = today_now.away_probability.goals_win_2o;
                smnd.Agoals_win_1 = today_now.away_probability.goals_win_1;
                smnd.Agoals_draw_0 = today_now.away_probability.goals_draw_0;
                smnd.Agoals_loss_1 = today_now.away_probability.goals_loss_1;
                smnd.Agoals_loss_2o = today_now.away_probability.goals_loss_2o;
                smnd.Amygoals_0 = today_now.away_probability.mygoals_0;
                smnd.Amygoals_1 = today_now.away_probability.mygoals_1;
                smnd.Amygoals_2 = today_now.away_probability.mygoals_2;
                smnd.Amygoals_3o = today_now.away_probability.mygoals_3o;
                smnd.Atotal_goals_0t1 = today_now.away_probability.total_goals_0t1;
                smnd.Atotal_goals_2t3 = today_now.away_probability.total_goals_2t3;
                smnd.Atotal_goals_4t6 = today_now.away_probability.total_goals_4t6;
                smnd.Atotal_goals_7o = today_now.away_probability.total_goals_7o;
                smnd.Atotal_goals_double = today_now.away_probability.total_goals_double;
                smnd.Atotal_goals_single = today_now.away_probability.total_goals_single;
                smnd.Ascore_recent_1 = today_now.away_probability.score_recent_1;
                smnd.Ascore_recent_2 = today_now.away_probability.score_recent_2;
                smnd.Ascore_recent_3 = today_now.away_probability.score_recent_3;
                smnd.Ascore_recent_4 = today_now.away_probability.score_recent_4;
                smnd.Ascore_recent_5 = today_now.away_probability.score_recent_5;
                smnd.Ascore_recent_6 = today_now.away_probability.score_recent_6;

                smnd.Jmatch_count = today_now.jz_probability.match_count;
                smnd.Jtotal_wins = today_now.jz_probability.total_wins;
                smnd.Jtotal_draws = today_now.jz_probability.total_draws;
                smnd.Jtotal_loss = today_now.jz_probability.total_loss;
                smnd.Jhost_wins = today_now.jz_probability.host_wins;
                smnd.Jhost_draws = today_now.jz_probability.host_draws;
                smnd.Jhost_loss = today_now.jz_probability.host_loss;
                smnd.Jaway_wins = today_now.jz_probability.away_wins;
                smnd.Jaway_draws = today_now.jz_probability.away_draws;
                smnd.Jaway_loss = today_now.jz_probability.away_loss;
                smnd.Jht_total_wins = today_now.jz_probability.ht_total_wins;
                smnd.Jht_total_draws = today_now.jz_probability.ht_total_draws;
                smnd.Jht_total_loss = today_now.jz_probability.ht_total_loss;
                smnd.Jgoals_win_2o = today_now.jz_probability.goals_win_2o;
                smnd.Jgoals_win_1 = today_now.jz_probability.goals_win_1;
                smnd.Jgoals_draw_0 = today_now.jz_probability.goals_draw_0;
                smnd.Jgoals_loss_1 = today_now.jz_probability.goals_loss_1;
                smnd.Jgoals_loss_2o = today_now.jz_probability.goals_loss_2o;
                smnd.Jmygoals_0 = today_now.jz_probability.mygoals_0;
                smnd.Jmygoals_1 = today_now.jz_probability.mygoals_1;
                smnd.Jmygoals_2 = today_now.jz_probability.mygoals_2;
                smnd.Jmygoals_3o = today_now.jz_probability.mygoals_3o;
                smnd.Jtotal_goals_0t1 = today_now.jz_probability.total_goals_0t1;
                smnd.Jtotal_goals_2t3 = today_now.jz_probability.total_goals_2t3;
                smnd.Jtotal_goals_4t6 = today_now.jz_probability.total_goals_4t6;
                smnd.Jtotal_goals_7o = today_now.jz_probability.total_goals_7o;
                smnd.Jtotal_goals_double = today_now.jz_probability.total_goals_double;
                smnd.Jtotal_goals_single = today_now.jz_probability.total_goals_single;
                smnd.Jscore_recent_1 = today_now.jz_probability.score_recent_1;
                smnd.Jscore_recent_2 = today_now.jz_probability.score_recent_2;
                smnd.Jscore_recent_3 = today_now.jz_probability.score_recent_3;
                smnd.Jscore_recent_4 = today_now.jz_probability.score_recent_4;
                smnd.Jscore_recent_5 = today_now.jz_probability.score_recent_5;
                smnd.Jscore_recent_6 = today_now.jz_probability.score_recent_6;


                mongocrud.MongoCol.Insert(smnd);
            }
        }
    }
}
