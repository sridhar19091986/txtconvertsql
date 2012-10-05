
/*
 * 
 * 第4步
 * 
 * 写入mongo，由matlab操作
 * 
 * 
 * 遍历预测为空的，按照日期进行滚动预测？
 * 
 * 
 * 按照日期进行分割。滚动预测。
 * 
 * 
 * 算法设计比较重要
 * 
 * 这里为什么会出现不能计算的情况呢?估计是维度的问题，直接用matlab进行模拟，最后用get;set属性屏蔽部分字段，达到降维的目标
 * 
 * */

#define abc

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Reflection;
using MongoScorePredict.Extensions;
using System.Collections;

namespace MongoScorePredict.DataMingForMatlab
{
    public class DataMingForMatlabs
    {
        public static void CreateSimCollection()
        {
            using (SimulinkMatchNow smm = new SimulinkMatchNow())
                smm.CreateLiveCollection();
            GC.Collect();
            using (SimulinkMatchOver smo = new SimulinkMatchOver())
                smo.CreateLiveCollection();
            GC.Collect();
            Console.WriteLine("CreateSimCollection->mongo->ok");

        }
        public static void DoSimulink()
        {
            SimulinkMatchNow smm = new SimulinkMatchNow();
            SimulinkMatchOver smo = new SimulinkMatchOver();
            SimulinkRbf simulinkrbf = new SimulinkRbf();
            int simulinkno = 0;
            var lookup_now = smm.mongocrud.QueryMongo().Where(e => e.Hmatch_count == 20)
                .Where(e => e.Haway_count > 0).Where(e => e.Hhost_count > 0)
                .Where(e => e.Amatch_count == 20)
                .Where(e => e.Ahost_count > 0).Where(e => e.Aaway_count > 0)
                .Where(e => e.Jmatch_count > 0).ToLookup(e => e.live);
            var lookup_over = smo.mongocrud.QueryMongo().Where(e => e.Hmatch_count == 20)
          .Where(e => e.Haway_count > 0).Where(e => e.Hhost_count > 0)
                .Where(e => e.Amatch_count == 20)
                .Where(e => e.Ahost_count > 0).Where(e => e.Aaway_count > 0)
                .Where(e => e.Jmatch_count > 0).ToLookup(e => e.live);
            foreach (var nowM in lookup_now)
            {
                simulinkno++;
                NNPredication nn = new NNPredication();
                DataTable dt1 = nowM.ToDataTable();
                string streamx = DataTableToTxt.DataTable2Txt(dt1, nn.tempx);
                var overM = lookup_over[0];
                if (!overM.Any()) continue;
                DataTable dt2 = overM.ToDataTable();
                string streamy = DataTableToTxt.DataTable2Txt(dt2, nn.tempy);

                SimulinkRbfLog srlog = new SimulinkRbfLog();
                srlog._id = simulinkno; Console.WriteLine(srlog._id);
                //srlog.matchtype = nowM.Key;
                srlog.matchover = streamy;  //y是训练用
                srlog.matchnow = streamx;  //x是预测目标
                srlog.matchnowColumn = DataTableToTxt.getDataTableColumnName(dt1);
                srlog.matchoverColumn = DataTableToTxt.getDataTableColumnName(dt2);
                srlog.matchid = nowM.Select(e => e._id.ToString()).ToList().Aggregate((a, b) => a + "\n" + b);
                srlog.grnn = nn.NewGrnn();
                srlog.pnn = nn.NewPnn();

                simulinkrbf.mongocrud.MongoDropColCreateCol.Insert(srlog);
            }
            Console.WriteLine("DoSimulink->mongo->ok");
        }
    }
}
        
