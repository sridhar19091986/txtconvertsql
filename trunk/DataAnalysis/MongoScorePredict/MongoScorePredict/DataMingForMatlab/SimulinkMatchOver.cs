using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;
using MongoScorePredict.AlgorithmModel;

namespace MongoScorePredict.DataMingForMatlab
{
    public class SimulinkMatchOverDocument
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


        public int full_host_goals;// 主队进球;
        public int full_away_goals;  //客队进球;
        public int full_310value; //全场，3，1，0;
    }

    public class SimulinkMatchOver : IDisposable
    {
        private string mongo_collection = CommonAttribute.SimulinkMatchOver[0];
        private string mongo_db = CommonAttribute.SimulinkMatchOver[1];
        private string mongo_conn = CommonAttribute.SimulinkMatchOver[2];

        public MongoCrud<SimulinkMatchOverDocument> mongocrud;

        public SimulinkMatchOver()
        {
            mongocrud = new MongoCrud<SimulinkMatchOverDocument>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SimulinkMatchOver()
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
                .Where(e=>e.live==0);
            foreach (var today_now in cals)
            {
                SimulinkMatchOverDocument smod = new SimulinkMatchOverDocument();
                smod._id = today_now._id;

                smod.match_time = (DateTime)today_now.match_prop.match_time;
                smod.match_type = today_now.match_prop.match_type;
                smod.home_team = today_now.match_prop.home_team;
                smod.away_team = today_now.match_prop.away_team;
                smod.home_team_big = (int)today_now.match_prop.home_team_big;
                smod.away_team_big = (int)today_now.match_prop.away_team_big;
                smod.asia_odds = today_now.match_prop.asia_odds;

                smod.Hmatch_count = today_now.host_probability.match_count;
                smod.Htotal_wins = today_now.host_probability.total_wins;
                smod.Htotal_draws = today_now.host_probability.total_draws;
                smod.Htotal_loss = today_now.host_probability.total_loss;
                smod.Hhost_wins = today_now.host_probability.host_wins;
                smod.Hhost_draws = today_now.host_probability.host_draws;
                smod.Hhost_loss = today_now.host_probability.host_loss;
                smod.Haway_wins = today_now.host_probability.away_wins;
                smod.Haway_draws = today_now.host_probability.away_draws;
                smod.Haway_loss = today_now.host_probability.away_loss;
                smod.Hht_total_wins = today_now.host_probability.ht_total_wins;
                smod.Hht_total_draws = today_now.host_probability.ht_total_draws;
                smod.Hht_total_loss = today_now.host_probability.ht_total_loss;
                smod.Hgoals_win_2o = today_now.host_probability.goals_win_2o;
                smod.Hgoals_win_1 = today_now.host_probability.goals_win_1;
                smod.Hgoals_draw_0 = today_now.host_probability.goals_draw_0;
                smod.Hgoals_loss_1 = today_now.host_probability.goals_loss_1;
                smod.Hgoals_loss_2o = today_now.host_probability.goals_loss_2o;
                smod.Hmygoals_0 = today_now.host_probability.mygoals_0;
                smod.Hmygoals_1 = today_now.host_probability.mygoals_1;
                smod.Hmygoals_2 = today_now.host_probability.mygoals_2;
                smod.Hmygoals_3o = today_now.host_probability.mygoals_3o;
                smod.Htotal_goals_0t1 = today_now.host_probability.total_goals_0t1;
                smod.Htotal_goals_2t3 = today_now.host_probability.total_goals_2t3;
                smod.Htotal_goals_4t6 = today_now.host_probability.total_goals_4t6;
                smod.Htotal_goals_7o = today_now.host_probability.total_goals_7o;
                smod.Htotal_goals_double = today_now.host_probability.total_goals_double;
                smod.Htotal_goals_single = today_now.host_probability.total_goals_single;
                smod.Hscore_recent_1 = today_now.host_probability.score_recent_1;
                smod.Hscore_recent_2 = today_now.host_probability.score_recent_2;
                smod.Hscore_recent_3 = today_now.host_probability.score_recent_3;
                smod.Hscore_recent_4 = today_now.host_probability.score_recent_4;
                smod.Hscore_recent_5 = today_now.host_probability.score_recent_5;
                smod.Hscore_recent_6 = today_now.host_probability.score_recent_6;

                smod.Amatch_count = today_now.away_probability.match_count;
                smod.Atotal_wins = today_now.away_probability.total_wins;
                smod.Atotal_draws = today_now.away_probability.total_draws;
                smod.Atotal_loss = today_now.away_probability.total_loss;
                smod.Ahost_wins = today_now.away_probability.host_wins;
                smod.Ahost_draws = today_now.away_probability.host_draws;
                smod.Ahost_loss = today_now.away_probability.host_loss;
                smod.Aaway_wins = today_now.away_probability.away_wins;
                smod.Aaway_draws = today_now.away_probability.away_draws;
                smod.Aaway_loss = today_now.away_probability.away_loss;
                smod.Aht_total_wins = today_now.away_probability.ht_total_wins;
                smod.Aht_total_draws = today_now.away_probability.ht_total_draws;
                smod.Aht_total_loss = today_now.away_probability.ht_total_loss;
                smod.Agoals_win_2o = today_now.away_probability.goals_win_2o;
                smod.Agoals_win_1 = today_now.away_probability.goals_win_1;
                smod.Agoals_draw_0 = today_now.away_probability.goals_draw_0;
                smod.Agoals_loss_1 = today_now.away_probability.goals_loss_1;
                smod.Agoals_loss_2o = today_now.away_probability.goals_loss_2o;
                smod.Amygoals_0 = today_now.away_probability.mygoals_0;
                smod.Amygoals_1 = today_now.away_probability.mygoals_1;
                smod.Amygoals_2 = today_now.away_probability.mygoals_2;
                smod.Amygoals_3o = today_now.away_probability.mygoals_3o;
                smod.Atotal_goals_0t1 = today_now.away_probability.total_goals_0t1;
                smod.Atotal_goals_2t3 = today_now.away_probability.total_goals_2t3;
                smod.Atotal_goals_4t6 = today_now.away_probability.total_goals_4t6;
                smod.Atotal_goals_7o = today_now.away_probability.total_goals_7o;
                smod.Atotal_goals_double = today_now.away_probability.total_goals_double;
                smod.Atotal_goals_single = today_now.away_probability.total_goals_single;
                smod.Ascore_recent_1 = today_now.away_probability.score_recent_1;
                smod.Ascore_recent_2 = today_now.away_probability.score_recent_2;
                smod.Ascore_recent_3 = today_now.away_probability.score_recent_3;
                smod.Ascore_recent_4 = today_now.away_probability.score_recent_4;
                smod.Ascore_recent_5 = today_now.away_probability.score_recent_5;
                smod.Ascore_recent_6 = today_now.away_probability.score_recent_6;

                smod.Jmatch_count = today_now.jz_probability.match_count;
                smod.Jtotal_wins = today_now.jz_probability.total_wins;
                smod.Jtotal_draws = today_now.jz_probability.total_draws;
                smod.Jtotal_loss = today_now.jz_probability.total_loss;
                smod.Jhost_wins = today_now.jz_probability.host_wins;
                smod.Jhost_draws = today_now.jz_probability.host_draws;
                smod.Jhost_loss = today_now.jz_probability.host_loss;
                smod.Jaway_wins = today_now.jz_probability.away_wins;
                smod.Jaway_draws = today_now.jz_probability.away_draws;
                smod.Jaway_loss = today_now.jz_probability.away_loss;
                smod.Jht_total_wins = today_now.jz_probability.ht_total_wins;
                smod.Jht_total_draws = today_now.jz_probability.ht_total_draws;
                smod.Jht_total_loss = today_now.jz_probability.ht_total_loss;
                smod.Jgoals_win_2o = today_now.jz_probability.goals_win_2o;
                smod.Jgoals_win_1 = today_now.jz_probability.goals_win_1;
                smod.Jgoals_draw_0 = today_now.jz_probability.goals_draw_0;
                smod.Jgoals_loss_1 = today_now.jz_probability.goals_loss_1;
                smod.Jgoals_loss_2o = today_now.jz_probability.goals_loss_2o;
                smod.Jmygoals_0 = today_now.jz_probability.mygoals_0;
                smod.Jmygoals_1 = today_now.jz_probability.mygoals_1;
                smod.Jmygoals_2 = today_now.jz_probability.mygoals_2;
                smod.Jmygoals_3o = today_now.jz_probability.mygoals_3o;
                smod.Jtotal_goals_0t1 = today_now.jz_probability.total_goals_0t1;
                smod.Jtotal_goals_2t3 = today_now.jz_probability.total_goals_2t3;
                smod.Jtotal_goals_4t6 = today_now.jz_probability.total_goals_4t6;
                smod.Jtotal_goals_7o = today_now.jz_probability.total_goals_7o;
                smod.Jtotal_goals_double = today_now.jz_probability.total_goals_double;
                smod.Jtotal_goals_single = today_now.jz_probability.total_goals_single;
                smod.Jscore_recent_1 = today_now.jz_probability.score_recent_1;
                smod.Jscore_recent_2 = today_now.jz_probability.score_recent_2;
                smod.Jscore_recent_3 = today_now.jz_probability.score_recent_3;
                smod.Jscore_recent_4 = today_now.jz_probability.score_recent_4;
                smod.Jscore_recent_5 = today_now.jz_probability.score_recent_5;
                smod.Jscore_recent_6 = today_now.jz_probability.score_recent_6;

                smod.full_host_goals = (int)today_now.result_score.full_host_goals;
                smod.full_away_goals = (int)today_now.result_score.full_away_goals;
                smod.full_310value = (int)today_now.result_score.full_310value;

                mongocrud.MongoCol.Insert(smod);
            }
        }
    }
}
