using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DesignPatterns.Interfaces;

namespace DesignPatterns
{
    class Program
    {
        private static IServiceProvider _provider;
        static void Main(string[] args)
        {
            
            _provider = BuildDependencies().BuildServiceProvider();

            var logger = _provider.GetService<ILoggerFactory>().CreateLogger<Program>();

            logger.LogInformation("Observer");

            var product = new Product("Coffee", "Unavailable");
            var loggerFactory = _provider.GetService<ILoggerFactory>();
            var o1 = new Observer(loggerFactory,product);
            var o2 = new Observer(loggerFactory,product);
        
            product.Attach(o1);
            product.Attach(o2);
            product.SetState("Available");
            product.DetachAll();


            
            logger.LogInformation("FactoryMethod");

            var reconObj = _provider.GetService<IReconObjectFactory>();
            IReconcile recTrade = reconObj.GetReconObject("Trades");
            recTrade.DoReconciliation();

            IReconcile recFixing = reconObj.GetReconObject("Fixings");
            recFixing.DoReconciliation();


            logger.LogInformation("Singleton");
            
            var singleObj1 = SingletonService.GetInstance();
            singleObj1.PrintPattern();

            var singleObj2 = SingletonService.GetInstance();
            singleObj2.PrintPattern();

            for (int i=0; i< 2000; i++) {
                Console.Write(i + ",");
            }

            Console.ReadLine();
        }


        private static IServiceCollection BuildDependencies()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(opt => opt.AddConsole().SetMinimumLevel(LogLevel.Debug));
            serviceCollection.AddScoped<IReconObjectFactory, ReconObjectFactory>();
            serviceCollection.AddScoped<ILoggerFactory, LoggerFactory>();
            serviceCollection.AddScoped<IAccountProcessor, AccountProcessor>();
            serviceCollection.AddScoped<IUserProcessor, UserProcessor>();
            return serviceCollection;
        }
    }
}
