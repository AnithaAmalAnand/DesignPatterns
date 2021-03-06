using Xunit;
using Microsoft.Extensions.DependencyInjection;
using DesignPatterns.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace DesignPatterns.Tests {
    
    public class FacadeShould {
        private ServiceProvider _serviceProvider { get; set; }
        [Fact]
        public void RunToCompletion() {

            //Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IAccountProcessor, AccountProcessor>();
            serviceCollection.AddScoped<IUserProcessor, UserProcessor>();
            serviceCollection.AddScoped<IFacadeService, FacadeService>();
            serviceCollection.AddScoped<ILoggerFactory, LoggerFactory>();
             
            
            _serviceProvider = serviceCollection.BuildServiceProvider();
            var facadeObject = _serviceProvider.GetService<IFacadeService>();
            
            //Act
            var result = facadeObject.Process();

            //Assert
            result.Status.ToString().Should().Be("RanToCompletion");
        }
    }
}