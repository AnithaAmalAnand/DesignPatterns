using System;
public class SingletonService {
    private static readonly Lazy<SingletonService> _singletonObj =   new Lazy<SingletonService>(() => new SingletonService());

    private SingletonService() {
        //Make constructor private to prevent instantiation and class derivation
    }

    public static SingletonService GetInstance() {
        return _singletonObj.Value;
    }
}