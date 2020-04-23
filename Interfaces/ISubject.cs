namespace DesignPatterns.Interfaces {
    public interface ISubject
    {
        void Attach(IStockObserver observer);
        void Detach(IStockObserver observer);
        void DetachAll();
        void Notify();
        void SetState(string state);
    } 
}