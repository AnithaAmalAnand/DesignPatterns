using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

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

            IReconcile recObj = reconObj.GetReconObject("Trades");
            Assert.IsType<ReconcileTrades>(recObj);
        }
    }
}