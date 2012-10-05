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

        public int Hmatch_count { get; set; }
        public int Hhost_count { get; set; }
        public int Haway_count { get; set; }

        public double Htotal_wins;  //1.总胜
        public double Htotal_draws; //2.总平
        public double Htotal_loss;   //3.总负   

        public double Hhost_wins;//4.主胜
        public double Hhost_draws;   //5.主平
        public double Hhost_loss;  //6.主负

        public double Haway_wins;   //7.客胜
        public double Haway_draws;   //8.客平
        public double Haway_loss;//9.客负

        public double Hht_total_wins;  //10.半场胜
        public double Hht_total_draws; //11.半场平
        public double Hht_total_loss;   //12.半场负   

        public double Hgoals_win_2o;  //13."净胜2+" 
        public double Hgoals_win_1;  //14.净胜1
        public double Hgoals_draw_0;  //15.平
        public double Hgoals_loss_1;   //16.净负1
        public double Hgoals_loss_2o;  //17."净负2+"

        public double Hmygoals_0;   //18.进球数0
        public double Hmygoals_1;   //19.进球数1
        public double Hmygoals_2;   //20.进球数2
        public double Hmygoals_3o;   //21."进球数3+"

        public double Htotal_goals_0t1;   //22."0-1球"
        public double Htotal_goals_2t3;   //23"2-3球"
        public double Htotal_goals_4t6;   //24"4-6球"
        public double Htotal_goals_7o;   //25.7球以上

        public double Htotal_goals_single;  //26.单数
        public double Htotal_goals_double; //27.双数

        public int Hscore_recent_6;  //28.6轮积分;
        public int Hscore_recent_5; //29.5轮积分;
        public int Hscore_recent_4;   //30.4轮积分;
        public int Hscore_recent_3;  //31.3轮积分;
        public int Hscore_recent_2;  //32.2轮积分;
        public int Hscore_recent_1;   //33.1轮积分  

        public int Amatch_count { get; set; }
        public int Ahost_count { get; set; }
        public int Aaway_count { get; set; }

        public double Atotal_wins;  //总胜
        public double Atotal_draws; //总平
        public double Atotal_loss;   //总负   

        public double Ahost_wins; //主胜
        public double Ahost_draws;    //主平
        public double Ahost_loss;  //主负

        public double Aaway_wins;  //客胜
        public double Aaway_draws; //客平
        public double Aaway_loss; //客负

        public double Aht_total_wins;  //半场胜
        public double Aht_total_draws; //半场平
        public double Aht_total_loss;   //半场负   

        public double Agoals_win_2o; //"净胜2+" 
        public double Agoals_win_1;  //净胜1
        public double Agoals_draw_0; //平
        public double Agoals_loss_1; //净负1
        public double Agoals_loss_2o; //"净负2+"

        public double Amygoals_0;   //进球数0
        public double Amygoals_1;   //进球数1
        public double Amygoals_2;   //进球数2
        public double Amygoals_3o;   //"进球数3+"

        public double Atotal_goals_0t1;   //"0-1球"
        public double Atotal_goals_2t3;   //"2-3球"
        public double Atotal_goals_4t6;   //"4-6球"
        public double Atotal_goals_7o;   //7球以上

        public double Atotal_goals_single;  //单数
        public double Atotal_goals_double;  //双数

        public int Ascore_recent_6;  //6轮积分;
        public int Ascore_recent_5; //5轮积分;
        public int Ascore_recent_4;  //4轮积分;
        public int Ascore_recent_3;  //3轮积分;
        public int Ascore_recent_2;//2轮积分;
        public int Ascore_recent_1;   //1轮积分  

        public int Jmatch_count { get; set; }
        public int Jhost_count { get; set; }
        public int Jaway_count { get; set; }

        public int Jtotal_wins { get; set; } //总胜
        public int Jtotal_draws { get; set; } //总平
        public int Jtotal_loss { get; set; }   //总负   

        public int Jhost_wins { get; set; }//主胜
        public int Jhost_draws { get; set; }   //主平
        public int Jhost_loss { get; set; }   //主负

        public int Jaway_wins { get; set; }  //客胜
        public int Jaway_draws { get; set; }   //客平
        public int Jaway_loss { get; set; } //客负

        public int Jht_total_wins { get; set; }  //半场胜
        public int Jht_total_draws { get; set; } //半场平
        public int Jht_total_loss { get; set; }   //半场负   

        public int Jgoals_win_2o { get; set; } //"净胜2+" 
        public int Jgoals_win_1 { get; set; }   //净胜1
        public int Jgoals_draw_0 { get; set; }//平
        public int Jgoals_loss_1 { get; set; }  //净负1
        public int Jgoals_loss_2o { get; set; }   //"净负2+"

        public int Jmygoals_0 { get; set; }   //进球数0
        public int Jmygoals_1 { get; set; }   //进球数1
        public int Jmygoals_2 { get; set; }   //进球数2
        public int Jmygoals_3o { get; set; }   //"进球数3+"

        public int Jtotal_goals_0t1 { get; set; }   //"0-1球"
        public int Jtotal_goals_2t3 { get; set; }  //"2-3球"
        public int Jtotal_goals_4t6 { get; set; }   //"4-6球"
        public int Jtotal_goals_7o { get; set; }  //7球以上

        public int Jtotal_goals_single { get; set; }   //单数
        public int Jtotal_goals_double { get; set; }   //双数

        public int Jscore_recent_6 { get; set; }   //6轮积分;
        public int Jscore_recent_5 { get; set; }  //5轮积分;
        public int Jscore_recent_4 { get; set; }   //4轮积分;
        public int Jscore_recent_3 { get; set; }    //3轮积分;
        public int Jscore_recent_2; //2轮积分;
        public int Jscore_recent_1;  //1轮积分  

    }

    public class SimulinkMatchNow : IDisposable
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
                .Where(e => e.live == 1);
            foreach (var today_now in cals)
            {

                if (today_now.host_probability.match_count == 0
                    || today_now.away_probability.match_count == 0) continue;

                SimulinkMatchNowDocument smnd = new SimulinkMatchNowDocument();
                smnd._id = today_now._id;

                smnd.match_time = (DateTime)today_now.match_prop.match_time;
                smnd.match_type = today_now.match_prop.match_type;
                smnd.home_team = today_now.match_prop.home_team;
                smnd.away_team = today_now.match_prop.away_team;
                smnd.home_team_big = (int)today_now.match_prop.home_team_big;
                smnd.away_team_big = (int)today_now.match_prop.away_team_big;
                smnd.asia_odds = today_now.match_prop.asia_odds;

                smnd.Hmatch_count = today_now.host_probability.match_count;
                smnd.Hhost_count = today_now.host_probability.host_count;
                smnd.Haway_count = today_now.host_probability.away_count;
                smnd.Htotal_wins = (double)today_now.host_probability.total_wins / smnd.Hmatch_count;
                smnd.Htotal_draws = (double)today_now.host_probability.total_draws / smnd.Hmatch_count;
                smnd.Htotal_loss = (double)today_now.host_probability.total_loss / smnd.Hmatch_count;
                smnd.Hhost_wins = (double)today_now.host_probability.host_wins / smnd.Hhost_count;
                smnd.Hhost_draws = (double)today_now.host_probability.host_draws / smnd.Hhost_count;
                smnd.Hhost_loss = (double)today_now.host_probability.host_loss / smnd.Hhost_count;
                smnd.Haway_wins = (double)today_now.host_probability.away_wins / smnd.Haway_count;
                smnd.Haway_draws = (double)today_now.host_probability.away_draws / smnd.Haway_count;
                smnd.Haway_loss = (double)today_now.host_probability.away_loss / smnd.Haway_count;
                smnd.Hht_total_wins = (double)today_now.host_probability.ht_total_wins / smnd.Hmatch_count;
                smnd.Hht_total_draws = (double)today_now.host_probability.ht_total_draws / smnd.Hmatch_count;
                smnd.Hht_total_loss = (double)today_now.host_probability.ht_total_loss / smnd.Hmatch_count;
                smnd.Hgoals_win_2o = (double)today_now.host_probability.goals_win_2o / smnd.Hmatch_count;
                smnd.Hgoals_win_1 = (double)today_now.host_probability.goals_win_1 / smnd.Hmatch_count;
                smnd.Hgoals_draw_0 = (double)today_now.host_probability.goals_draw_0 / smnd.Hmatch_count;
                smnd.Hgoals_loss_1 = (double)today_now.host_probability.goals_loss_1 / smnd.Hmatch_count;
                smnd.Hgoals_loss_2o = (double)today_now.host_probability.goals_loss_2o / smnd.Hmatch_count;
                smnd.Hmygoals_0 = (double)today_now.host_probability.mygoals_0 / smnd.Hmatch_count;
                smnd.Hmygoals_1 = (double)today_now.host_probability.mygoals_1 / smnd.Hmatch_count;
                smnd.Hmygoals_2 = (double)today_now.host_probability.mygoals_2 / smnd.Hmatch_count;
                smnd.Hmygoals_3o = (double)today_now.host_probability.mygoals_3o / smnd.Hmatch_count;
                smnd.Htotal_goals_0t1 = (double)today_now.host_probability.total_goals_0t1 / smnd.Hmatch_count;
                smnd.Htotal_goals_2t3 = (double)today_now.host_probability.total_goals_2t3 / smnd.Hmatch_count;
                smnd.Htotal_goals_4t6 = (double)today_now.host_probability.total_goals_4t6 / smnd.Hmatch_count;
                smnd.Htotal_goals_7o = (double)today_now.host_probability.total_goals_7o / smnd.Hmatch_count;
                smnd.Htotal_goals_double = (double)today_now.host_probability.total_goals_double / smnd.Hmatch_count;
                smnd.Htotal_goals_single = (double)today_now.host_probability.total_goals_single / smnd.Hmatch_count;
                smnd.Hscore_recent_1 = today_now.host_probability.score_recent_1;
                smnd.Hscore_recent_2 = today_now.host_probability.score_recent_2;
                smnd.Hscore_recent_3 = today_now.host_probability.score_recent_3;
                smnd.Hscore_recent_4 = today_now.host_probability.score_recent_4;
                smnd.Hscore_recent_5 = today_now.host_probability.score_recent_5;
                smnd.Hscore_recent_6 = today_now.host_probability.score_recent_6;

                smnd.Amatch_count = today_now.away_probability.match_count;
                smnd.Ahost_count = today_now.away_probability.host_count;
                smnd.Aaway_count = today_now.away_probability.away_count;
                smnd.Atotal_wins = (double)today_now.away_probability.total_wins / smnd.Amatch_count;
                smnd.Atotal_draws = (double)today_now.away_probability.total_draws / smnd.Amatch_count;
                smnd.Atotal_loss = (double)today_now.away_probability.total_loss / smnd.Amatch_count;
                smnd.Ahost_wins = (double)today_now.away_probability.host_wins / smnd.Ahost_count;
                smnd.Ahost_draws = (double)today_now.away_probability.host_draws / smnd.Ahost_count;
                smnd.Ahost_loss = (double)today_now.away_probability.host_loss / smnd.Ahost_count;
                smnd.Aaway_wins = (double)today_now.away_probability.away_wins / smnd.Aaway_count;
                smnd.Aaway_draws = (double)today_now.away_probability.away_draws / smnd.Aaway_count;
                smnd.Aaway_loss = (double)today_now.away_probability.away_loss / smnd.Aaway_count;
                smnd.Aht_total_wins = (double)today_now.away_probability.ht_total_wins / smnd.Amatch_count;
                smnd.Aht_total_draws = (double)today_now.away_probability.ht_total_draws / smnd.Amatch_count;
                smnd.Aht_total_loss = (double)today_now.away_probability.ht_total_loss / smnd.Amatch_count;
                smnd.Agoals_win_2o = (double)today_now.away_probability.goals_win_2o / smnd.Amatch_count;
                smnd.Agoals_win_1 = (double)today_now.away_probability.goals_win_1 / smnd.Amatch_count;
                smnd.Agoals_draw_0 = (double)today_now.away_probability.goals_draw_0 / smnd.Amatch_count;
                smnd.Agoals_loss_1 = (double)today_now.away_probability.goals_loss_1 / smnd.Amatch_count;
                smnd.Agoals_loss_2o = (double)today_now.away_probability.goals_loss_2o / smnd.Amatch_count;
                smnd.Amygoals_0 = (double)today_now.away_probability.mygoals_0 / smnd.Amatch_count;
                smnd.Amygoals_1 = (double)today_now.away_probability.mygoals_1 / smnd.Amatch_count;
                smnd.Amygoals_2 = (double)today_now.away_probability.mygoals_2 / smnd.Amatch_count;
                smnd.Amygoals_3o = (double)today_now.away_probability.mygoals_3o / smnd.Amatch_count;
                smnd.Atotal_goals_0t1 = (double)today_now.away_probability.total_goals_0t1 / smnd.Amatch_count;
                smnd.Atotal_goals_2t3 = (double)today_now.away_probability.total_goals_2t3 / smnd.Amatch_count;
                smnd.Atotal_goals_4t6 = (double)today_now.away_probability.total_goals_4t6 / smnd.Amatch_count;
                smnd.Atotal_goals_7o = (double)today_now.away_probability.total_goals_7o / smnd.Amatch_count;
                smnd.Atotal_goals_double = (double)today_now.away_probability.total_goals_double / smnd.Amatch_count;
                smnd.Atotal_goals_single = (double)today_now.away_probability.total_goals_single / smnd.Amatch_count;
                smnd.Ascore_recent_1 = today_now.away_probability.score_recent_1;
                smnd.Ascore_recent_2 = today_now.away_probability.score_recent_2;
                smnd.Ascore_recent_3 = today_now.away_probability.score_recent_3;
                smnd.Ascore_recent_4 = today_now.away_probability.score_recent_4;
                smnd.Ascore_recent_5 = today_now.away_probability.score_recent_5;
                smnd.Ascore_recent_6 = today_now.away_probability.score_recent_6;

                smnd.Jmatch_count = today_now.jz_probability.match_count;
                smnd.Jhost_count = today_now.jz_probability.host_count;
                smnd.Jaway_count = today_now.jz_probability.away_count;
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


                mongocrud.MongoDropColCreateCol.Insert(smnd);
            }
        }
    }
}
