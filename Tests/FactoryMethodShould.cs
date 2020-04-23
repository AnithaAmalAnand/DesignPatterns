using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DesignPatterns.Interfaces;

namespace DesignPatterns.Tests {
    public class FactoryMethodShould {
        private ServiceProvider _serviceProvider { get; set; }

        [Fact]
        public void ReturnCreatedObject() {

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IReconObjectFactory, ReconObjectFactory>();
            serviceCollection.AddScoped<ILoggerFactory, LoggerFactory>();

            _serviceProvider = serviceCollection.BuildServiceProvider();
            var reconObj = _serviceProvider.GetService<IReconObjectFactory>();

            IReconcile recObj1 = reconObj.GetReconObject("Trades");
            Assert.IsType<ReconcileTrades>(recObj1);
            Assert.IsNotType<ReconcileFixings>(recObj1);

            IReconcile recObj2 = reconObj.GetReconObject("Fixings");
            Assert.IsType<ReconcileFixings>(recObj2);
            Assert.IsNotType<ReconcileTrades>(recObj2);
        }
    }
}