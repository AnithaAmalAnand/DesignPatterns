using Xunit;

namespace DesignPatterns.Tests {
    public class SingletonShould {
        [Fact]
        public void ReturnSameInstance()
        {
        //Given
        var sObj1 = SingletonService.GetInstance();
        var sObj2 = SingletonService.GetInstance();
        
        //When
        
        //Then
        Assert.Same(sObj1, sObj2);
        }
    }

}