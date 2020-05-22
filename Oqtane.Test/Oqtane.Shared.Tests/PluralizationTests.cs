using Oqtane.Shared;
using Xunit;

namespace Oqtane.Test.Oqtane.Shared.Tests
{
    public class PluralizationTests
    {
        [Theory]
        [InlineData("Blog", "Blogs")]
        [InlineData("Inventory", "Inventories")]
        [InlineData("", "")]
        public void NavigateUrlTest(string singular, string expected)
        {
            // Arrange
            var actual = string.Empty;

            // Act
            actual = Pluralization.Pluralize(singular);

            // Assert
            Assert.Equal(expected, actual);
        }
    }

}