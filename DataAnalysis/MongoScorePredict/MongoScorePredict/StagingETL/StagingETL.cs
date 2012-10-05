/*
 * 
 * 第5步，把预测数据保存
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;
using MongoScorePredict.DataMingForMatlab;

namespace MongoScorePredict.StagingETL
{
    public class StagingETLsDocument
    {
        public long _id;
        public int pnn_310values;
        public int grnn_310values;
        public int grnn_home_goals;
        public int grnn_away_goals;
    }
    public class StagingETLs
    {
        private string mongo_collection = CommonAttribute.StagingETLs[0];
        private string mongo_db = CommonAttribute.StagingETLs[1];
        private string mongo_conn = CommonAttribute.StagingETLs[2];
        public MongoCrud<StagingETLsDocument> mongo_StagingETLs;
        public StagingETLs()
        {
            mongo_StagingETLs = new MongoCrud<StagingETLsDocument>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~StagingETLs()
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
            SimulinkRbf simulinkrbf = new SimulinkRbf();
            var docs = simulinkrbf.mongocrud.QueryMongo();
            foreach (var doc in docs)
            {

                string[] ids = doc.matchid.Split(new char[] { '\r', '\n' });
                string[] pnns = doc.pnn.Split(new char[] { '\r', '\n' });
                string[] grnns = doc.grnn.Split(new char[] { '\r', '\n' });
                for (int i = 0; i < ids.Length; i++)
                {
                    int index = 0;
                    StagingETLsDocument std = new StagingETLsDocument();
                    std._id = long.Parse(ids[i]);
                    std.pnn_310values = int.Parse(pnns[i]);
                    string[] grnn_vs = grnns[i].Trim().Split(new char[] { ' ' });
                    foreach (var vs in grnn_vs)
                    {
                        if (vs != string.Empty)
                        {
                            grnn_vs[index] = vs;
                            index++;
                        }
                    }
                    std.grnn_home_goals = int.Parse(grnn_vs[0]);
                    std.grnn_away_goals = int.Parse(grnn_vs[1]);
                    std.grnn_310values = int.Parse(grnn_vs[2]);

                    mongo_StagingETLs.MongoCol.Insert(std);
                }
            }
            Console.WriteLine("StagingETLs->mongo->ok");
        }
    }
}
