using System.Reflection;
using Xunit;

namespace AutoFixture.AutoMoq.UnitTest;

public class DependencyConstraints
{
    [Theory]
    [InlineData("FakeItEasy")]
    [InlineData("xunit")]
    [InlineData("xunit.extensions")]
    public void AutoMoqDoesNotReference(string assemblyName)
    {
        // Arrange
        // Act
        var references = typeof(AutoMoqCustomization).GetTypeInfo().Assembly.GetReferencedAssemblies();
        // Assert
        Assert.DoesNotContain(references, an => an.Name == assemblyName);
    }

    [Theory]
    [InlineData("FakeItEasy")]
    public void AutoFixtureUnitTestsDoNotReference(string assemblyName)
    {
        // Arrange
        // Act
        var references = this.GetType().GetTypeInfo().Assembly.GetReferencedAssemblies();
        // Assert
        Assert.DoesNotContain(references, an => an.Name == assemblyName);
    }
}