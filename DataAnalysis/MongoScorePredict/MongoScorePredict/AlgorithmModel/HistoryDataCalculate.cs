/*
 * 
 * 第3步，按照模型进行计算
 * 
 * 检查这个模型的正确性，怎么处理？
 * 
 * 
 * */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;
using MongoScorePredict.LiveDataETL;
using MongoScorePredict.HistoryDataETL;

namespace MongoScorePredict.AlgorithmModel
{
    //球队属性
    public class ProbabilityModel
    {
        public int match_count;

        public int total_wins;  //总胜
        public int total_draws; //总平
        public int total_loss;   //总负   
        public int host_wins;//主胜
        public int host_draws;   //主平
        public int host_loss;   //主负
        public int away_wins;   //客胜
        public int away_draws;   //客平
        public int away_loss;  //客负

        public int ht_total_wins;  //总胜
        public int ht_total_draws; //总平
        public int ht_total_loss;   //总负   

        public int goals_win_2o; //"净胜2+" 
        public int goals_win_1;   //净胜1
        public int goals_draw_0; //平
        public int goals_loss_1;   //净负1
        public int goals_loss_2o;   //"净负2+"

        public int mygoals_0;   //进球数0
        public int mygoals_1;   //进球数1
        public int mygoals_2;   //进球数2
        public int mygoals_3o;   //"进球数3+"

        public int total_goals_0t1;   //"0-1球"
        public int total_goals_2t3;   //"2-3球"
        public int total_goals_4t6;   //"4-6球"
        public int total_goals_7o;   //7球以上

        public int total_goals_single;   //单数
        public int total_goals_double;   //双数

        public int score_recent_6;   //6轮积分;
        public int score_recent_5;  //5轮积分;
        public int score_recent_4;   //4轮积分;
        public int score_recent_3;   //3轮积分;
        public int score_recent_2; //2轮积分;
        public int score_recent_1;   //1轮积分  
    }
    //比赛属性
    public class PredictModel
    {
        public long _id;//由于需要经常修改，取当日比赛的id，或者比赛结果的id
        public int? full_host_goals;// 主队进球;
        public int? full_away_goals;  //客队进球;
        public int? half_host_goals; //半场主队进球;
        public int? half_away_goals;  //半场客队进球;
        public int? full_310value; //全场，3，1，0;
        public int? half_310value; //半场，3，1，0;  
    }
    public class MatchModel
    {
        public int? home_team_big;
        public int? away_team_big;
        public string match_type;
        public DateTime? match_time;
        public string asia_odds;
        public string home_team;
        public string away_team;
    }
    //模型修正系数、正确概率    
    public class AuditModel
    {

    }
    //交战记录的数据暂时忽略，避免计算NA值，NA的填充？
    public class HistoryDataCalculateDocument
    {
        public long _id;//取当日比赛的id
        public MatchModel match_prop;
        public ProbabilityModel host_probability;
        public ProbabilityModel away_probability;
        public ProbabilityModel jz_probability;
        public PredictModel predict_score;
        public PredictModel result_score;
    }

    public class HistoryDataCalculate : IDisposable
    {
        private string mongo_collection = CommonAttribute.HistoryDataCalculate[0];
        private string mongo_db = CommonAttribute.HistoryDataCalculate[1];
        private string mongo_conn = CommonAttribute.HistoryDataCalculate[2];
        public MongoCrud<HistoryDataCalculateDocument> mongo_HistoryDataCalculateDocument;
        public HistoryDataCalculate()
        {
            mongo_HistoryDataCalculateDocument = new MongoCrud<HistoryDataCalculateDocument>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~HistoryDataCalculate()
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

        public ProbabilityModel ConvertHost(List<HistoryDataETLs> host, int? home_team_big)
        {
            var host_probability = new ProbabilityModel();

            host_probability.host_wins = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals > 0).Count();
            host_probability.host_draws = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 0).Count();
            host_probability.host_loss = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals < 0).Count();

            host_probability.away_wins = host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals < 0).Count();
            host_probability.away_draws = host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 0).Count();
            host_probability.away_loss = host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals > 0).Count();

            host_probability.total_wins = host_probability.host_wins + host_probability.away_wins;
            host_probability.total_draws = host_probability.host_draws + host_probability.away_draws;
            host_probability.total_loss = host_probability.host_loss + host_probability.away_loss;

            host_probability.ht_total_wins = host.Where(e => e.home_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals > 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals < 0).Count();
            host_probability.ht_total_draws = host.Where(e => e.home_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals == 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals == 0).Count();
            host_probability.ht_total_loss = host.Where(e => e.home_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals < 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals > 0).Count();

            host_probability.goals_win_2o = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals >= 2).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals <= -2).Count();
            host_probability.goals_win_1 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 1).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == -1).Count();
            host_probability.goals_draw_0 = host_probability.total_draws;
            host_probability.goals_loss_1 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == -1).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 1).Count();
            host_probability.goals_loss_2o = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals <= -2).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals >= 2).Count();

            host_probability.mygoals_0 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals == 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals == 0).Count();
            host_probability.mygoals_1 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals == 1).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals == 1).Count();
            host_probability.mygoals_2 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals == 2).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals == 2).Count();
            host_probability.mygoals_3o = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals >= 3).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals >= 3).Count();

            host_probability.total_goals_0t1 = host.Where(e => e.full_home_goals + e.full_away_goals <= 1).Count();
            host_probability.total_goals_2t3 = host.Where(e => e.full_home_goals + e.full_away_goals <= 3 && e.full_home_goals + e.full_away_goals >= 2).Count();
            host_probability.total_goals_4t6 = host.Where(e => e.full_home_goals + e.full_away_goals <= 6 && e.full_home_goals + e.full_away_goals >= 4).Count();
            host_probability.total_goals_7o = host.Where(e => e.full_home_goals + e.full_away_goals >= 7).Count();

            host_probability.total_goals_double = host.Where(e => (e.full_home_goals + e.full_away_goals) % 2 == 0).Count();
            host_probability.total_goals_single = host.Where(e => (e.full_home_goals + e.full_away_goals) % 2 == 1).Count();

            int[] scores = new int[6];
            for (int i = 0; i < scores.Length; i++)
                scores[i] = 0;
            int index = 0;
            foreach (var ma in host.Take(6))
            {
                if (ma.full_home_goals - ma.full_away_goals > 0)
                    if (ma.home_team_big == home_team_big)
                        scores[index] = 3;
                if (ma.full_home_goals - ma.full_away_goals < 0)
                    if (ma.away_team_big == home_team_big)
                        scores[index] = 3;
                if (ma.full_home_goals - ma.full_away_goals == 0)
                    scores[index] = 1;
                index++;
            }
            host_probability.score_recent_1 = scores[0];
            host_probability.score_recent_2 = scores[0] + scores[1];
            host_probability.score_recent_3 = scores[0] + scores[1] + scores[2];
            host_probability.score_recent_4 = scores[0] + scores[1] + scores[2] + scores[3];
            host_probability.score_recent_5 = scores[0] + scores[1] + scores[2] + scores[3] + scores[4];
            host_probability.score_recent_6 = scores[0] + scores[1] + scores[2] + scores[3] + scores[4] + scores[5];

            return host_probability;

        }
        public ProbabilityModel ConvertAway(List<HistoryDataETLs> host, int? away_team_big)
        {
            var away_probability = new ProbabilityModel();

            away_probability.host_wins = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals > 0).Count();
            away_probability.host_draws = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals == 0).Count();
            away_probability.host_loss = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals < 0).Count();

            away_probability.away_wins = host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals < 0).Count();
            away_probability.away_draws = host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals == 0).Count();
            away_probability.away_loss = host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals > 0).Count();

            away_probability.total_wins = away_probability.host_wins + away_probability.away_wins;
            away_probability.total_draws = away_probability.host_draws + away_probability.away_draws;
            away_probability.total_loss = away_probability.host_loss + away_probability.away_loss;

            away_probability.ht_total_wins = host.Where(e => e.home_team_big == away_team_big).Where(e => e.half_home_goals - e.half_away_goals > 0).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.half_home_goals - e.half_away_goals < 0).Count();
            away_probability.ht_total_draws = host.Where(e => e.home_team_big == away_team_big).Where(e => e.half_home_goals - e.half_away_goals == 0).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.half_home_goals - e.half_away_goals == 0).Count();
            away_probability.ht_total_loss = host.Where(e => e.home_team_big == away_team_big).Where(e => e.half_home_goals - e.half_away_goals < 0).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.half_home_goals - e.half_away_goals > 0).Count();

            away_probability.goals_win_2o = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals >= 2).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals <= -2).Count();
            away_probability.goals_win_1 = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals == 1).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals == -1).Count();
            away_probability.goals_draw_0 = away_probability.total_draws;
            away_probability.goals_loss_1 = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals == -1).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals == 1).Count();
            away_probability.goals_loss_2o = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals <= -2).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_home_goals - e.full_away_goals >= 2).Count();

            away_probability.mygoals_0 = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals == 0).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_away_goals == 0).Count();
            away_probability.mygoals_1 = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals == 1).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_away_goals == 1).Count();
            away_probability.mygoals_2 = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals == 2).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_away_goals == 2).Count();
            away_probability.mygoals_3o = host.Where(e => e.home_team_big == away_team_big).Where(e => e.full_home_goals >= 3).Count()
                 + host.Where(e => e.away_team_big == away_team_big).Where(e => e.full_away_goals >= 3).Count();

            away_probability.total_goals_0t1 = host.Where(e => e.full_home_goals + e.full_away_goals <= 1).Count();
            away_probability.total_goals_2t3 = host.Where(e => e.full_home_goals + e.full_away_goals <= 3 && e.full_home_goals + e.full_away_goals >= 2).Count();
            away_probability.total_goals_4t6 = host.Where(e => e.full_home_goals + e.full_away_goals <= 6 && e.full_home_goals + e.full_away_goals >= 4).Count();
            away_probability.total_goals_7o = host.Where(e => e.full_home_goals + e.full_away_goals >= 7).Count();

            away_probability.total_goals_double = host.Where(e => (e.full_home_goals + e.full_away_goals) % 2 == 0).Count();
            away_probability.total_goals_single = host.Where(e => (e.full_home_goals + e.full_away_goals) % 2 == 1).Count();

            int[] scores = new int[6];
            for (int i = 0; i < scores.Length; i++)
                scores[i] = 0;
            int index = 0;
            foreach (var ma in host.Take(6))
            {
                if (ma.full_home_goals - ma.full_away_goals > 0)
                    if (ma.home_team_big == away_team_big)
                        scores[index] = 3;
                if (ma.full_home_goals - ma.full_away_goals < 0)
                    if (ma.away_team_big == away_team_big)
                        scores[index] = 3;
                if (ma.full_home_goals - ma.full_away_goals == 0)
                    scores[index] = 1;
                index++;
            }
            away_probability.score_recent_1 = scores[0];
            away_probability.score_recent_2 = scores[0] + scores[1];
            away_probability.score_recent_3 = scores[0] + scores[1] + scores[2];
            away_probability.score_recent_4 = scores[0] + scores[1] + scores[2] + scores[3];
            away_probability.score_recent_5 = scores[0] + scores[1] + scores[2] + scores[3] + scores[4];
            away_probability.score_recent_6 = scores[0] + scores[1] + scores[2] + scores[3] + scores[4] + scores[5];

            return away_probability;
        }
        public ProbabilityModel ConvertJz(List<HistoryDataETLs> host, int? home_team_big, int? away_team_big)
        {
            var jz_probability = new ProbabilityModel();

            jz_probability.host_wins = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals > 0).Count();
            jz_probability.host_draws = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 0).Count();
            jz_probability.host_loss = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals < 0).Count();

            jz_probability.away_wins = host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals < 0).Count();
            jz_probability.away_draws = host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 0).Count();
            jz_probability.away_loss = host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals > 0).Count();

            jz_probability.total_wins = jz_probability.host_wins + jz_probability.away_wins;
            jz_probability.total_draws = jz_probability.host_draws + jz_probability.away_draws;
            jz_probability.total_loss = jz_probability.host_loss + jz_probability.away_loss;

            jz_probability.ht_total_wins = host.Where(e => e.home_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals > 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals < 0).Count();
            jz_probability.ht_total_draws = host.Where(e => e.home_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals == 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals == 0).Count();
            jz_probability.ht_total_loss = host.Where(e => e.home_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals < 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.half_home_goals - e.half_away_goals > 0).Count();

            jz_probability.goals_win_2o = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals >= 2).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals <= -2).Count();
            jz_probability.goals_win_1 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 1).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == -1).Count();
            jz_probability.goals_draw_0 = jz_probability.total_draws;
            jz_probability.goals_loss_1 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == -1).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals == 1).Count();
            jz_probability.goals_loss_2o = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals <= -2).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_home_goals - e.full_away_goals >= 2).Count();

            jz_probability.mygoals_0 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals == 0).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals == 0).Count();
            jz_probability.mygoals_1 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals == 1).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals == 1).Count();
            jz_probability.mygoals_2 = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals == 2).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals == 2).Count();
            jz_probability.mygoals_3o = host.Where(e => e.home_team_big == home_team_big).Where(e => e.full_home_goals >= 3).Count()
                 + host.Where(e => e.away_team_big == home_team_big).Where(e => e.full_away_goals >= 3).Count();

            jz_probability.total_goals_0t1 = host.Where(e => e.full_home_goals + e.full_away_goals <= 1).Count();
            jz_probability.total_goals_2t3 = host.Where(e => e.full_home_goals + e.full_away_goals <= 3 && e.full_home_goals + e.full_away_goals >= 2).Count();
            jz_probability.total_goals_4t6 = host.Where(e => e.full_home_goals + e.full_away_goals <= 6 && e.full_home_goals + e.full_away_goals >= 4).Count();
            jz_probability.total_goals_7o = host.Where(e => e.full_home_goals + e.full_away_goals >= 7).Count();

            jz_probability.total_goals_double = host.Where(e => (e.full_home_goals + e.full_away_goals) % 2 == 0).Count();
            jz_probability.total_goals_single = host.Where(e => (e.full_home_goals + e.full_away_goals) % 2 == 1).Count();

            int[] scores = new int[6];
            for (int i = 0; i < scores.Length; i++)
                scores[i] = 0;
            int index = 0;
            foreach (var ma in host.Take(6))
            {
                if (ma.full_home_goals - ma.full_away_goals > 0)
                    if (ma.home_team_big == home_team_big)
                        scores[index] = 3;
                if (ma.full_home_goals - ma.full_away_goals < 0)
                    if (ma.away_team_big == home_team_big)
                        scores[index] = 3;
                if (ma.full_home_goals - ma.full_away_goals == 0)
                    scores[index] = 1;
                index++;
            }
            jz_probability.score_recent_1 = scores[0];
            jz_probability.score_recent_2 = scores[0] + scores[1];
            jz_probability.score_recent_3 = scores[0] + scores[1] + scores[2];
            jz_probability.score_recent_4 = scores[0] + scores[1] + scores[2] + scores[3];
            jz_probability.score_recent_5 = scores[0] + scores[1] + scores[2] + scores[3] + scores[4];
            jz_probability.score_recent_6 = scores[0] + scores[1] + scores[2] + scores[3] + scores[4] + scores[5];

            return jz_probability;

        }

        public void CreateCollection()
        {
            LiveDataETLs ldata = new LiveDataETLs();
            HistoryDataTopDetail hdatatop = new HistoryDataTopDetail();
            foreach (var today_m in ldata.mongo_LiveDataETL.QueryMongo())
            {
                HistoryDataCalculateDocument hdata = new HistoryDataCalculateDocument();
                hdata._id = today_m._id;

                hdata.match_prop = new MatchModel();
                hdata.match_prop.match_type = today_m.match_type;
                hdata.match_prop.match_time = today_m.match_time;
                hdata.match_prop.home_team = today_m.home_team;
                hdata.match_prop.away_team = today_m.away_team;
                hdata.match_prop.home_team_big = today_m.home_team_big;
                hdata.match_prop.away_team_big = today_m.away_team_big;
                hdata.match_prop.asia_odds = today_m.asia_odds;

                var host = hdatatop.mongo_HistoryDataTopHostDocument.QueryMongo()
                    .Where(e => e._id == today_m._id)
                    .Select(e => e.history_data_etl)
                    .FirstOrDefault()
                    .OrderByDescending(e => e.match_time)
                    .ToList();
                hdata.host_probability = ConvertHost(host, today_m.home_team_big);
                hdata.host_probability.match_count = host.Count();

                var away = hdatatop.mongo_HistoryDataTopAwayDocument.QueryMongo()
                   .Where(e => e._id == today_m._id)
                   .Select(e => e.history_data_etl)
                   .FirstOrDefault()
                   .OrderByDescending(e => e.match_time)
                   .ToList();
                hdata.away_probability = ConvertAway(away, today_m.away_team_big);
                hdata.away_probability.match_count = away.Count();

                var jz = hdatatop.mongo_HistoryDataTopJzDocument.QueryMongo()
                   .Where(e => e._id == today_m._id)
                   .Select(e => e.history_data_etl)
                   .FirstOrDefault()
                   .OrderByDescending(e => e.match_time)
                   .ToList();
                hdata.jz_probability = ConvertJz(jz, today_m.home_team_big, today_m.away_team_big);
                hdata.jz_probability.match_count = jz.Count();



                hdata.result_score = new PredictModel();
                hdata.result_score.full_host_goals = today_m.full_home_goals;
                hdata.result_score.full_away_goals = today_m.full_away_goals;
                hdata.result_score.half_host_goals = today_m.half_home_goals;
                hdata.result_score.half_away_goals = today_m.half_away_goals;
                hdata.result_score.full_310value = get310value(today_m.full_home_goals, today_m.full_away_goals);
                hdata.result_score.half_310value = get310value(today_m.half_home_goals, today_m.half_away_goals);

                hdata.predict_score = new PredictModel();//这里还没有实现计算


                mongo_HistoryDataCalculateDocument.MongoCol.Insert(hdata);

            }
            Console.WriteLine("HistoryDataCalculateDocument->mongo->ok");
        }
        private int? get310value(int? home_goals, int? away_goals)
        {
            if (home_goals == null || away_goals == null) return null;
            int vaules = 1;
            if (home_goals - away_goals == 0) vaules = 1;
            if (home_goals - away_goals > 0) vaules = 3;
            if (home_goals - away_goals < 0) vaules = 0;
            return vaules;
        }
    }
}
