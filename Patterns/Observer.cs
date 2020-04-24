using DesignPatterns.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace DesignPatterns {


    public class Observer: IStockObserver {
        
        private string _state;
        private ISubject _subject;
        private ILogger _logger;

        public Observer(ILoggerFactory loggerFactory, ISubject subject) {
            _logger = loggerFactory.CreateLogger<Observer>();
            subject.Attach(this);

        }
        
        public void UpdateStatus(string state) {
            _state = state;
            _logger.LogDebug("Stock status: " + state);
        }

    }


    public class Product: ISubject {

        private string _name;
        private string _state;

        public Product(string name, string state) {
            _name = name;
            _state = state;
        }

        private List<IStockObserver> lstObservers = new List<IStockObserver>(); 

        public void Attach(IStockObserver observer) {
            lstObservers.Add(observer);
        }

         public void Detach(IStockObserver observer) {
            lstObservers.Remove(observer);
        }

        public void DetachAll() {
            lstObservers.Clear();
        }

        public void SetState(string state) {
            _state = state;
            Notify();
        }


        public void Notify() {
             foreach(var observer in lstObservers) {
                observer.UpdateStatus(_state);
            }
        }
    }
}