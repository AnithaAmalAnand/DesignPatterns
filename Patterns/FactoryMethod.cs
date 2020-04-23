using System;
using Microsoft.Extensions.Logging;
using DesignPatterns.Interfaces;

namespace DesignPatterns {
   

    public class ReconcileTrades: IReconcile {
        private ILogger _logger;
        public ReconcileTrades(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<ReconcileTrades>();
        }

        public void DoReconciliation() {
            _logger.LogDebug("Reconcile Trades Logic");
        }
    }

    public class ReconcileFixings: IReconcile {
        private ILogger _logger;

          public ReconcileFixings(ILoggerFactory loggerFactory) {
            _logger = loggerFactory.CreateLogger<ReconcileFixings>();
        }
        public void DoReconciliation() {
            _logger.LogDebug("Reconcile Fixings Logic");
        }
    }

  

     public class ReconObjectFactory: IReconObjectFactory
    {
        private ILoggerFactory _loggerFactory;
        public ReconObjectFactory(ILoggerFactory loggerFactory) {
            _loggerFactory = loggerFactory;
        }
        public IReconcile GetReconObject(string ReconType)
        {
            IReconcile objReconcile = null;

            switch (ReconType)
            {
                case "Trades":
                    objReconcile = new ReconcileTrades(_loggerFactory);
                    break;

                case "Fixings":
                    objReconcile = new ReconcileFixings(_loggerFactory);
                    break;
            }
            return objReconcile;
        }
    }

}