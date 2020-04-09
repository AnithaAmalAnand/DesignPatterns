using System;
public class SingletonService {
    private static readonly Lazy<SingletonService> _singletonObj =   new Lazy<SingletonService>(() => new SingletonService());
    private string uid;
    private SingletonService() {
        //Make constructor private to prevent instantiation and class derivation
        uid = Guid.NewGuid().ToString();
    }

    public static SingletonService GetInstance() {
        return _singletonObj.Value;
    }

    public void PrintPattern() {
        Console.WriteLine("I am Singleton with uid:" + uid);
    }
}