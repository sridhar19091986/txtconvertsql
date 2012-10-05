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
 * */

#define abcd

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.HistoryDataETL;
using MongoScorePredict.LiveDataETL;
using MongoScorePredict.AlgorithmModel;
using MongoScorePredict.StagingETL;

namespace MongoScorePredict
{
    class Program
    {
        static void Main(string[] args)
        {
            int overday = 100;
#if abc
            using (LiveDataETLs lcb = new LiveDataETLs())
            {
                lcb.CreateResultCollection(overday);
                lcb.CreateLiveCollection();
            }             
            GC.Collect();
            using (HistoryDataTopDetail lcbs = new HistoryDataTopDetail())
                lcbs.CreateCollection();
            GC.Collect();
            using (HistoryDataCalculate lcbs = new HistoryDataCalculate())
                lcbs.CreateCollection();
            GC.Collect(); 

            DataMingForMatlab.DataMingForMatlabs.CreateCollection();
#endif
            DataMingForMatlab.DataMingForMatlabs.Simulink();

            StagingETLs sts = new StagingETLs();
            sts.CreateLiveCollection();

            ScorePredict sp = new ScorePredict();
            sp.CreateLiveCollection();

            Console.ReadKey();
        }
    }
}
