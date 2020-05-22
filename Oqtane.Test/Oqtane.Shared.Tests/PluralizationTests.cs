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
        public void PluralizationTest(string singular, string expected)
        {
            // Arrange
            var actual = string.Empty;

            // Act
            actual = Pluralization.Pluralize(singular);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("Test.input.[Module]s.value", "Blog", "Test.input.Blogs.value")]
        [InlineData("Test.input.[Module]s.value", "Inventory", "Test.input.Inventories.value")]
        [InlineData("Test input [Module]s value", "Inventory", "Test input Inventories value")]
        [InlineData("Test.input.[Module].value", "Inventory", "Test.input.Inventory.value")]
        [InlineData("Test input [Module] value", "Inventory", "Test input Inventory value")]
        [InlineData("", "", "")]
        public void ReplaceModuleWithPluralTest(string input, string singular, string expected)
        {
            // Arrange
            var actual = string.Empty;

            // Act
            actual = Pluralization.ReplaceModuleWithPlural(input, singular);

            // Assert
            Assert.Equal(expected, actual);
        }


    }

}