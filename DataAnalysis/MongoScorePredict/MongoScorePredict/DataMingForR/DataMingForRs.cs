/*
 * 
 * 写入mongo，由R操作
 * 
 * 写入txt，由rattle进行操作分析
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.DataMingForMatlab;
using System.Data;
using MongoScorePredict.Extensions;

namespace MongoScorePredict.DataMingForR
{
    public static class DataMingForRs
    {
        public static void MatchOverToTxt()
        {
            SimulinkMatchOver smo = new SimulinkMatchOver();
            var lookup_over = smo.mongocrud.QueryMongo().Where(e => e.Hmatch_count == 20)
             .Where(e => e.Haway_count > 0).Where(e => e.Hhost_count > 0)
             .Where(e => e.Amatch_count == 20)
             .Where(e => e.Ahost_count > 0).Where(e => e.Aaway_count > 0)
             .Where(e => e.Jmatch_count > 0).ToLookup(e => e.live);
            foreach (var overM in lookup_over)
            {
                DataTable dt1 = overM.CopyDataTable();
                DataTableToTxt.DataTable2TxtAll(dt1, @"over.csv");
            }
            Console.WriteLine("MatchOverToTxt->mongo->ok");
        }
        public static void MatchNowToTxt()
        {
            SimulinkMatchNow smm = new SimulinkMatchNow();
            var lookup_now = smm.mongocrud.QueryMongo().Where(e => e.Hmatch_count == 20)
                .Where(e => e.Haway_count > 0).Where(e => e.Hhost_count > 0)
                .Where(e => e.Amatch_count == 20)
                .Where(e => e.Ahost_count > 0).Where(e => e.Aaway_count > 0)
                .Where(e => e.Jmatch_count > 0).ToLookup(e => e.live);
            foreach (var nowM in lookup_now)
            {
                DataTable dt1 = nowM.CopyDataTable();
                DataTableToTxt.DataTable2TxtAll(dt1, @"now.csv");
            }
            Console.WriteLine("MatchNowToTxt->mongo->ok");
        }
    }
}
