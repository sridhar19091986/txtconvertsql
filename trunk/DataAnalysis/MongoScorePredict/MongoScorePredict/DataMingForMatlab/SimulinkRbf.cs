using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoScorePredict.MongoCurd;

namespace MongoScorePredict.DataMingForMatlab
{
    public class SimulinkRbfLog
    {
        public long _id;
        public string matchtype;
        public string matchoverColumn;
        public string matchnowColumn;
        public string matchover;
        public string matchnow;
        public string matchid;
        public string grnn;
        public string pnn;
    }

    public class SimulinkRbf
    {
        private string mongo_collection = CommonAttribute.SimulinkRbf[0];
        private string mongo_db = CommonAttribute.SimulinkRbf[1];
        private string mongo_conn = CommonAttribute.SimulinkRbf[2];

        public MongoCrud<SimulinkRbfLog> mongocrud;

        public SimulinkRbf()
        {
            mongocrud = new MongoCrud<SimulinkRbfLog>(mongo_conn, mongo_db, mongo_collection);
        }
        #region Implementing IDisposable and the Dispose Pattern Properly
        private bool disposed = false; // to detect redundant calls
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~SimulinkRbf()
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
    }
}
