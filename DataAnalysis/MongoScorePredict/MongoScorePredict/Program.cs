/*
 * 
 * 数据在mongodb中采用列存储的方式，加快数据的查询速度
 * 
 * 采用mongodb和matlab和r语言的接口进行分析
 * 
 * 中间计算过程保存在mongodb中，无一遗漏
 * 
 * 单变量的R图（分布等），双变量的R图（线性关系等），多变量的R的（聚类关系等）
 * 
 * 
 * 采用分层的结构，采集层，共享层，应用层。开启3个应用程序？
 * 
 * 
 * 采集层暂时用其他的工具代替，应用层也用其他的工具代替，暂时只完成共享层（核心计算功能）。
 * 
 * 核心层用matlab和r共同进行数据调试。维度的进一步扩展和优化？以提升数据预测的精度？
 * 
 * 
 * MongoUpdateCol和MongoDropColCreateCol的优化处理，只更新最新数据，以便于提升处理速度。
 * 
 * 即只启动只对每个collection的更新操作？问题在哪里？每个创建的都需要处理一次，便于进行更新操作。
 * 
 * 是否需要再开始一个项目，实施即时更新呢？即做一个这个项目的copy版本，实现更新操作。
 * 
 * 最核心代码进行优化，1.速度，2.准确性，3.模型优化。
 * 
 * 
 * { "match_type" : { $in : [ "德甲", "西甲","英超"] } }
 * 
 * 
 * 训练的时间长度和训练的比赛类型。pnn要求的样本数多。grnn则可以快速收敛，但是是局部值。
 * 
 * 
 * 
 * */

#define abc

#define abcd

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.HistoryDataETL;
using MongoScorePredict.LiveDataETL;
using MongoScorePredict.AlgorithmModel;
using MongoScorePredict.StagingETL;
using MongoScorePredict.DataMingForR;
using MongoScorePredict.Extensions;
using System.Data;
using MongoScorePredict.EmailScorePredict;

namespace MongoScorePredict
{
    class Program
    {
        static void Main(string[] args)
        {

#if abcd
            int overday = 365 * 4;

            using (LiveDataETLs lcb = new LiveDataETLs())
            {
                lcb.CreateResultCollection(overday);
                lcb.CreateLiveCollection();
            }
            GC.Collect();
#endif
#if abcd
            using (HistoryDataTopDetail lcbs = new HistoryDataTopDetail())
                lcbs.CreateCollection();
            GC.Collect();

            using (HistoryDataCalculate lcbs = new HistoryDataCalculate())
                lcbs.CreateCollection();
            GC.Collect();

            DataMingForMatlab.DataMingForMatlabs.CreateSimCollection();

             DataMingForMatlab.DataMingForMatlabs.DoSimulink();
              using (StagingETLs sts = new StagingETLs())
                sts.CreateLiveCollection();
            GC.Collect();
            
#endif
#if abc
            using (ScorePredict sp = new ScorePredict())
                sp.CreateLiveCollection();
            GC.Collect();
            using (ScorePredictForCn sp = new ScorePredictForCn())
                sp.CreateLiveCollection();
            GC.Collect();

            //预测结束
#endif

#if abc
            //csv和email观察预测结果
            string filename = @"ScorePredictForCn.csv";
            ScorePredictForCn smo = new ScorePredictForCn();
            var today_ma = smo.mongo_ScorePredictForCn.QueryMongo();
            DataTable dt1 = today_ma.CopyDataTable();
            DataTableToTxt.DataTable2TxtAll(dt1, filename);
            Console.WriteLine("ScorePredictForCnToTxt->mongo->ok");

            SendPredictEmail.SendMail(filename);
#endif

#if abc
            //写入csv给R研究用
            DataMingForRs.MatchNowToTxt();
            DataMingForRs.MatchOverToTxt();
#endif

            Console.ReadKey();
        }
    }
}
